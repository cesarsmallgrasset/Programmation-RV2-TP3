using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Shoot : MonoBehaviour
{

    internal bool cannonIsGrabbed = false;


    //Fait reference au action map pour la gachette ("Shoot")
    [SerializeField] private InputActionReference shootReference;




    //Tous les items en liens avec le tir de la balle
    [SerializeField]
    private GameObject CannonBullet, CannonBarrel;
    [SerializeField] AudioSource cannonAudioSource;


   

    private void Start()
    {
        //fait appel au action map "Shoot" et le stock dans cette variable
        shootReference.action.performed += OnShoot;
    }



    void OnShoot(InputAction.CallbackContext obj) {

        if (cannonIsGrabbed)
        {
            
            //Spawn la balle et fait jouer le son appropriee
            Instantiate(CannonBullet, CannonBarrel.transform.position, CannonBarrel.transform.rotation);
            cannonAudioSource.Play();
        }
        else
        {
            Debug.Log("No bullets");

        }
    }
}
