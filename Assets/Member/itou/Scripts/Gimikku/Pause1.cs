using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause1 : MonoBehaviour
{
    [SerializeField]
    // Start is called before the first frame update
    private GameObject pauseUIPrefab;
    private GameObject PauseUIInstance;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Button()
    {
       
           Destroy(PauseUIInstance);
           Time.timeScale = 1f;
    }
}