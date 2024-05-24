using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanagerScript : MonoBehaviour
{
    public GameObject pause;
    public GameObject exitQ;
    public GameObject Dark;
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
        DarkFalse();
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
    public void DarkTrue()
    {
        Dark.SetActive(true);
    }
    public void DarkFalse()
    {
        Dark.SetActive(false);
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
        DarkFalse();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PauseT()
    {
        DarkTrue();
        pause.SetActive(true);
    }
}
