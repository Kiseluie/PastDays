using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PuppetAI : MonoBehaviour
{
    public AudioSource jumpscare;

    public NavMeshAgent puppetEntity;
    public Transform player;
    public float catchingRange = 2f;
    public float chaseRange = 10;
    public float heightOffset = 1.0f;
    public float tiltAngle = 30f;
    public Transform mainCamera;
    public Transform PuppetMonster;
    public float shakeDuration;
    public float shakeMagnitude = 0.1f;
    public GameObject playerObject;
    public bool _jumpScarePlayed = false;

    private GameObject spotpoint;
    private Vector3 originalCameraPosition;
    private FirstPersonController firstPersonController;
    private Rigidbody rb;
    private ChanceShadowAttack chanceAttackScript;
    private GameObject stepsAudioSource;
    

    

    void Start()
    {
        spotpoint = GameObject.FindGameObjectWithTag("spotpointtagPuppet");
        playerObject = GameObject.FindGameObjectWithTag("Player");
        stepsAudioSource = GameObject.FindGameObjectWithTag("audioObjectTag");
        firstPersonController = playerObject.GetComponent<FirstPersonController>();
        rb = playerObject.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mainCamera = Camera.main.transform;
        shakeDuration = jumpscare.clip.length;

    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(puppetEntity.transform.position, player.position);

        if (!_jumpScarePlayed && distanceToPlayer <= catchingRange)
        {
            firstPersonController.enabled = false;
            puppetEntity.enabled = false;
            LookAtAndRaiseCamera();
            Destroy(stepsAudioSource);
            Destroy(rb);
            StartCoroutine(PlayJumpScareAndReload());

        }
        else if (_jumpScarePlayed && distanceToPlayer > catchingRange)
        {
            _jumpScarePlayed = false;
        }

        if (distanceToPlayer <= chaseRange)
        {
            puppetEntity.destination = player.position;
        }

        if (player.position.y < -3)
        {
            SceneManager.LoadScene(1);
        }
    }

    void LookAtAndRaiseCamera()
    {
        originalCameraPosition = mainCamera.position;

        mainCamera.LookAt(spotpoint.transform.position);

        Vector3 cameraPosition = mainCamera.position;
        cameraPosition.y += heightOffset;
        mainCamera.position = cameraPosition;

        TiltCameraUpwards();

        StartCoroutine(ShakeCamera());
    }

    private IEnumerator PlayJumpScareAndReload()
    {
        _jumpScarePlayed = true;
        jumpscare.Play();

        yield return new WaitForSeconds(jumpscare.clip.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator ShakeCamera()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            Vector3 randomPoint = originalCameraPosition + Random.insideUnitSphere * shakeMagnitude;
            mainCamera.position = randomPoint;

            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        mainCamera.position = originalCameraPosition;
    }

    void TiltCameraUpwards()
    {
        mainCamera.Rotate(-tiltAngle, 0, 0, Space.Self);
    }
}

