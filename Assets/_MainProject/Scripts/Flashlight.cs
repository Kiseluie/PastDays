using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    //public RectTransform valueRectTransform;
    public TextMeshProUGUI batteryPercentage;
    public float value = 100;
    public float DischargeSpeed = 1f;

    private bool isFlickering = false;
    private float timer = 0;

    private bool FlashlightIsOn = true;
    private float _maxValue;
    private float outputNumber;
    private GameObject flashlightObject;
    // Start is called before the first frame update
    void Start()
    {
        _maxValue = value;
        DrawBatteryBar();
        flashlightObject = GameObject.Find("Flashlight");
    }

    // Update is called once per frame
    void Update()
    {
        FlashlightDischarge();
    }

    public void AddCharge(float amount)
    {
        value += amount;
        value = Mathf.Clamp(value, 0, _maxValue);
        DrawBatteryBar();
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
        }
        else
        {
            FlashlightIsOn = true;
            value -= DischargeSpeed * Time.deltaTime;
            DrawBatteryBar();
        }

        flashlightObject.SetActive(FlashlightIsOn);   
    }

    private void DrawBatteryBar()
    {
        outputNumber = Mathf.Round(value);
        //valueRectTransform.anchorMax = new Vector2(value / _maxValue, 1);
        batteryPercentage.text = outputNumber.ToString() + "%";
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
