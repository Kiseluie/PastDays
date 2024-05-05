using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ShadowAI : MonoBehaviour
{
    public AudioSource jumpscare;

    public NavMeshAgent Entity;
    public Transform player;
    public float cat�hingRange = 2f;
    public float chaseRange = 10;

    private bool _jumpScarePlayed = false; // ���� ��� ������������ ������������ �����

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float destination = Vector3.Distance(Entity.transform.position, player.position);

        if (!_jumpScarePlayed && destination <= cat�hingRange)
        {
            StartCoroutine(PlayJumpScareAndReload());
        }
        else if (_jumpScarePlayed && destination > cat�hingRange)
        {
            // ��������� ������� ����� �������� ������, ���� ��� ���� �� ���������� ����������
            _jumpScarePlayed = false;
        }

        if (destination <= chaseRange)
        {
            Entity.destination = player.position;
        }

        if (player.position.y < -3)
        {
            SceneManager.LoadScene(1);
        }
    }

    private IEnumerator PlayJumpScareAndReload()
    {
        _jumpScarePlayed = true; // ������������� ����, ��� ���� �������������
        jumpscare.Play();
        yield return new WaitForSeconds(jumpscare.clip.length); // ������� ��������� ������������ �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // ������������� ������� �����
    }
}
