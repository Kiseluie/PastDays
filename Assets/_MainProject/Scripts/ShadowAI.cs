using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ShadowAI : MonoBehaviour
{
    public AudioSource jumpscare;

    public NavMeshAgent Entity;
    public Transform player;
    public float catchingRange = 2f;
    public float chaseRange = 10;
    public float heightOffset = 1.0f;
    public Transform mainCamera; 
    public Transform ShadowMonster;

    private FirstPersonController firstPersonController;
    private Rigidbody rb;
    public GameObject playerObject;

    private bool _jumpScarePlayed = false;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        firstPersonController = playerObject.GetComponent<FirstPersonController>();
        rb = playerObject.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mainCamera = Camera.main.transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(Entity.transform.position, player.position);

        if (!_jumpScarePlayed && distanceToPlayer <= catchingRange)
        {
            firstPersonController.enabled = false;
            rb.isKinematic = false;
            Entity.enabled = false;
            LookAtAndRaiseCamera();
            StartCoroutine(PlayJumpScareAndReload());
        }
        else if (_jumpScarePlayed && distanceToPlayer > catchingRange)
        {
            _jumpScarePlayed = false;
        }

        if (distanceToPlayer <= chaseRange)
        {
            Entity.destination = player.position;
        }

        if (player.position.y < -3)
        {
            SceneManager.LoadScene(1);
        }
    }

    void LookAtAndRaiseCamera()
    {
        Vector3 cameraPosition = mainCamera.position;
        mainCamera.LookAt(Entity.transform.position);
        cameraPosition.y += heightOffset;
        mainCamera.position = cameraPosition;
    }

    private IEnumerator PlayJumpScareAndReload()
    {
        _jumpScarePlayed = true;
        jumpscare.Play();

        yield return new WaitForSeconds(jumpscare.clip.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
