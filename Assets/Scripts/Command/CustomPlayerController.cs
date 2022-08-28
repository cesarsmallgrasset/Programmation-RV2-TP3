using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomPlayerController : MonoBehaviour
{

    //Action Map References
    [SerializeField] private InputActionReference shootReference, grappleOutReference, grappleReference, jumpReference;

    GroundCheck groundcheck;


    //Audio
    [SerializeField] private AudioSource cannonAudioSource;

    //Gameobjects
    [SerializeField] private GameObject Player, Bullet, Barrel, CannonBullet, CannonBarrel;
    private Transform playerTransform;
    private Rigidbody Bulletrb, PlayerRb;
    SpringJoint springJoint;
    grappleShot _grappleShot;

    //Variables
    [SerializeField] private float jumpForce = 500f, BulletSpeed = 5f, MinDistance = 0.1f, MaxDistance = 0.9f, Damper = 100f, Spring = 300f;
    internal bool Shot, cannonIsGrabbed = false;


    private void Start()
    {

        //fait appel au action map "Shoot" et le stock dans cette variable
        shootReference.action.performed += OnShoot;

        //Player
        groundcheck = Player.GetComponent<GroundCheck>();
        PlayerRb = Player.GetComponent<Rigidbody>();
        jumpReference.action.performed += OnJump;
        playerTransform = Player.transform;

        //ActionMap
        grappleReference.action.performed += OnGrappleEnter;
        grappleOutReference.action.performed += OnGrappleExit;

        //Bullet
        Bulletrb = Bullet.GetComponent<Rigidbody>();
        _grappleShot = Bullet.GetComponent<grappleShot>();

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

    void OnShoot(InputAction.CallbackContext obj)
    {

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



    private void OnJump(InputAction.CallbackContext obj)
    {
        Debug.Log("Jump");
        if (groundcheck.isGrounded)
        {
            Debug.Log("Grounded");
            PlayerRb.AddForce(Vector3.up * jumpForce);
        }
    }

}
