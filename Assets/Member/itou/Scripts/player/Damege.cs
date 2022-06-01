using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damege : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") == true){
            other.GetComponent<HP>().Damage(8);
        }
        Debug.Log("Player entered!");
    }
}
