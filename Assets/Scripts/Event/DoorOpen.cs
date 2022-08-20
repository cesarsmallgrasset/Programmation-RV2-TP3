using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    //Reference au TargetCounter
    [SerializeField] GameObject HolderReference;
    TargetCounter targetCounter;



    //Audio
    [SerializeField] AudioSource audioSource;
    //Code pour faire jouer le son une seul fois
    private bool alreadyPlayed = false;


    //Vitesses de destruction et de la translation de la porte
   
    


    //Animator
    [SerializeField] private Animator DoorAnim;

    void Awake()
    {
        targetCounter = HolderReference.GetComponent<TargetCounter>();
    }



    void Update()
    {
        if (targetCounter.ActivateTrigger == true)
        {


            
            DoorAnim.SetBool("isOpening", true);
           
            if (!alreadyPlayed) {
            audioSource.Play();
                alreadyPlayed = true;
            }
        }
    } 
}
