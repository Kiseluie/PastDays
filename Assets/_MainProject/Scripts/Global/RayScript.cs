using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    public int distance;
    public GameObject CollectText;
    public GameObject player;
    private Camera camera;
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
            if (hit.collider.tag == ("Battery"))//какой тег
            {
                CollectText.SetActive(true);
                var _addBattery = player.gameObject.GetComponent<Flashlight>();
                if (Input.GetKeyDown(KeyCode.E) && _addBattery.batteryCount < _addBattery.maxBatteryCount)
                {
                    _addBattery.addBattery();
                    Destroy(hit.collider.gameObject);
                    CollectText.SetActive(false);
                }
            }
            else
            {
                CollectText.SetActive(false);
            }
        }
    }
}
