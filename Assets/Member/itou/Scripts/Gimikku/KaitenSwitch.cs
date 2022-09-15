using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaitenSwitch : MonoBehaviour
{

    
    //bool direction = true;
    [SerializeField]
    GameObject KaitenYuka;

    [SerializeField]
    Sprite[] _switchImage = null;

    bool playerFrag, kaitennF = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 1"))
        {
            Debug.Log(playerFrag);
            if (playerFrag == true)
            {
                KaitenYuka.GetComponent<kaiten>().RoteStart();
                if(kaitennF)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = _switchImage[0];
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = _switchImage[1];
                }
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
