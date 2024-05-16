using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotReady : MonoBehaviour
{
    public GameObject LaterObject;
    private void Start()
    {
        LaterF();
    }
    public void LaterT()
    {
        LaterObject.SetActive(true);
    }
   public void LaterF()
    {
        LaterObject.SetActive(false);
    }
}
