using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public GameObject �ollectionText;
    public bool Near = false;
    private void Start()
    {
        �ollectionText.SetActive(false);
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
            �ollectionText.SetActive(true);
            if (Near == true)
            {
                var flashlight = other.gameObject.GetComponent<Flashlight>();
                if (flashlight != null && flashlight.batteryCount < flashlight.maxBatteryCount)
                {
                    flashlight.addBattery();
                    Destroy(gameObject);
                    �ollectionText.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            �ollectionText.SetActive(false);
        }
    }

}   
