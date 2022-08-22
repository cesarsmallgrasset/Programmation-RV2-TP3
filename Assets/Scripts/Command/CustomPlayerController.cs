using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomPlayerController : MonoBehaviour
{

    //Action Map References
    [SerializeField] private InputActionReference shootReference, grappleOutReference, grappleReference, jumpReference;

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
        internal bool isGrounded => Physics.Raycast( new Vector2(transform.position.x, transform.position.y + 2.5f), Vector3.down, 2.5f);


    private void Start()
    {
        PlayerRb = Player.GetComponent<Rigidbody>();
        jumpReference.action.performed += OnJump;


        //fait appel au action map "Shoot" et le stock dans cette variable
        shootReference.action.performed += OnShoot;


        //_________________________________________________
        //References
        grappleReference.action.performed += OnGrappleEnter;
        grappleOutReference.action.performed += OnGrappleExit;
        _grappleShot = Bullet.GetComponent<grappleShot>();

        //Bullet
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
        if (isGrounded)
        {
            PlayerRb.AddForce(Vector3.up * jumpForce);
        }
    }

}
