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
    public float catсhingRange = 2f;
    public float chaseRange = 10;

    private bool _jumpScarePlayed = false; // Флаг для отслеживания проигрывания звука

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float destination = Vector3.Distance(Entity.transform.position, player.position);

        if (!_jumpScarePlayed && destination <= catсhingRange)
        {
            StartCoroutine(PlayJumpScareAndReload());
        }
        else if (_jumpScarePlayed && destination > catсhingRange)
        {
            // Позволяет монстру снова испугать игрока, если тот ушёл на безопасное расстояние
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
        _jumpScarePlayed = true; // Устанавливаем флаг, что звук проигрывается
        jumpscare.Play();
        yield return new WaitForSeconds(jumpscare.clip.length); // Ожидаем окончания проигрывания звука
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Перезагружаем текущую сцену
    }
}
