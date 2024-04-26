using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject us;
    public GameObject exitQ;

    private void Start()
    {
        UsF();
        ExitQuestionF();
    }
    public void UsT()
    {
        us.SetActive(true);
    }
    public void UsF()
    {
        us.SetActive(false);
    }
    public void ExitQuestion()
    {
        exitQ.SetActive(true);

    }
    public void ExitQuestionF()
    {
        exitQ.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
