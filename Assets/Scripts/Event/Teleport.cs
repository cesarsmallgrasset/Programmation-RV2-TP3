using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform Destination, Destination2;
    [SerializeField] private new AudioSource audio;
    private Transform teleport;
    [SerializeField] private bool canTeleport;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (canTeleport)
            {
                Debug.Log("Teleport1");
                other.transform.position = Destination.transform.position;
                audio.Play();
                canTeleport = false;
            }
            if (!canTeleport)
            {
                Debug.Log("Teleport2");
                Destination.transform.position = Destination2.transform.position;
                audio.Play();
                canTeleport = true;
            }
        }
    }
}

  