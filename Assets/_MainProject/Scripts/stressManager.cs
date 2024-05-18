using System.Collections;
using UnityEngine;

public class StressManager : MonoBehaviour
{
    public float maxStress = 100f;
    private float stressLevel = 0f;
    public Flashlight flashlight;
    public float speedIncreaseSpeed = 4f;
    public float speedDecreaseSpeed = 2f;

    public AudioSource heartbeating;
    public float minHeartbeatPitch = 1f;
    public float maxHeartbeatPitch = 1.5f; // Устанавливает предел, насколько высоким может быть pitch
    public GameObject monsterPrefab;
    public Transform spawnPoint;
    private bool monsterSpawned = false;

    private void Start()
    {
        heartbeating.pitch = minHeartbeatPitch; // Инициализация pitch
    }

    void Update()
    {
        if (flashlight.value <= 0)
        {
            IncreaseStress();
        }
        else if (flashlight.value > 0)
        {
            DecreaseStress();
        }

        if (stressLevel >= maxStress && !monsterSpawned)
        {
            SpawnMonster();
            monsterSpawned = true;
        }

        if (stressLevel < maxStress)
        {
            monsterSpawned = false;
        }

        UpdateHeartbeat();
    }

    void IncreaseStress()
    {
        stressLevel += Time.deltaTime * speedIncreaseSpeed;
    }

    void DecreaseStress()
    {
        stressLevel -= Time.deltaTime * speedDecreaseSpeed;
        stressLevel = Mathf.Max(stressLevel, 0);
    }

    void UpdateHeartbeat()
    {
        if (stressLevel >= 10)
        {
            if (!heartbeating.isPlaying)
            {
                heartbeating.Play();
            }

            // Устанавливаем pitch на основе уровня стресса
            heartbeating.pitch = Mathf.Lerp(minHeartbeatPitch, maxHeartbeatPitch, (stressLevel - 10) / (maxStress - 10));
        }
        else
        {
            if (heartbeating.isPlaying)
            {
                heartbeating.Stop();
            }
            // Сброс pitch к стандартному значению при снижении стресса ниже 10
            heartbeating.pitch = minHeartbeatPitch;
        }
    }

    void SpawnMonster()
    {
        Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);
    }
}