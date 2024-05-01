using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsBlink : MonoBehaviour
{
    private bool isFlickering = false;
    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        if(isFlickering == false)
        {
            StartCoroutine(FlickeringLight());
        }
    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timer = Random.Range(.01f, 1f);
        yield return new WaitForSeconds(timer);
        this.gameObject.GetComponent<Light>().enabled = true;
        timer = Random.Range(.01f, 1f);
        yield return new WaitForSeconds(timer);
        isFlickering = false;

    }
}
