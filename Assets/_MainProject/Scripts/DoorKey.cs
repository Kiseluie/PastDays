using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorKey : MonoBehaviour
{
    public TextMeshProUGUI CollectKeyText;
    public GameObject CollectBackground;
    public GameObject CollectText;
    public int KeyCounter;
    public int _maxKeyCounter;
    public int distance;
    private void Start()
    {
        CollectText.SetActive(false);
        CollectBackground.SetActive(false);
    }
    private void Update()
    {
        if(KeyCounter == _maxKeyCounter)
        {
            Destroy(gameObject);
        }
        CollectKey();  
    }
    private void CollectKey()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, distance))//подбор ключа на дистанции 
        {
            if (hit.collider.tag == ("Key"))//какой тег
            {
                CollectBackground.SetActive(true);
                CollectText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(hit.collider.gameObject);
                    KeyCounter++;
                    WriteCollectText();
                }
            }
        }
        else
        {
            CollectText.SetActive(false);
        }
    }
    private void WriteCollectText()
    {
        CollectKeyText.text = KeyCounter.ToString();
    }
}
