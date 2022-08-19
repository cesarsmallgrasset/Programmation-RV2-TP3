using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCounter : MonoBehaviour
{
    //TargetsHit counter
    internal int Counter = 0;
    [SerializeField] int NbOfTargets;

    //Si tout les cibles sont atteintes,  = true
    internal bool ActivateTrigger;




    private void Update()
    {
        SequenceCheck();
        Debug.Log("Targets Hit: " + Counter);
    }




    void SequenceCheck()
    {
        if (Counter == NbOfTargets)
        {
            ActivateTrigger = true;
            Debug.Log("Number Of Targets Reached");
        }
    }
}
