using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cleartext : MonoBehaviour
{
    public Text text;
    public bool _push=false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cleartx());
    }
    private void Update()
    {
         if(Input.GetKey(KeyCode.Space)|| Input.GetKeyDown("joystick button 1") || _push)
        {
            _push = false;
            SceneManager.LoadScene("MapTutorial");
        }
    }
    IEnumerator cleartx()
    {
        yield return new WaitForSeconds(0.5f);
        float _timeColor=0; 
        for (int i = 0; i < 100; i++)
        {
           // Debug.Log(_timeColor);
            
            _timeColor+=0.01f;
            yield return new WaitForSeconds(0.01f);
            text.color =  new Color(255, 255, 255,_timeColor);
        }
        //Debug.Log("’†ŠÔ");
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 100; i++)
        {
           // Debug.Log(_timeColor);
            _timeColor-=0.01f;
            yield return new WaitForSeconds(0.01f);
            text.color = new Color(255, 255, 255, _timeColor);
        }
        StartCoroutine(cleartx());
    }
}
