using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSteps : MonoBehaviour
{
    public AudioSource footstepSoundSource; // Аудио источник, добавленный к монстру
    public AudioClip[] footstepSounds; // Массив ваших звуков шагов

    public float footstepInterval = 1.0f; // Интервал между шагами в секундах

    private void OnEnable()
    {
        // Запуск корутины по проигрыванию звука шагов
        StartCoroutine(PlayFootstepSounds());
    }

    private IEnumerator PlayFootstepSounds()
    {
        while (true) // Бесконечный цикл
        {
            yield return new WaitForSeconds(footstepInterval); // Ожидание одной секунды
            if (this.gameObject.activeSelf) // Проверка, что объект монстра активен
            {
                PlayRandomFootstepSound();
            }
        }
    }

    private void PlayRandomFootstepSound()
    {
        // Выбираем случайный AudioClip из массива и воспроизводим его
        if (footstepSounds.Length > 0)
        {
            AudioClip clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
            footstepSoundSource.PlayOneShot(clip);
        }
    }

    private void OnDisable()
    {
        // Остановка корутины, если монстр удаляется со сцены
        StopAllCoroutines();
    }
}
