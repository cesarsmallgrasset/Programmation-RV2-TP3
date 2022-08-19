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
    [SerializeField] float speed;
    [SerializeField] float DoorDestroy;


    void Awake()
    {
        targetCounter = HolderReference.GetComponent<TargetCounter>();
    }



    void Update()
    {
        if (targetCounter.ActivateTrigger == true)
        {

            //Si les cibles ont tous ete atteintes, la porte ouvrent et jouent un son
            transform.Translate(Vector3.left * speed * Time.deltaTime);

           
            if (!alreadyPlayed) {
            audioSource.Play();
                alreadyPlayed = true;
            }

            //La porte se detruit apres x secondes
            Destroy(this.gameObject, DoorDestroy);
        }
    } 
}
