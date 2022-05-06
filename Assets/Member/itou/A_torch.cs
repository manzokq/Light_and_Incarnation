using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class A_torch : MonoBehaviour
{
    private bool Atorch = false;
        void _Reset()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true){
            Atorch = true;
        }
    }
       void Update()
    {
        if(Atorch){
        Debug.Log("A");
        }
        Atorch = false;
    }
}