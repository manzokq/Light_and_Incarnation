using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneChingPlayer : MonoBehaviour
{
    enum Gatenum
    {
        None = 0,
        Gate1,
        Gate2,
        Gate3,
        Gate4,
    }

    Gatenum gate;

    //�������Q�[�g���L������
    public static int Gate_Number = 0;

    [SerializeField]
    string getOut,comeIn;
    GameObject door;
    GameObject[] doors;

    int enterGatenum;

    //�v���[���[�����B���Ȃ��悤��
    public static SceneChingPlayer instance = null;

    private void Awake()//Start�O�ɏ���
    {
        SceneManager.sceneLoaded += OnSceneLoad;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            gate = Gatenum.None;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown("joystick button 3")||Input.GetKeyDown(KeyCode.I))
        {
            if(gate != Gatenum.None)
            {
                Change();
            }
            else
            {
                Debug.Log("�h�A��0����");
            }
            
        }
    }

    //�V�[���؂�ւ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("S" + Gate_Number);
        //�V�[���J�ځ��Q�[�g�L��
        //�`���[�g���A���ƂP
        if (collision.gameObject.tag=="Gate")
        {
            door = collision.gameObject;
            GetExit();
        }
        /*
        if (collision.gameObject.name == ("Gate1"))
        {
            
            Gate_Number = 1;
           
            if (SceneManager.GetActiveScene().name != "Map1")
            {
               
                SceneManager.LoadScene("Map1");
            }
            else
            {
                
                SceneManager.LoadScene("MapTutorial");
            }
            
        }
        //
        if (collision.gameObject.name == ("Gate2"))
        {
            Gate_Number = 2;
            if (SceneManager.GetActiveScene().name != "Map1")
            {
               
                SceneManager.LoadScene("Map1");
            }
            else
            {
                SceneManager.LoadScene("MapTutorial");
            }
        }
        //2����3��
        if (collision.gameObject.name == ("Gate3"))
        {
            Gate_Number = 3;

            
            SceneManager.LoadScene("MapBoss");
        }
        //3����1��
        if (collision.gameObject.name == ("Gate4"))
        {
           
            Gate_Number = 4;
            SceneManager.LoadScene("tei_tesuto_1");
        }
        //1����3��
        if (collision.gameObject.name == ("Gate5"))
        {
            
            Gate_Number = 5;
            SceneManager.LoadScene("tei_tesuto_3");
        }*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gate = Gatenum.None;
    }
    /*
    //�L���������l���Q�[�g�ɓn��
    public static int Player_gate()
    {
        return Gate_Number;
    }
    */
    void Change()
    {
        if (SceneManager.GetActiveScene().name != getOut)
        {
            SceneManager.LoadScene(getOut);
        }
        else
        {
            SceneManager.LoadScene(comeIn);
        }
        //���̃V�[������Ȃ����ɔ��
    }

    void GetExit()
    {
        if(door.GetComponent<Gate>()!=null)
        {
            getOut = door.GetComponent<Gate>().ReturnExit1();
            comeIn = door.GetComponent<Gate>().ReturnExit2();
            gate = (Gatenum)Enum.ToObject(typeof(Gatenum), door.GetComponent<Gate>().ReturnGatenum());
                
        }
        else
        {
            Debug.Log("Gate�X�N���v�g����������Ȃ�");
        }
        
    }
    void OnSceneLoad(Scene scene,LoadSceneMode mode)
    {


        doors = GameObject.FindGameObjectsWithTag("Gate");
        foreach(var obj in doors)
        {
            if((int)gate== obj.gameObject.GetComponent<Gate>().ReturnGatenum())
            {
                this.gameObject.transform.position = new Vector3(
                    obj.transform.position.x, 
                    obj.transform.position.y, 
                    obj.transform.position.z);
            }
        }

        gate = Gatenum.None;
        if (gate == Gatenum.None && GameObject.FindWithTag("target") != null)
        {
            var target = GameObject.FindWithTag("target");
            transform.position = target.gameObject.transform.position;
        }
        /*
        if(Gate_Number!=0)
        {
            Debug.Log("�V�[���J��");

            this.gameObject.transform.position = new Vector3(
                GameObject.Find("Gate" + Gate_Number).transform.position.x,
                GameObject.Find("Gate" + Gate_Number).transform.position.y,
                GameObject.Find("Gate" + Gate_Number).transform.position.z);
        }

        Gate_Number = 0;*/
    }


}
