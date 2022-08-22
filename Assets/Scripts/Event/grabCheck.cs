using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class grabCheck : MonoBehaviour
{
    [SerializeField] GameObject Shootreference, Ammopack;
    [SerializeField] AudioSource audioSource;
    Shoot shoot;
    private bool alreadyPlayed = false;



    void Awake()
    {
        shoot = Shootreference.GetComponent<Shoot>();
       
    }

    private void Update()
    {
        shoot.isGrabbed = true;
        if (!alreadyPlayed)
        {
            audioSource.Play();
            alreadyPlayed = true;
        }
        Destroy(Ammopack, 2f);
    }
}
