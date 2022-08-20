using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    
    [SerializeField]  private Transform RespawnPoint;
    



    private void OnTriggerEnter(Collider other)
    {
        //Teleportes le joueur a la location du GameObject associee
        if (other.CompareTag("Player")) { other.transform.position = RespawnPoint.position; }
    }
}
