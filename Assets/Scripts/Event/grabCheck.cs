using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class grabCheck : MonoBehaviour
{
    [SerializeField] GameObject Shootreference, Ammopack;
    [SerializeField] AudioSource audioSource;
    CustomPlayerController shoot;
    private bool alreadyPlayed = false;
    void Awake()
    {
        shoot = Shootreference.GetComponent<CustomPlayerController>();
       
    }
    private void Update()
    {
        shoot.cannonIsGrabbed = true;
        if (!alreadyPlayed)
        {
            audioSource.Play();
            alreadyPlayed = true;
        }
        Destroy(Ammopack, 2f);
    }
}
