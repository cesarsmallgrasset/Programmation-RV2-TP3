using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform Destination;

    [SerializeField] private new AudioSource audio;

    
   


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
                other.transform.position = Destination.transform.position;
                other.transform.rotation = Destination.transform.rotation;
                audio.Play();
        }
    }
}

  