using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : MonoBehaviour
{
    public float DisapearDistance = 10;
    public bool WillDestroyed = false;

    private GameObject player;
    private GameObject audio;
    private StressManager stress;

    void Start()
    {
        player = GameObject.Find("FirstPersonController");
        audio = GameObject.Find("Jumpscare");
        stress = player.GetComponent<StressManager>();

    }

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

        if(Vector3.Distance(transform.position, player.transform.position) <= DisapearDistance && WillDestroyed)
        {
            stress.stressLevel += 60;
            audio.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
