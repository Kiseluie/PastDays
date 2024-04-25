using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject us;

    private void Start()
    {
        UsF();
    }
    public void UsT()
    {
        us.SetActive(true);
    }
    public void UsF()
    {
        us.SetActive(false);
    }


}
