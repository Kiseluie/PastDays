using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    private GameObject player;
    private Component[] meshes;
    private AudioSource AudioSource;

    public bool isOpening;

    private void Start()
    {
        player = GameObject.Find("FirstPersonController");
        meshes = gameObject.GetComponentsInChildren<MeshCollider>();
        AudioSource = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= 3) 
        {
            if (Input.GetKeyDown(KeyCode.E) && isOpening == false)
            {
                AudioSource.PlayOneShot(audioClips[0]);
                StartCoroutine(OpenDoor());
            }
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
