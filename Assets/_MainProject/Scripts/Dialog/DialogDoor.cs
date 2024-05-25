using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogDoor : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;


    public void StartDialog()
    {
        DialogManager.GetInstance().EnterDialogMode(inkJSON);
    }
}
