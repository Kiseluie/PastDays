using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInfected : MonoBehaviour
{
    public float destructionDistance = 3f;
    public bool doorIsImposter = false;
    public float delay = 60f;
    public AudioSource breathing;
    public GameObject monsterCerberusPrefab;

    public Door DoorComponent;
    public bool doorIsOpened = false;

    private bool monsterSpawned = false;
    private GameObject player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(ChangeImposterStatus());
    }

    private void Update()
    {
        doorIsOpened = DoorComponent.isOpening;

        if (doorIsImposter)
        {
            if (!breathing.isPlaying)
            {
                breathing.Play();
            }

            if (doorIsOpened && !monsterSpawned)
            {
                SpawnMonster();
            }
        }
        else
        {
            if (breathing.isPlaying)
            {
                breathing.Stop();
            }
        }
    }

    private void SpawnMonster()
    {
        if (monsterCerberusPrefab != null && Vector3.Distance(player.transform.position, transform.position) <= destructionDistance)
        {
            Instantiate(monsterCerberusPrefab, transform.position, Quaternion.identity);
            monsterSpawned = true;
        }
    }

    private IEnumerator ChangeImposterStatus()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            doorIsImposter = Random.value < 0.3f;
            monsterSpawned = false;
        }
    }

}