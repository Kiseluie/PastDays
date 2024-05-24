using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private GameObject gameUI;

    private Story currentStory;
    private bool dialogIsPlaying;

    private static DialogManager instance;
    private void Awake()
    {
        if (instance != null) 
        {
            Debug.LogWarning("Found more than one Dialog");
        }
        instance = this;
    }

    public static DialogManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogIsPlaying = false;
        dialogPanel.SetActive(false);
    }

    private void Update()
    {
        if (!dialogIsPlaying && dialogPanel.active == true)
        {
            StartCoroutine(ContinueStory());
        }
    }

    public void EnterDialogMode(TextAsset inkJSON)
    {
        if (!dialogIsPlaying && dialogPanel.active == false)
        {
            currentStory = new Story(inkJSON.text);
            dialogIsPlaying = true;
            dialogPanel.SetActive(true);
            gameUI.SetActive(false);

            StartCoroutine(ContinueStory());
        }
    }

    private void ExitDialogMode()
    {
        dialogIsPlaying = false;
        dialogPanel.SetActive(false);
        dialogText.text = "";
        gameUI.SetActive(true);
    }

    private IEnumerator ContinueStory()
    {
        dialogIsPlaying = true;
        if (currentStory.canContinue)
        {
            dialogText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogMode();
        }
        yield return new WaitForSeconds(4);
        dialogIsPlaying = false;
    }

}
