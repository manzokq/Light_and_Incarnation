using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    // Start is called before the first frame update
    private GameObject pauseUIPrefab;
    private GameObject PauseUIInstance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q")){
            if(PauseUIInstance == null){
               PauseUIInstance = GameObject.Instantiate (pauseUIPrefab) as GameObject;
               Time.timeScale = 0f;
            }else{
               Destroy(PauseUIInstance);
               Time.timeScale = 1f;
            }
        }
    }
}
