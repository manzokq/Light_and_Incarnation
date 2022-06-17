using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hasi : MonoBehaviour
{
    [SerializeField]
    private GameObject hasi;

    bool hs = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (hs)
        //{
        //    if(hasi.transform.rotation.z <= 80 || hasi.transform.rotation.z >= 0)
        //    {
        //        hasi.transform.Rotate(new Vector3(0, 0, 90f * Time.deltaTime));
        //        StartCoroutine(stop());
        //    }
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hs)
        {
            StartCoroutine(stop());
        }
    }

    IEnumerator stop()
    {
        float T=0;
        while(T<=1)
        { 

                hasi.transform.Rotate(new Vector3(0, 0, 88f * Time.deltaTime));
            yield return null;
            T+=Time.deltaTime;
        }
        hs = false;
    }
}
