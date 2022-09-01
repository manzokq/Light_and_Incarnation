using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaitenSwitch : MonoBehaviour
{

    
    //bool direction = true;
    [SerializeField]
    GameObject KaitenYuka;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            KaitenYuka.GetComponent<kaiten>().RoteStart();
        }
            /*
            if(collision.gameObject.CompareTag("Player")&&direction)
            {
                KaitenYuka.GetComponent<kaiten>().LeftRote();
                direction = false;
            }
            else if (collision.gameObject.CompareTag("Player") && !direction)
            {
                KaitenYuka.GetComponent<kaiten>().RightRote();
                direction = true;
            }*/
    }
}
