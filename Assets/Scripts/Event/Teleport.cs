using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform firstDestination, secondDestination;
    [SerializeField] private new AudioSource audio;

    internal bool _firstDestination = true, _secondDestination = false;
   


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (_firstDestination)
            {
                other.transform.position = firstDestination.transform.position;
                other.transform.rotation = firstDestination.transform.rotation;
                audio.Play();
                _firstDestination = false;
                _secondDestination = true;
            }
            else if (_secondDestination)
            {

                _firstDestination = true;
                _secondDestination = false;

                other.transform.position = secondDestination.transform.position;
                other.transform.rotation = secondDestination.transform.rotation;

            }
        }
    }
}

  