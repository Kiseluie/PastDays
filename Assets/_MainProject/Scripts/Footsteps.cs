using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Footsteps : MonoBehaviour
{
    [SerializeField] LayerMask groundLayer;

    [SerializeField] List<AudioClip> TerrainSounds;
    [SerializeField] List<AudioClip> buildingSounds;

    [SerializeField] AudioSource currentSound;

    string[] tags = { "Terrain", "Building" };

    Rigidbody _playerBody;
    FirstPersonController _playerFPC;

    private void Start()
    {
        _playerBody = GetComponent<Rigidbody>();
        _playerFPC = GetComponent<FirstPersonController>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!currentSound.isPlaying)
        {
            currentSound.Stop();
            switch (collision.collider.tag)
            {
                case "Terrain":
                    currentSound.PlayOneShot(TerrainSounds[Random.Range(0, TerrainSounds.Count)]);
                    break;
                case "Building":
                    currentSound.PlayOneShot(buildingSounds[Random.Range(0, buildingSounds.Count)]);
                    break;
                default:
                    currentSound.PlayOneShot(buildingSounds[Random.Range(0, buildingSounds.Count)]);
                    break;
            }
        }
    }

    private void Update()
    {
        StopMusic();
        StateChange();
    }

    private void StopMusic()
    {
        bool isMoving = _playerBody.velocity.magnitude > 0.1f;
        if (!isMoving)
        {
            currentSound.Stop();
        }
    }
    private void StateChange()
    {
        //sprint
        if (_playerFPC.isSprinting)
        {
            currentSound.pitch = 1.75f;
        }

        if (!_playerFPC.isSprinting)
        {
            currentSound.pitch = 1f;
        }

        //crouch
        if (_playerFPC.isCrouched)
        {
            currentSound.pitch = 0.8f;
            currentSound.volume = 0.2f;
        }

        if (!_playerFPC.isCrouched && !_playerFPC.isSprinting)
        {
            currentSound.pitch = 1f;
            currentSound.volume = 0.4f;
        }
    }
}
