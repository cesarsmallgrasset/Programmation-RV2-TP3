using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform Destination;

    [SerializeField] private new AudioSource audio;

    private bool isPlayed = false;
    private bool CountdownEnabled = false;
   
    [SerializeField] private float CountdownTimer;
    private float Timer, time;



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (CountdownEnabled == false) {
                other.transform.position = Destination.transform.position;
                other.transform.rotation = Destination.transform.rotation;
                audio.Play();
                CountdownEnabled = true;
            }
        }
    }

    void Counter()
    {

        if(CountdownEnabled == true)
        {
            
            Timer = CountdownTimer;
            Timer -= Time.deltaTime;
            Debug.Log("Timer: " + Timer);
            if(Timer == 0)
            {
                CountdownEnabled = false;
            }
        }

    }
}
