using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaihei : MonoBehaviour
{
    public int time;

    [SerializeField]
    int openTime = 10;
    bool ok = false;
    [SerializeField]
    private bool EVflag;
    private float floar;
    [SerializeField]
    private GameObject Ele;
    [SerializeField]
    float max = 0f;
    [SerializeField]
    float minimum = 0f;

    // Start is called before the first frame update
    void Start()
    {
        floar = 1f;
        EVflag = false;
    }

    // Update is called once per frame
    void Update()
    {

        //if (Ele.transform.position.y < 4f && floar == 1f && EVflag == true)
        //{
        //    Ele.transform.Translate(0, 1f * Time.deltaTime, 0);
        //
        //}
        //
        //
        //if (Ele.transform.position.y > 4f && floar == 2f && EVflag == true)
        //{
        //    Ele.transform.Translate(0, -1f * Time.deltaTime, 0);
        //}
    }
    private void OnTriggerEnter2D(Collider2D other)//エレベーターの中に入ったら
    {
        if (other.tag == "Player")
        {
            //ok = true;
            StartCoroutine(El());
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {/*
        if (Input.GetKeyDown(KeyCode.C) && ok)
        {
            StartCoroutine(El());
        }*/
    }
    private void OnTriggerExit2D(Collider2D other)//エレベーターから出たら
    {
        if (other.tag == "Player")
        {
            ok = false;
        }
    }

    IEnumerator El()
    {
        int times = 0;
        while (true)
        {
            if (times == time)
            {

                break;
            }
            else
            {
                Transform myTransform = Ele.transform;
                myTransform.Translate(new Vector3(0, 0.1f, 0));
                times++;
            }
            yield return new WaitForSeconds(0.001f);
        }
        yield return new WaitForSeconds(openTime);
        times = 0;
        while (true)
        {
            if (times == time)
            {

                break;
            }
            else
            {
                Transform myTransform = Ele.transform;
                myTransform.Translate(new Vector3(0, -0.1f, 0));
                times++;
            }
            yield return new WaitForSeconds(0.001f);
        }
        EVflag = false;
    }
}
