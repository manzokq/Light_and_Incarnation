using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChingPlayer : MonoBehaviour
{
    //�������Q�[�g���L������
    public static int Gate_Number = 0;
    //�v���[���[�����B���Ȃ��悤��
    public static SceneChingPlayer Instance
    {
        get;
        private set;
    }
    private void Awake()//Start�O�ɏ���
    {
        SceneManager.sceneLoaded += OnSceneLoad;


        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //tp�̒l�����Z�b�g
        Gate_Number = 0;
        //tp = tpps.gate_Player();
    }

    //�V�[���؂�ւ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("S" + Gate_Number);
        //�V�[���J�ځ��Q�[�g�L��
        //�`���[�g���A���ƂP
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
        }
    }
    //�L���������l���Q�[�g�ɓn��
    public static int Player_gate()
    {
        return Gate_Number;
    }

    void OnSceneLoad(Scene scene,LoadSceneMode mode)
    {


        if(Gate_Number!=0)
        {
            Debug.Log("�V�[���@��");

            this.gameObject.transform.position = new Vector3(
                GameObject.Find("Gate" + Gate_Number).transform.position.x + 2,
                GameObject.Find("Gate" + Gate_Number).transform.position.y,
                GameObject.Find("Gate" + Gate_Number).transform.position.z);
        }          
        
    }


}
