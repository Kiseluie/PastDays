using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{

    public GameObject DeathScreen;
    public bool playerIsAlived = true;
    private GameObject player;
    public CerberusAI _jumpscarePlayedComponent;

    private bool _isJumpscared;

    void Start()
    {
        DeathScreen = GameObject.FindGameObjectWithTag("abc");
        DeathScreen.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        playerIsAlived = player.GetComponent<FirstPersonController>().playerIsAlive;
        _isJumpscared = _jumpscarePlayedComponent._jumpScarePlayed;

    }
    void Update()
    {
        if (player != null)
        {
            playerIsAlived = player.GetComponent<FirstPersonController>().playerIsAlive;
        }

        if (!playerIsAlived && !_isJumpscared)
        {
            DeathScreen.SetActive(true);
            _isJumpscared = true;
        }
    }

}
