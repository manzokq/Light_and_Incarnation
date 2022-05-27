using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public  class StatChange : MonoBehaviour 
{
    int num = 0;
    [SerializeField]
    private GameObject direc;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            num++;

            if(Enum.IsDefined(typeof(States),num))
            {
                //Debug.Log("aaaaa");
                
            }
            else
            {
                num = 0;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            num--;

            if (Enum.IsDefined(typeof(States), num))
            {


            }
            else
            {
                num = 3;
            }
            
        }
        float LT = Input.GetAxis("LT");

        if(LT != 0.0f)
        {
            Debug.Log(LT);

            float Horizontal = Input.GetAxis("HorizontalKey");
            if (Horizontal < 0.0f)
            {
               
               
                //Horizontal = 3 - Horizontal;
                //Debug.Log(Horizontal);
            }
            else if (Horizontal > 0.0f)
            {
                //Horizontal = 1 + Horizontal;
            }

            float Vertical = Input.GetAxis("VerticalKey");
            if (Vertical < 0.0f)
            {
                //Vertical = 2 - Vertical;
                //Debug.Log(Vertical);
            }
            else if (Vertical > 0.0f)
            {

            }

            float radian = Mathf.Atan2(Vertical, Horizontal) * Mathf.Rad2Deg;

            if (radian < 0)
            {
                radian += 360;
            }
            radian -= 90;
            //Debug.Log(radian);

            //var direction = new Vector2(Horizontal,Vertical);

            direc.transform.localRotation = Quaternion.Euler(0,0,radian);
            radian += 90;
            radian /= 90;
            //Debug.Log((int)radian);
            switch ((States)Enum.ToObject(typeof(States), (int)radian))
            {
                case States.Girl:
                    Debug.Log("­—‚Ìˆ—");
                    break;

                case States.SwordMan:
                    Debug.Log("Œ•Žm‚Ìˆ—");
                    break;

                case States.Archer:
                    Debug.Log("‹|Žg‚¢‚Ìˆ—");
                    break;

                case States.Wizard:
                    Debug.Log("–‚–@Žg‚¢‚Ìˆ—");
                    break;

                default:
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch((States)Enum.ToObject(typeof(States),num))
            {
                case States.Girl:
                    Debug.Log("­—‚Ìˆ—");
                    break;

                case States.SwordMan:
                    Debug.Log("Œ•Žm‚Ìˆ—");
                    break;

                case States.Archer:
                    Debug.Log("‹|Žg‚¢‚Ìˆ—");
                    break;

                case States.Wizard:
                    Debug.Log("–‚–@Žg‚¢‚Ìˆ—");
                    break;

                default:
                    
                    break;
            }
        }
    }



    
  


}
