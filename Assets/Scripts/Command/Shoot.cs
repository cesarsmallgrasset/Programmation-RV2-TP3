using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Shoot : MonoBehaviour
{

    internal bool isGrabbed = false;


    //Fait reference au action map pour la gachette ("Shoot")
    [SerializeField] private InputActionReference shootReference;




    //Tous les items en liens avec le tir de la balle
    [SerializeField]
    private GameObject Bullet, Barrel;
    [SerializeField] AudioSource audioSource;


   

    private void Start()
    {
        //fait appel au action map "Shoot" et le stock dans cette variable
        shootReference.action.performed += OnShoot;
    }



    void OnShoot(InputAction.CallbackContext obj) {

        if (isGrabbed)
        {
            
            //Spawn la balle et fait jouer le son appropriee
            Instantiate(Bullet, Barrel.transform.position, Barrel.transform.rotation);
            audioSource.Play();
        }
        else
        {
            Debug.Log("No bullets");

        }
    }
}
