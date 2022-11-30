using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JimScare : MonoBehaviour
{

    public GameObject environment;
    public GameObject playerCam;
    public GameObject JimKill;
    public AnimationClip clip;
    public GameObject flash;


    public void KillAll()
    {
        environment.SetActive(false);
        int num = FindObjectsOfType<SpiderController>().Length;
        flash.SetActive(false);
        for (int i = 0; i < num; i++)
        {
            FindObjectOfType<SpiderController>().gameObject.SetActive(false);
        }
    }

    public void JimJumpScare(Transform trans, Quaternion quat)
    {
        Instantiate(JimKill, trans.position + new Vector3(0, 1, 0), quat, gameObject.transform);
        playerCam.SetActive(false);
        StartCoroutine(NextScene());
    }

    public IEnumerator NextScene()
    {
        yield return new WaitForSeconds(clip.length);
        SceneManager.LoadScene("DemoCredits");
    }
}
