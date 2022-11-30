using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed : Interactable
{
    public GameObject playerCam, bedCam, alarmCam;

    private void Start()
    {
        bedCam.SetActive(false);
        alarmCam.SetActive(false);
    }

    public override string GetDescription()
    {
        return "Press [E] to sleep";
    }

    public override void Interact()
    {
        bedCam.SetActive(true);
        playerCam.SetActive(false);
        StartCoroutine(Sleep(3));
    }

    IEnumerator Sleep(int s)
    {
        yield return new WaitForSeconds(s);
        alarmCam.SetActive(true);
        bedCam.SetActive(false);
        yield return new WaitForSeconds(s);
        SceneManager.LoadScene("Chair");
        //NextLevel();
    }
}