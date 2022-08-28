using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class grappleShot : MonoBehaviour
{
    //Parameters
    [SerializeField] private InputActionReference grappleOutReference;
    internal GameObject collisionObject;
    Collider _collider;


    //Joint related
    FixedJoint joint;
    CustomPlayerController playercontroller;
    [SerializeField] GameObject PlayerReference;

    private void Start()
    {
        grappleOutReference.action.performed += OnGrappleExit;
        playercontroller = PlayerReference.GetComponent<CustomPlayerController>();
        _collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (playercontroller.Shot) {
            _collider.enabled = !_collider.enabled;
                }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Grappleable")
        {
            Debug.Log("Hooked");
            collisionObject = collision.gameObject;
            joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = collisionObject.GetComponent<Rigidbody>();

            playercontroller.Swing();
        }
    }


    void OnGrappleExit(InputAction.CallbackContext obj2)
    {
        Debug.Log("Destroying Joint");
        Destroy(joint);
    }

}
