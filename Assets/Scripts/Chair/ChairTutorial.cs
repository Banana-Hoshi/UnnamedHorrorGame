using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairTutorial : MonoBehaviour
{
    public GameObject enemySpawn;
    public GameObject ui1, ui2, ui3, parentUI;
    bool t = false;


    private void Start()
    {
        ui1.SetActive(true);
        enemySpawn.GetComponent<SpawnEnemies>().enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ui1.SetActive(false);
            ui2.SetActive(true);
            t = true;
        }
        if (t && Input.GetKeyUp(KeyCode.Mouse0))
        {
            StartCoroutine(WaitForS());
        }
    }

    IEnumerator WaitForS()
    {
        yield return new WaitForSeconds(3);
        ui2.SetActive(false);
        ui3.SetActive(true);
        yield return new WaitForSeconds(3);
        ui3.SetActive(false);
        parentUI.SetActive(false);
        enemySpawn.GetComponent<SpawnEnemies>().enabled = true;
        t = false;
    }
}
