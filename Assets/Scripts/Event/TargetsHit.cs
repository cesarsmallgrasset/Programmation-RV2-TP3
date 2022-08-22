using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsHit : MonoBehaviour
{

    //Reference au TargetCounter
    [SerializeField] GameObject HolderReference;
    TargetCounter targetCounter;



    [SerializeField] private Light Greenlight;
    [SerializeField] private Light Redlight;



    void Awake()
    {
        targetCounter = HolderReference.GetComponent<TargetCounter>();
        Greenlight.GetComponent<Light>().enabled = false;
        Redlight.GetComponent<Light>().enabled = true;

    }




    void Update()
    {
        if (targetCounter.ActivateTrigger == true)
        {
            Greenlight.GetComponent<Light>().enabled = true;
            Redlight.GetComponent<Light>().enabled = false;
        }
    }
}