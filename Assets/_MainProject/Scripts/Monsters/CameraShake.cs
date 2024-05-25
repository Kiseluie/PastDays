using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.7f;
    private Vector3 originalPos;
    private GameObject mainCamera;
    private GameObject jumpscareCamera;

    void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        jumpscareCamera = GameObject.FindGameObjectWithTag("newCamera");
        originalPos = transform.localPosition;
    }

    public void StartShake()
    {
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

            camPos.z = originalPos.z;

            transform.localPosition = camPos;
        }
    }

}
