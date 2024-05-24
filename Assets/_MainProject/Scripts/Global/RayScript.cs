using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    public int distance;
    public GameObject CollectText;
    public GameObject player;
    private Camera camera;
    public GameObject LockDoor;
    public GameObject FirstDoor;
    public TextMeshProUGUI KeyText;

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
                var _lock = LockDoor.GetComponent<LockDoor>();
                var _lockFirst = FirstDoor.GetComponent<LockDoorFirst>();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (_lockFirst.FirstLock == true)
                    {
                        Destroy(hit.collider.gameObject);
                        CollectText.SetActive(false);
                        _lock.Key++;
                        KeyText.text = "Keys: " + _lock.Key.ToString() + "/" + _lock.Need.ToString();
                    }
                    else
                    {
                        Destroy(hit.collider.gameObject);
                        CollectText.SetActive(false);
                        _lockFirst.Key++;
                        KeyText.text = "Keys: " + _lockFirst.Key.ToString() + "/" + _lockFirst.Need.ToString();
                    }
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
