using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSteps : MonoBehaviour
{
    public AudioSource footstepSoundSource;
    public AudioClip[] footstepSounds;

    public float footstepInterval = 1.0f;

    private void OnEnable()
    {
        StartCoroutine(PlayFootstepSounds());
    }

    private IEnumerator PlayFootstepSounds()
    {
        while (true)
        {
            yield return new WaitForSeconds(footstepInterval);
            if (this.gameObject.activeSelf)
            {
                PlayRandomFootstepSound();
            }
        }
    }

    private void PlayRandomFootstepSound()
    {
        if (footstepSounds.Length > 0)
        {
            AudioClip clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
            footstepSoundSource.PlayOneShot(clip);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
