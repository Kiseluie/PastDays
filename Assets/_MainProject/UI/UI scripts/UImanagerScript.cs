using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanagerScript : MonoBehaviour
{
    public GameObject pause;
    public GameObject exitQ;


    void Start()
    {
        pause.SetActive(false);
        exitQ.SetActive(false);
        pause.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PauseT();
            //Cursor.visible = true;
            GetComponent<FirstPersonController>().enabled = false;
        }
    }
    public void PauseF()
    {
        pause.SetActive(false);
        //Cursor.visible = false;
        GetComponent<FirstPersonController>().enabled = true;
    }
    public void ExitQt()
    {
        exitQ.SetActive(true);
        pause.SetActive(false);
    }
    public void ExitQf()
    {
        exitQ.SetActive(false);
        pause.SetActive(true);
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void PauseT()
    {
        pause.SetActive(true);
    }
}
