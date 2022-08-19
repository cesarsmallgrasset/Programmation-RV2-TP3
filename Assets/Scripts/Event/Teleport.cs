using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public Transform Receiver;
    public GameObject Player;

    [SerializeField] AudioSource audioSource;



        private void OnCollisionEnter(Collision collision)
    {
        //Teleporte le joueur a la location du GameObject associee et fait jouer un son
        if (collision.gameObject.CompareTag("Player")) {Player.transform.position = Receiver.position;}
        audioSource.Play();
    }
}
