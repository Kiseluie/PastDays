using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class CerberusAI : MonoBehaviour
{
    public AudioSource jumpscare;

    public NavMeshAgent cerberusEntity;
    public Transform player;
    public float catchingRange = 2f;
    public float chaseRange = 10;
    public float heightOffset = 1.0f;
    public float tiltAngle = 30f;
    public Transform mainCamera;
    public Transform cerberusMonster;
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
    private GameObject shadowMonster;

    private bool _isRbDestroyed = false;
    private bool _isFaced = false;




    void Start()
    {
        spotpoint = GameObject.FindGameObjectWithTag("spotpointtagCerberus");
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
        float distanceToPlayer = Vector3.Distance(cerberusEntity.transform.position, player.position);

        if (!_jumpScarePlayed && distanceToPlayer <= catchingRange)
        {
            firstPersonController.enabled = false;
            cerberusEntity.enabled = false;
            LookAtAndRaiseCamera();
            Destroy(stepsAudioSource);
            if (!_isRbDestroyed)
            {
                rb.isKinematic = true;
                rb.velocity = Vector3.zero;
                _isRbDestroyed = !_isRbDestroyed;
            }
            StartCoroutine(PlayJumpScareAndReload());

        }
        else if (_jumpScarePlayed && distanceToPlayer > catchingRange)
        {
            _jumpScarePlayed = false;
        }

        if (distanceToPlayer <= chaseRange && !_jumpScarePlayed)
        {
            FaceTarget();
            _isFaced = true;
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
        StartCoroutine(WaitHalfSecond());


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

    void FaceTarget()
    {
        Vector3 targetPosition = new Vector3(player.position.x,
                                             cerberusEntity.transform.position.y,
                                             player.position.z);

        cerberusEntity.transform.LookAt(targetPosition);
    }

    private IEnumerator WaitHalfSecond()
    {
        jumpscare.Play();
        yield return new WaitForSeconds(0.1f);
        Destroy(shadowMonster);
        _jumpScarePlayed = true;

    }
}

