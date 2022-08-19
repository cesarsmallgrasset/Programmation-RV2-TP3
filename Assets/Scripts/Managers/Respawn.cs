using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    
    public Transform RespawnPoint;
    public GameObject Player;



    private void OnCollisionEnter(Collision collision)
    {
        //Teleportes le joueur a la location du GameObject associee
        if (collision.gameObject.CompareTag("Player")) { Player.transform.position = RespawnPoint.position; }
    }
}
