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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
        }
    }
    public void PauseF()
    {
        pause.SetActive(false);
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
}
