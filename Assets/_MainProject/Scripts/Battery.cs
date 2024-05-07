using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public GameObject ÑollectionText;
    public bool Near = false;
    private void Start()
    {
        ÑollectionText.SetActive(false);
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Near = true;
        }
        else
        {
            Near = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ÑollectionText.SetActive(true);
            if (Near == true)
            {
                var flashlight = other.gameObject.GetComponent<Flashlight>();
                if (flashlight != null && flashlight.batteryCount < flashlight.maxBatteryCount)
                {
                    flashlight.addBattery();
                    Destroy(gameObject);
                    ÑollectionText.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ÑollectionText.SetActive(false);
        }
    }

}   
