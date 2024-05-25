using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    public int distance;
    public GameObject CollectText;
    public GameObject player;
    //public GameObject Door;
    //public GameObject FirstDoor;
    //public TextMeshProUGUI KeyText;

    public int keys = 0;

    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] public GameObject KeyImage;
    private AudioSource audioSource;
    private Camera rayCamera;

    private void Start()
    {
        CollectText.SetActive(false);
        rayCamera = Camera.main;
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        RaycastHit hit;
        Ray ray = rayCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.tag == ("Battery") || hit.collider.tag == ("Key"))//���������� ������� "press E to collect"
            {
                CollectText.SetActive(true);
                
            }
            else
            {
                CollectText.SetActive(false);
            }
            if(hit.collider.tag == ("Key"))//������ �����
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    KeyImage.SetActive(true);
                    keys++;
                    Destroy(hit.collider.gameObject);
                    CollectText.SetActive(false);
                    audioSource.PlayOneShot(audioClips[0]);
                }
            }
            if (hit.collider.tag == ("Battery"))//������ ���������
            {
                var _addBattery = player.gameObject.GetComponent<Flashlight>();
                if (Input.GetKeyDown(KeyCode.E) && _addBattery.batteryCount < _addBattery.maxBatteryCount)
                {
                    _addBattery.addBattery();
                    Destroy(hit.collider.gameObject);
                    CollectText.SetActive(false);
                    audioSource.PlayOneShot(audioClips[0]);
                }
            }
        }
    }
}
