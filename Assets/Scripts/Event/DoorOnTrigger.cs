using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Animator animator;

    //Audio
    [SerializeField] AudioSource audioSource;
    //Code pour faire jouer le son une seul fois
    private bool alreadyPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("isOpening", true);

            if (!alreadyPlayed)
            {
                audioSource.Play();
                alreadyPlayed = true;
            }
        }
    }
}
