using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.7f;
    private Vector3 originalPos;
    private GameObject mainCamera; // дл€ хранени€ ссылки на основную камеру
    private GameObject jumpscareCamera; // дл€ хранени€ ссылки на камеру jumpscare

    void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        jumpscareCamera = GameObject.FindGameObjectWithTag("newCamera");
        originalPos = transform.localPosition;

        // ”бедитесь, что камера jumpscare отключена с самого начала


    }

    public void StartShake()
    {
        // ƒеактивируем основную камеру и активируем камеру jumpscare
        if (mainCamera != null)
            mainCamera.SetActive(false);

        if (jumpscareCamera != null)
            jumpscareCamera.SetActive(true);

        originalPos = transform.localPosition;
        InvokeRepeating("Shake", 0f, 0.005f);
        Invoke("StopShake", shakeDuration);
    }

    private void Shake()
    {
        if (shakeMagnitude > 0)
        {
            Vector3 camPos = originalPos + Random.insideUnitSphere * shakeMagnitude;

            // ѕредотвращаем изменение Z позиции камеры
            camPos.z = originalPos.z;

            transform.localPosition = camPos;
        }
    }

}
