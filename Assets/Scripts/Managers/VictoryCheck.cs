using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryCheck : MonoBehaviour
{

    public GameObject winningMessage;

    void Start()
    {
        winningMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            winningMessage.SetActive(true);
        }
    }
}
