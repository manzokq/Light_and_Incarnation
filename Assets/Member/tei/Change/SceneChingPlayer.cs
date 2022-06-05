using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChingPlayer : MonoBehaviour
{
    //入ったゲートを記憶する
    public static int Gate_Number = 0;
    //プレーヤーが増殖しないように
    public static SceneChingPlayer Instance
    {
        get;
        private set;
    }
    private void Awake()//Start前に処理
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
        //tpの値をリセット
        Gate_Number = 0;
        //tp = tpps.gate_Player();
    }

    //シーン切り替え
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("S" + Gate_Number);
        //シーン遷移＆ゲート記憶
        //チュートリアルと１
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
        //2から3へ
        if (collision.gameObject.name == ("Gate3"))
        {
            Gate_Number = 3;

            
            SceneManager.LoadScene("MapBoss");
        }
        //3から1へ
        if (collision.gameObject.name == ("Gate4"))
        {
           
            Gate_Number = 4;
            SceneManager.LoadScene("tei_tesuto_1");
        }
        //1から3へ
        if (collision.gameObject.name == ("Gate5"))
        {
            
            Gate_Number = 5;
            SceneManager.LoadScene("tei_tesuto_3");
        }
    }
    //記憶した数値をゲートに渡す
    public static int Player_gate()
    {
        return Gate_Number;
    }

    void OnSceneLoad(Scene scene,LoadSceneMode mode)
    {


        if(Gate_Number!=0)
        {
            Debug.Log("シーン繊維");

            this.gameObject.transform.position = new Vector3(
                GameObject.Find("Gate" + Gate_Number).transform.position.x + 2,
                GameObject.Find("Gate" + Gate_Number).transform.position.y,
                GameObject.Find("Gate" + Gate_Number).transform.position.z);
        }          
        
    }


}
