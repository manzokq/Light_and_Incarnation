using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSearch : MonoBehaviour
{
    private GameObject searchObject;
    private bool searcher = true;
    [HideInInspector]public bool Search = true;

    private void Start()
    {
        searchObject = this.gameObject;   
    }

    private void Update()
    {
        Search = searcher;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            searcher = false;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            searcher = true;
        }
    }
}
