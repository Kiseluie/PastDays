using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChanceShadowAttack : MonoBehaviour
{
    public AudioSource scarySoundSource;
    public GameObject shadowPrefab;
    public Transform spawnPoint;
    public List<Transform> spawnPoints;
    public ShadowAI shadowAI;

    public float spawnDistance = 25f;
    public LayerMask spawnLayerMask;
    public float minTime = 180f;
    public float maxTime = 360f;
    public float spawnChance = 0.5f;
    public float shadowDestroyDelay = 20f;

    private void Start()
    {
        shadowAI = GetComponent<ShadowAI>();
        StartCoroutine(SoundAndSpawnRoutine());
    }

    private IEnumerator SoundAndSpawnRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);

            scarySoundSource.Play();

            yield return new WaitForSeconds(scarySoundSource.clip.length);

            if (Random.value <= spawnChance)
            {
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
                GameObject shadowInstance = Instantiate(shadowPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
                StartCoroutine(DestroyShadowAfterTime(shadowInstance, shadowDestroyDelay));
            }
        }
    }
    private IEnumerator DestroyShadowAfterTime(GameObject shadow, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (!shadowAI._jumpScarePlayed)
        Destroy(shadow);
    }


}