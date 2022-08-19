using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traffic : MonoBehaviour
{

    //Reference au TargetCounter
    [SerializeField] GameObject HolderReference;
    TargetCounter targetCounter;





    //Le renderer sert a aller modifier la couleur du feu / stop light
    [SerializeField] public Renderer renderer;


    void Awake()
    {
        targetCounter = HolderReference.GetComponent<TargetCounter>();
        renderer = GetComponent<Renderer>();
        renderer.material.color = Color.red;

    }



    void Update()
    {
        if (targetCounter.ActivateTrigger == true)
        {
            renderer.material.color = Color.green;
        }
    }
}
