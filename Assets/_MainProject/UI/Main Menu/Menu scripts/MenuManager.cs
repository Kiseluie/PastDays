using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject us;
    public GameObject exitQ;
    public GameObject Menu;

    private void Start()
    {
        us.SetActive(false);
        exitQ.SetActive(false);
    }
    public void UsT()
    {
        us.SetActive(true);
        Menu.SetActive(false);
    }
    public void UsF()
    {
        us.SetActive(false);
        Menu.SetActive(true);
    }
    public void ExitQuestion()
    {
        exitQ.SetActive(true);
        Menu.SetActive(false);
    }
    public void ExitQuestionF()
    {
        exitQ.SetActive(false);
        Menu.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
}
