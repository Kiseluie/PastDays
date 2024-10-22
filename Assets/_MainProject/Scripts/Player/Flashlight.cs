using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    //public RectTransform valueRectTransform;
    public TextMeshProUGUI batteryPercentage;
    public TextMeshProUGUI batteryCountUI;
    public float maxValue = 100;
    public float value = 100;
    public float DischargeSpeed = 1f;
    public int batteryCount = 0;
    public int maxBatteryCount = 4;
    public float ChargeAmount = 50;

    private bool isFlickering = false;
    private float timer = 0;

    private bool FlashlightIsOn = true;
    private float outputNumber;
    private GameObject maxUI;
    private GameObject flashlightObject;
    public float distance = 5;
    // Start is called before the first frame update
    void Start()
    {
        DrawBatteryBar();
        maxUI = GameObject.Find("batteryMax");
        flashlightObject = GameObject.Find("Flashlight");
    }

    // Update is called once per frame
    void Update()
    {
        FlashlightDischarge();
        AddCharge(ChargeAmount);
    }

    public void addBattery()
    { 
        batteryCount++;
        DrawBatteryBar();
    }

    private void AddCharge(float amount)
    {
        if (Input.GetKeyDown(KeyCode.R) && batteryCount > 0)
        {
            value += amount;
            value = Mathf.Clamp(value, 0, maxValue);
            DrawBatteryBar();
            FlashlightIsOn = true;
            flashlightObject.SetActive(FlashlightIsOn);
            batteryCount--;
        }
        if (batteryCount == maxBatteryCount)
        {
            maxUI.SetActive(true);
        }
        else
        {
            maxUI.SetActive(false);
        }
    }

    private void FlashlightDischarge()
    {
        if (isFlickering == false && FlashlightIsOn && value <= 10)
        {
            StartCoroutine(FlickeringLight());
        }
        
        if(value <= 0)
        {
            FlashlightIsOn = false;
            flashlightObject.SetActive(FlashlightIsOn);
        }
        else
        {
            value -= DischargeSpeed * Time.deltaTime;
            DrawBatteryBar();
        }

        
    }

    private void DrawBatteryBar()
    {
        outputNumber = Mathf.Round(value);
        //valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
        batteryPercentage.text = outputNumber.ToString() + "%";
        batteryCountUI.text = batteryCount.ToString();
    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        this.flashlightObject.GetComponent<Light>().enabled = false;
        timer = Random.Range(.01f, 1f);
        yield return new WaitForSeconds(timer);
        this.flashlightObject.GetComponent<Light>().enabled = true;
        timer = Random.Range(.01f, 1f);
        yield return new WaitForSeconds(timer);
        isFlickering = false;

    }
}
