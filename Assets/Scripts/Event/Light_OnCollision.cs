using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_OnCollision : MonoBehaviour
{

    //Audio
    [SerializeField] AudioSource audioSource;

    //public GameObject lightTarget1;

    public Light lightTarget1;
    public Light lightTarget2;
    public Light lightTarget3;
    public Light lightTarget4;
   

    void Start()
    {
        lightTarget1.GetComponent<Light>().enabled = false;
        lightTarget2.GetComponent<Light>().enabled = false;
        lightTarget3.GetComponent<Light>().enabled = false;
        lightTarget4.GetComponent<Light>().enabled = false;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            lightTarget1.GetComponent<Light>().enabled = true;
            lightTarget2.GetComponent<Light>().enabled = true;
            lightTarget3.GetComponent<Light>().enabled = true;
            lightTarget4.GetComponent<Light>().enabled = true;

            audioSource.Play();

        }
    }
}
