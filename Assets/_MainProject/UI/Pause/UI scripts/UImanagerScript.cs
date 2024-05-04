using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanagerScript : MonoBehaviour
{
    public GameObject pause;
    public GameObject exitQ;

    private GameObject PlayerController;
    void Start()
    {
        PlayerController = GameObject.Find("FirstPersonController");

        pause.SetActive(false);
        exitQ.SetActive(false);
        pause.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseT();
            Cursor.visible = true;
            PlayerController.GetComponent<FirstPersonController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void PauseF()
    {
        pause.SetActive(false);
        Cursor.visible = false;
        PlayerController.GetComponent<FirstPersonController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
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
