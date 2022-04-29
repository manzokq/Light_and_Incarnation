using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damege : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") == true){
            other.GetComponent<HP>().Damage();
        }
        Debug.Log("Player entered!");
    }
}
