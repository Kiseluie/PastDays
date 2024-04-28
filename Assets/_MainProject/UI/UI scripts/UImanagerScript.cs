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
        ExitQf();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            pause.SetActive(true);
            Cursor.visible = true;
        }
    }
    public void PauseF()
    {
        pause.SetActive(false);
        Cursor.visible = false;
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
