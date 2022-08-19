using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class grappleShot : MonoBehaviour
{
    //Parameters
    [SerializeField] private InputActionReference grappleOutReference;
    internal GameObject collisionObject;



    //Joint related
    FixedJoint joint;
    grappleGun _grappleGun;
    [SerializeField] GameObject grappleGunReference;

    private void Start()
    {
        grappleOutReference.action.performed += OnGrappleExit;
        _grappleGun = grappleGunReference.GetComponent<grappleGun>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Grappleable")
        {
            collisionObject = collision.gameObject;
            joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = collisionObject.GetComponent<Rigidbody>();

            _grappleGun.Swing();
        }
    }


    void OnGrappleExit(InputAction.CallbackContext obj2)
    {
        Debug.Log("Destroying Joint");
        Destroy(joint);
    }

}
