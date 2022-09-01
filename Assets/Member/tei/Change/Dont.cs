using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Dont : MonoBehaviour
{
    // Start is called before the first frame update
    public static Dont instance = null;

    //Canvas canvas;
    

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        //else if (SceneManager.GetActiveScene().name == "GameClear" ||
        //        SceneManager.GetActiveScene().name == "GameOP" ||
        //        SceneManager.GetActiveScene().name == "GameOver")
        //{
        //    Destroy(this.gameObject);
        //}
        else
        {
            Destroy(this.gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;


        //canvas = GetComponent<Canvas>().renderMode.;

    }
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        if (SceneManager.GetActiveScene().name == "GameClear" ||
                SceneManager.GetActiveScene().name == "GameOP" ||
                SceneManager.GetActiveScene().name == "GameOver")
        {
           
            //Destroy(this.gameObject);
        }
        switch (SceneManager.GetActiveScene().name)
        {
            case "GameOP":
                BGMManager.Instance.Sound(BGMManager.SoundState.Stop);
                BGMManager.Instance.Sound(BGMManager.SoundState.Sound0);
                Destroy(this.gameObject);
                break;
            case "MapTutorial":
                BGMManager.Instance.Sound(BGMManager.SoundState.Stop);
                BGMManager.Instance.Sound(BGMManager.SoundState.Sound1);
                break;
            case "Map1":
                BGMManager.Instance.Sound(BGMManager.SoundState.Stop);
                BGMManager.Instance.Sound(BGMManager.SoundState.Sound1);
                break;
            case "Map2":
                BGMManager.Instance.Sound(BGMManager.SoundState.Stop);
                BGMManager.Instance.Sound(BGMManager.SoundState.Sound1);
                break;
            case "MapIkidomari":
                BGMManager.Instance.Sound(BGMManager.SoundState.Stop);
                BGMManager.Instance.Sound(BGMManager.SoundState.Sound1);
                break;
            case "MapBoss":
                BGMManager.Instance.Sound(BGMManager.SoundState.Stop);
                BGMManager.Instance.Sound(BGMManager.SoundState.Sound2);
                break;
            case "GameClear":
                BGMManager.Instance.Sound(BGMManager.SoundState.Stop);
                BGMManager.Instance.Sound(BGMManager.SoundState.Sound0);
                Destroy(this.gameObject);
                break;
            case "GameOver":
                BGMManager.Instance.Sound(BGMManager.SoundState.Stop);
                BGMManager.Instance.Sound(BGMManager.SoundState.Sound3);

                Debug.Log("è¡Ç¶ÇÈÇ◊Ç´");
                Destroy(this.gameObject);
                break;
        }
    }


}
