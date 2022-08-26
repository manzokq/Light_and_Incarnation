using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaihei : MonoBehaviour
{
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
            ok = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.C) && ok)
        {
            EVflag = true;
            StartCoroutine(El());
        }
    }
    private void OnTriggerExit2D(Collider2D other)//エレベーターから出たら
    {
        if (floar == 1f && EVflag == true && other.tag == "Player")
        {
            floar = 2f;
            EVflag = false;
            ok = false;
        }
        if (floar == 2f && EVflag == true && other.tag == "Player")
        {
            floar = 1f;
            EVflag = false;
            ok=false;
        }
    }

    IEnumerator El()
    {
        while (EVflag)
        {
            if (Ele.transform.position.y < max && floar == 1f && EVflag == true)
            {
                Ele.transform.Translate(0, 1f * Time.deltaTime, 0);

            }
        }
        yield return new WaitForSeconds(10);
        while (EVflag)
        {
            if (floar == 2f)
            {
                if (Ele.transform.position.y > minimum && EVflag == true)
                {
                    Ele.transform.Translate(0, -1f * Time.deltaTime, 0);
                }
            }
        }
    }
}
