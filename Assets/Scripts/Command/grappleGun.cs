using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class grappleGun : MonoBehaviour
{
    //Grapple references
    [SerializeField] private InputActionReference grappleReference;
    [SerializeField] private InputActionReference grappleOutReference;
    

    //Player
    [SerializeField] private GameObject Player; 
    private Transform playerTransform;


    //Bullet and Barrel references
    [SerializeField] private GameObject Bullet, Barrel;

    //Instances of the shots
    grappleShot _grappleShot;
    private bool Shot;

    //Bullet rigidbody
    private Rigidbody Bulletrb;

    //Springjoint variables
    SpringJoint springJoint;
    [SerializeField] private float BulletSpeed = 5f, MinDistance = 0.1f, MaxDistance = 0.9f, Damper = 100f, Spring = 300f;


    private void Start()
    {
        //References
        grappleReference.action.performed += OnGrappleEnter;
        grappleOutReference.action.performed += OnGrappleExit;
        _grappleShot = Bullet.GetComponent<grappleShot>();

        //Bullet Rigidbody
        Bulletrb = Bullet.GetComponent<Rigidbody>();

        //Player
        playerTransform = Player.transform;

    }

    private void Update()
    {
        Bullet.transform.forward = Barrel.transform.forward;
        if (!Shot)
        {
            Bullet.transform.position = Barrel.transform.position;
            
        }
    }

    void OnGrappleEnter(InputAction.CallbackContext obj)
    {
        Shot = true;
        Debug.Log("In");


        Bullet.transform.position = Barrel.transform.position;

        Bulletrb.velocity = Barrel.transform.forward * BulletSpeed;
    }

    void OnGrappleExit(InputAction.CallbackContext obj2)
    {
        Shot = false;
        Debug.Log("Out" + Shot);
        Destroy(springJoint);
    }
    internal void Swing()
    {
        Debug.Log("Swing");
        springJoint = Player.AddComponent<SpringJoint>();
        springJoint.connectedBody = _grappleShot.collisionObject.GetComponent<Rigidbody>();
        springJoint.autoConfigureConnectedAnchor = false;
        springJoint.connectedAnchor = Vector3.zero;
        springJoint.anchor = Vector3.zero;

        float disJointToPlayer = Vector3.Distance(playerTransform.position, Bullet.transform.position);
        springJoint.maxDistance = disJointToPlayer * MaxDistance;
        springJoint.minDistance = disJointToPlayer * MinDistance;

        springJoint.damper = Damper;
        springJoint.spring = Spring;
    }

}
