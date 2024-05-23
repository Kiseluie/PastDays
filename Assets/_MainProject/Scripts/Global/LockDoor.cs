using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoor : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    private GameObject player;
    private Component[] meshes;
    public int Need = 3;
    public int Key = 0;
    [SerializeField] private AudioSource AudioSource;


    public bool isOpening;

    private void Start()
    {
        player = GameObject.Find("FirstPersonController");
        meshes = gameObject.GetComponentsInChildren<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= 3)
        {
            if (Input.GetKeyDown(KeyCode.E) && isOpening == false && Key >= Need)
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
