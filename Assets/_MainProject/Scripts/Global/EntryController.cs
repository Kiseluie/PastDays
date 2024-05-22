using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryController : MonoBehaviour
{
    private GameObject Player;
    private GameObject UI;
    [SerializeField] private GameObject Flashlight;
    [SerializeField] private GameObject EntryCamera;
    public bool isDoing = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Player = GameObject.Find("FirstPersonController");
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        isDoing = true;
        Player.GetComponent<FirstPersonController>().enabled = false;
        Flashlight.GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(4);
        Destroy(EntryCamera);
        Player.GetComponent<FirstPersonController>().enabled = true;
        Flashlight.GetComponent<Light>().enabled = true;
        isDoing = false;
    }
}
