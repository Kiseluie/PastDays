using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInfected : MonoBehaviour
{
    public float destructionDistance = 3f;
    public bool doorIsImposter = false;
    public float delay = 60f;
    public float delayMonsterMin = 5f;
    public float delayMonsterMax = 10f;
    public float safeDelay = 1.8f;
    public AudioSource breathing;
    public GameObject monsterCerberusPrefab;
    public float chanceDoorInfected = 0.3f;

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

        StartCoroutine(doorIsImposterActions());
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
        while (true && !doorIsOpened)
        {
            yield return new WaitForSeconds(0.1f);
            if (!doorIsOpened)
            {
                yield return new WaitForSeconds(Random.Range(delayMonsterMin, delayMonsterMax));
                doorIsImposter = false;
                yield return new WaitForSeconds(delay);
                doorIsImposter = Random.value < chanceDoorInfected;
                monsterSpawned = false;
            }

        }
    }

    private IEnumerator doorIsImposterActions() 
    {
        if (doorIsImposter)
        {
            if (!breathing.isPlaying)
            {
                breathing.Play();
            }

            yield return new WaitForSeconds(safeDelay); 
            if (Input.GetKeyDown(KeyCode.E) && !monsterSpawned)
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

}