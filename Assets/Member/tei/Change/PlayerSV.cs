using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSV : MonoBehaviour
{
    public static int tp = 0;
    //�v���[���[�����B���Ȃ��悤��
    public static PlayerSV Instance
    {
        get;
        private set;
    }
    //Start�O�ɏ���
    private void Awake()
    {
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
        tp = tpps.tps2();
    }

    //�V�[���؂�ւ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("S" + tp);
        //�V�[���J��
        //1����2��
        if (collision.gameObject.name == ("Gate1"))
        {
            tp = 1;
            SceneManager.LoadScene("tei_tesuto_2");
            //this.transform.position = new Vector3(2, 3, 1);
        }
        //2����1��
        if (collision.gameObject.name == ("Gate2"))
        {
            tp = 2;
            SceneManager.LoadScene("tei_tesuto_1");
        }
        //2����3��
        if (collision.gameObject.name == ("Gate3"))
        {
            tp = 3;
            SceneManager.LoadScene("tei_tesuto_3");
        }
        //3����1��
        if (collision.gameObject.name == ("Gate4"))
        {
            tp = 4;
            SceneManager.LoadScene("tei_tesuto_1");
        }
        //1����3��
        if (collision.gameObject.name == ("Gate5"))
        {
            tp = 5;
            SceneManager.LoadScene("tei_tesuto_3");
        }
    }
    public static int tps1()
    {
        return tp;
    }
}
