using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject Credits;
    public GameObject exitQuestion;
    public GameObject Menu;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Credits.SetActive(false);
        exitQuestion.SetActive(false);
    }
    public void CreditsTrue()
    {
        Credits.SetActive(true);
        Menu.SetActive(false);
    }
    public void CreditsFalse()
    {
        Credits.SetActive(false);
        Menu.SetActive(true);
    }
    public void ExitQuestionTrue()
    {
        exitQuestion.SetActive(true);
        Menu.SetActive(false);
    }
    public void ExitQuestionFalse()
    {
        exitQuestion.SetActive(false);
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
