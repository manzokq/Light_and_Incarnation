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
        if(instance ==null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
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
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            Destroy(this.gameObject);
        }
    }


}
