using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hasi : MonoBehaviour
{
    [SerializeField]
    private GameObject hasi;

    bool hs = true;

    [SerializeField]
    private int rotate = 0;

    public int _StartAxis,_RotateAxis = 0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.transform.localEulerAngles);
            //Mathf.Abs(this.gameObject.transform.rotation.z));
        _StartAxis = Mathf.Abs((int)gameObject.transform.localEulerAngles.z);
        _RotateAxis = rotate- _StartAxis ;
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

        if(Input.GetKeyDown(KeyCode.A))
        {
            if(hs)StartCoroutine(stop());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hs && collision.gameObject.CompareTag("Arrow"))
        {
            StartCoroutine(stop());
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hs&&collision.gameObject.CompareTag("Arrow"))
        {
            StartCoroutine(stop());
        }
    }

    IEnumerator stop()
    {
        hs = false;
        float T=0;
        while(T < 2)
        {
           
            hasi.transform.Rotate(new Vector3(0, 0, _RotateAxis * Time.deltaTime/2));
            T += Time.deltaTime;
            yield return null;
        }

        hasi.transform.rotation = Quaternion.Euler(0, 0, rotate);
    }
}
