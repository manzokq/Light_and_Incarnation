using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    BoxCollider2D box;
    private bool EVflag;
    private float floar;
    [SerializeField]
    private GameObject EleObj;
    [SerializeField]
    private GameObject torch;
    [SerializeField]
    float max = 0f;
    [SerializeField]
    float minimum = 0f;

    [SerializeField]
    float noboruSpeed = 1;
    bool playerON = false;
    Vector3 ElePos=new Vector3(0,0,0);
    float firstY = 0;
    public bool eleSwitch=false;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        floar = 1f;

        EVflag = false;
        ElePos = EleObj.transform.position;
        firstY = EleObj.transform.position.y;
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

        if(Input.GetKeyDown(KeyCode.A))
        {
            playerON = true;
            StartCoroutine(Noboru());
        }

    }
    private void OnTriggerEnter2D(Collider2D other)//エレベーターの中に入ったら
    {
        /*
        if (torch.GetComponent<torcha>().flag == true && other.tag == "Player")
        {
            box.size = new Vector3(2,2);
            EVflag = true;
            StartCoroutine(El());
        }
        */
        if(other.gameObject.CompareTag("Player")&&eleSwitch)
        {
            playerON = true;
            StartCoroutine(Noboru());
        }

    }
    private void OnTriggerExit2D(Collider2D other)//エレベーターから出たら
    {/*
        if (floar == 1f && EVflag == true && other.tag == "Player")
        {
            box.size = new Vector3(1,1);
            floar = 2f;
            EVflag = false;
        }
        if (floar == 2f && EVflag == true && other.tag == "Player")
        {
            box.size = new Vector3(1,1);
            floar = 1f;
            EVflag = false;
        }*/

        if(other.gameObject.CompareTag("Player"))
        {
            playerON = false;
            StartCoroutine(Oriru());
        }
    }

    IEnumerator Noboru()
    {
        while(playerON)
        {
            //ElePos.y += 1 * Time.deltaTime;
            EleObj.transform.Translate(0, noboruSpeed * Time.deltaTime, 0);
            yield return null;
        }
        
    }
    IEnumerator Oriru()
    {

        while (!playerON)
        {
            if (firstY >= EleObj.transform.position.y)
            {
                break;
            }

            //ElePos.y += 1 * Time.deltaTime;
            EleObj.transform.Translate(0, -noboruSpeed * Time.deltaTime, 0);
            yield return null;
        }
        
    }




    IEnumerator El()
    {
        while (EVflag)
        {
            if (EleObj.transform.position.y < max && floar == 1f && EVflag == true)
            {
                EleObj.transform.Translate(0, 1f * Time.deltaTime, 0);

            }
            if (EleObj.transform.position.y > minimum && floar == 2f && EVflag == true)
            {
                EleObj.transform.Translate(0, -1f * Time.deltaTime, 0);
            }
            yield return null;
        }
    }
}