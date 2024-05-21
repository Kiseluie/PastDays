using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    public int distance;
    public GameObject CollectText;
    public GameObject player;
    private Camera camera;
    public GameObject Door;
    private void Start()
    {
        CollectText.SetActive(false);
        camera = Camera.main;
    }
    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.tag == ("Battery") || hit.collider.tag == ("Key"))//появляется надпись "press E to collect"
            {
                CollectText.SetActive(true);
            }
            else
            {
                CollectText.SetActive(false);
            }
            if(hit.collider.tag == ("Key"))//подбор ключа
            {
                var _lock = Door.GetComponent<LockDoor>();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(hit.collider.gameObject);
                    CollectText.SetActive(false);
                    _lock.Key++;
                }
            }
            if (hit.collider.tag == ("Battery"))//подбор батарейки
            {
                var _addBattery = player.gameObject.GetComponent<Flashlight>();
                if (Input.GetKeyDown(KeyCode.E) && _addBattery.batteryCount < _addBattery.maxBatteryCount)
                {
                    _addBattery.addBattery();
                    Destroy(hit.collider.gameObject);
                    CollectText.SetActive(false);
                }
            }
        }
    }
}
