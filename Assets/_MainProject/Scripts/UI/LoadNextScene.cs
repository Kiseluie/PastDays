using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] private int sceneNum;
    private void OnEnable()
    {
        SceneManager.LoadScene(sceneNum);
    }
}
