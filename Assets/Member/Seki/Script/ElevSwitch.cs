using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevSwitch : MonoBehaviour
{

    bool playerFrag = false;

    [SerializeField]
    GameObject EleObj;

    [SerializeField]
    Sprite[] _switchImage=null;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("joystick button 1"))
        {
            //Debug.Log(playerFrag);
            if(playerFrag == true)
            {
                EleObj.GetComponent<Elevator>().eleSwitch = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = _switchImage[1];
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerFrag = true;
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerFrag = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerFrag = false;
        }
    }

}
