using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public  class StatChange : MonoBehaviour 
{
    int num = 0;
    [SerializeField]
    private List<Sprite> playerTex = new List<Sprite>();

    [SerializeField]
    private GameObject direc;

    bool ltFrag=true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float tri = Input.GetAxis("L_R_Trigger");
        if(tri <0&&ltFrag)
        {
            ltFrag = false;
            Debug.Log("âüÇ≥ÇÍÇΩ");

            num++;

            if (Enum.IsDefined(typeof(States), num))
            {
                //Debug.Log("aaaaa");

            }
            else
            {
                num = 0;
            }

            GetComponent<SpriteRenderer>().sprite = playerTex[num];
        }
        else if(tri ==0)
        {
            ltFrag=true;   
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
           
            
        }/*
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
            
        }*/

        /*
        if(Input.GetKeyDown(KeyCode.JoystickButton11))
        {
          
        }
        float LT = Input.GetAxis("LT");
        if (LT != 0.0f)
        {
            Debug.Log("ÉgÉäÉKÅ[");
        }
        */

            
            if(tri != 0.0f)
            {
                //Debug.Log(LT);

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

            Debug.Log(radian);
            radian -= 90;
                //

                //var direction = new Vector2(Horizontal,Vertical);

                direc.transform.localRotation = Quaternion.Euler(0,0,radian);
                radian += 90;
                radian /= 90;
                //Debug.Log((int)radian);
                /*
                switch ((States)Enum.ToObject(typeof(States), (int)radian))
                {
                    case States.Girl:
                        Debug.Log("è≠èóÇÃèàóù");
                        break;

                    case States.SwordMan:
                        Debug.Log("åïémÇÃèàóù");
                        break;

                    case States.Archer:
                        Debug.Log("ã|égÇ¢ÇÃèàóù");
                        break;

                    case States.Wizard:
                        Debug.Log("ñÇñ@égÇ¢ÇÃèàóù");
                        break;

                    default:
                        break;
                }*/
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                switch((States)Enum.ToObject(typeof(States),num))
                {
                   case States.Girl:
                       Debug.Log("è≠èóÇÃèàóù");
                       break;

                   case States.SwordMan:
                       Debug.Log("åïémÇÃèàóù");
                       break;

                   case States.Archer:
                       Debug.Log("ã|égÇ¢ÇÃèàóù");
                       break;

                   case States.Wizard:
                       Debug.Log("ñÇñ@égÇ¢ÇÃèàóù");
                       break;

                   default:
                       
                       break;
                }
            }
    }



    
  


}
