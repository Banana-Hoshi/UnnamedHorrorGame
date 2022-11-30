using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class Flash : MonoBehaviour {

  public float timer = 0.0f;
  public float flashRange;
  public float test;
  public float fadeScale, distanceScale, intensityScale;
  public float maxBlinkTime;
  public GameObject lightPrefab, lightObjects, lightGameObject, cam;
  public RectTransform topEye, bottomEye;
  public float colliderOffset, radiusRatio, distanceRatio;
  float timeSinceLastFlash;
  public float flashCooldown;

  private void Update() {
    timeSinceLastFlash += Time.deltaTime;
    if (Input.GetKey(KeyCode.Mouse0) && timeSinceLastFlash > flashCooldown) {
      if (timer <= maxBlinkTime) {
        timer += Time.deltaTime;
        if (topEye.rect.height < 550) {
          topEye.sizeDelta = new Vector2(topEye.rect.width, Mathf.MoveTowards(topEye.rect.height, 550f, Time.deltaTime * 10000f));
          test = topEye.rect.height;
          bottomEye.sizeDelta = new Vector2(topEye.rect.width, Mathf.MoveTowards(bottomEye.rect.height, 550f, Time.deltaTime * 10000f));
        }
      }
    }
    if (Input.GetKeyUp(KeyCode.Mouse0) && timer != 0) {
      flashRange = timer;
      timer = 0.0f;
      topEye.sizeDelta = new Vector2(topEye.rect.width, 0);
      bottomEye.sizeDelta = new Vector2(topEye.rect.width, 0);
      FlashSpawn();
    }

  }

  public void FlashSpawn() {
    lightGameObject = Instantiate(lightPrefab, cam.transform.position, Quaternion.Euler(cam.transform.eulerAngles), lightObjects.transform);
    lightGameObject.GetComponent<Light>().range = flashRange * distanceScale;
    lightGameObject.GetComponent<Light>().intensity = flashRange * distanceScale * intensityScale;
    lightGameObject.GetComponent<FlashFade>().fadeTime = flashRange * fadeScale;
    lightGameObject.GetComponent<FlashFade>().enabled = true;
    lightGameObject.GetComponent<FlashFade>().ImportScale(fadeScale, distanceScale, intensityScale, colliderOffset, radiusRatio, distanceRatio, flashRange);
    lightGameObject.GetComponent<CapsuleCollider>().center = new Vector3( 0, 0, (distanceRatio * flashRange * distanceScale) / 2 + colliderOffset);
    lightGameObject.GetComponent<CapsuleCollider>().radius = radiusRatio * flashRange * distanceScale;
    lightGameObject.GetComponent<CapsuleCollider>().height = distanceRatio * flashRange * distanceScale;
    lightGameObject.GetComponent<CapsuleCollider>().enabled = true;
    timeSinceLastFlash = 0;
  }
}
