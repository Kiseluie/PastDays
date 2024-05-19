using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class StressManager : MonoBehaviour
{
    public float maxStress = 100f;
    private float stressLevel = 0f;
    public Flashlight flashlight;
    public float speedIncreaseSpeed = 4f;
    public float speedDecreaseSpeed = 2f;

    public AudioSource heartbeating;
    public AudioSource apperianceSound;

    public float minHeartbeatPitch = 1f;
    public float maxHeartbeatPitch = 1.5f;
    public GameObject monsterPrefab;
    public Transform spawnPoint;


    public Vignette vignette;
    public GameObject cameraObject;
    private bool monsterSpawned = false;
    private PostProcessVolume postProcessVolume;
    public LensDistortion lensDistortion;


    private void Start()
    {
        heartbeating.pitch = minHeartbeatPitch;
        postProcessVolume = cameraObject.GetComponent<PostProcessVolume>();

        if (postProcessVolume.profile.TryGetSettings(out Vignette vignetteSettings))
        {
            vignette = vignetteSettings;
        }
        if (postProcessVolume.profile.TryGetSettings(out LensDistortion lensDistortionSettings))
        {
            lensDistortion = lensDistortionSettings;
        }
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
        UpdateVignette();
        UpdateLensDistortion();
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

            heartbeating.pitch = Mathf.Lerp(minHeartbeatPitch, maxHeartbeatPitch, (stressLevel - 10) / (maxStress - 10));
        }
        else
        {
            if (heartbeating.isPlaying)
            {
                heartbeating.Stop();
            }
            heartbeating.pitch = minHeartbeatPitch;
        }
    }
    void UpdateVignette()
    {
        if (vignette != null)
        {
            float vignetteIntensity = Mathf.Lerp(0.2f, 0.6f, stressLevel / maxStress);
            vignette.intensity.value = vignetteIntensity;
        }
    }

    void UpdateLensDistortion()
    {
        if (lensDistortion != null)
        {
            float distortionIntensity = Mathf.Lerp(20f, -60f, stressLevel / maxStress);
            lensDistortion.intensity.value = distortionIntensity;
        }
    }

    void SpawnMonster()
    {
        StartCoroutine(AppearanceSoundCoroutine());
    }

    private IEnumerator AppearanceSoundCoroutine()
    {
        apperianceSound.Play();
        yield return new WaitForSeconds(3);
        Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}