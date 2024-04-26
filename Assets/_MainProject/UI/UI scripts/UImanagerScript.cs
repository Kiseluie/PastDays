using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanagerScript : MonoBehaviour
{
    public GameObject pause;
    public GameObject exitQ;
    public GameObject LaterObject;


    void Start()
    {
        pause.SetActive(false);
        ExitQf();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
        }
    }
    public void PauseF()
    {
        pause.SetActive(false);
        ExitQf();
        LaterObject.SetActive(false);
    }
    public void ExitQt()
    {
        exitQ.SetActive(true);
    }
    public void ExitQf()
    {
        exitQ.SetActive(false);
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
