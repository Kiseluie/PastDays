using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : MonoBehaviour
{
    public float DisapearDistance = 10;
    public bool WillDestroyed = false;

    private GameObject player;
    private Component screamAudio;
    private bool Dieing;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FirstPersonController");
        screamAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);

        if(Vector3.Distance(transform.position, player.transform.position) <= DisapearDistance && !WillDestroyed)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -5, gameObject.transform.position.z);
        }

        else
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
        }

        if(Vector3.Distance(transform.position, player.transform.position) <= DisapearDistance && WillDestroyed && !Dieing)
        {
            StartCoroutine(WaitDie());  
        }
    }

    IEnumerator WaitDie()
    {
        Dieing = true;
        screamAudio.GetComponent<AudioSource>().Play();
        Component[] meshes = gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach(Component mesh in meshes)
        {
            mesh.GetComponent<MeshRenderer>().enabled = false;
        }
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
