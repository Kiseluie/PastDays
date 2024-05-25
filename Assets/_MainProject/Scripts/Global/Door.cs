using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    private GameObject player;
    private Component[] meshes;
    [SerializeField] private AudioSource AudioSource;

    public bool isLocked;
    public bool isOpening;

    private void Start()
    {
        player = GameObject.Find("FirstPersonController");
        meshes = gameObject.GetComponentsInChildren<MeshCollider>();
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= 3) 
        {
            if (Input.GetKeyDown(KeyCode.E) && isOpening == false)
            {
                if (!isLocked)
                {
                    AudioSource.PlayOneShot(audioClips[0]);
                    StartCoroutine(OpenDoor());
                }
                else if (isLocked)
                {
                    
                    UnlockDoor();
                }

            }

        }

    }

    private void UnlockDoor()
    {
        if(player.GetComponent<RayScript>().keys > 0)
        {
            AudioSource.PlayOneShot(audioClips[1]);
            isLocked = false;
            player.GetComponent<RayScript>().keys--;
            player.GetComponent<RayScript>().KeyImage.SetActive(false);
        }
        else
        {
            AudioSource.PlayOneShot(audioClips[2]);
            gameObject.GetComponent<DialogDoor>().StartDialog();
        }
    }


    IEnumerator OpenDoor() 
    {
        isOpening = true;
        gameObject.GetComponent<Animator>().Play("Door");
        yield return new WaitForSeconds(0.05f);
        foreach (MeshCollider mesh in meshes)
        {
            mesh.enabled = false;
        }
        yield return new WaitForSeconds(1f);
        foreach (MeshCollider mesh in meshes)
        {
            mesh.enabled = true;
        }
        yield return new WaitForSeconds(4.0f);

        gameObject.GetComponent<Animator>().Play("NewState");
        isOpening = false;
    }
}
