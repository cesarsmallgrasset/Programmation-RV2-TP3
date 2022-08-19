using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class grabCheck : MonoBehaviour
{
    //reference to Shoot script
    [SerializeField] GameObject Bullet;
    Shoot shoot;


    //Input Reference
    [SerializeField] private InputActionReference selectReference;

    [SerializeField]AudioSource audio;
    [SerializeField] AudioClip audioClip;
    

    //to check if the player is in the area and grabbing the bullet pack
    bool grabbed = false;
    bool colliding = false;
    void Awake()
    {
        shoot = Bullet.GetComponent<Shoot>();
        selectReference.action.performed += OnSelect;
    }


    void Update()
    {
        if (grabbed && colliding)
        {
            shoot.isGrabbed = true;

            Destroy(this.gameObject, 1f);
        }

    }


    void OnSelect(InputAction.CallbackContext obj)
    {
        grabbed = true;
        if (colliding)
        {
            audio.Play();

        }
    }


    private void OnTriggerEnter(Collider collision)
    {
            colliding = true;
    }

}
