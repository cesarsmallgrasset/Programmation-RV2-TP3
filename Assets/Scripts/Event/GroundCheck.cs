using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    Rigidbody Player;
    internal bool isGrounded;
    private void Start()
    {
        Player = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision) { if (collision.gameObject.CompareTag("Ground")) {isGrounded = true;}}
    void OnCollisionExit(Collision collision) { if (collision.gameObject.CompareTag("Ground")) { isGrounded = false; }}

}
