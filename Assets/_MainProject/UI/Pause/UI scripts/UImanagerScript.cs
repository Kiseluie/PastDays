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
        UnPauseGame();
        PlayerController = GameObject.Find("FirstPersonController");

        pause.SetActive(false);
        exitQ.SetActive(false);
        pause.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseT();
            PlayerController.GetComponent<FirstPersonController>().enabled = false;
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void PauseF()
    {
        pause.SetActive(false);
        PlayerController.GetComponent<FirstPersonController>().enabled = true;
        UnPauseGame();
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
        Time.timeScale = 1;
        AudioListener.pause = false;
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
