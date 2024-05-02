using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var flashlight = other.gameObject.GetComponent<Flashlight>();
        if (flashlight != null && flashlight.batteryCount < flashlight.maxBatteryCount)
        {
            flashlight.addBattery();
            Destroy(gameObject);
        }
    }
}
