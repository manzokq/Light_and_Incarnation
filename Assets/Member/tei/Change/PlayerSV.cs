using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSV : MonoBehaviour
{
    public GameObject Playe;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == ("Gate1-2"))
        {
            SceneManager.LoadScene("tei_tesuto_2");
            this.transform.position = new Vector3(0, 0, 1);
        }
        if (collision.gameObject.name == ("Gate2-1"))
        {
            SceneManager.LoadScene("tei_tesuto_1");
            this.transform.position = new Vector3(0, 0, 1);
        }

    }
}
