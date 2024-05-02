using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public float ChargeAmount = 50;
    private void OnTriggerEnter(Collider other)
    {
        var flashlight = other.gameObject.GetComponent<Flashlight>();
        if (flashlight != null)
        {
            flashlight.AddCharge(ChargeAmount);
            Destroy(gameObject);
        }
    }
}
