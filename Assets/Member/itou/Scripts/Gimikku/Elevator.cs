using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private bool EVflag;
    private float floar;
    [SerializeField]
    private GameObject Ele;
    [SerializeField]
    private GameObject torch;
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
        if (torch.GetComponent<torcha>().flag == true)
        {
            EVflag = true;
            StartCoroutine(El());
        }
        


    }
    private void OnTriggerExit2D(Collider2D other)//エレベーターから出たら
    {
        if (floar == 1f && EVflag == true)
        {
            floar = 2f;
            EVflag = false;
        }
        if (floar == 2f && EVflag == true)
        {
            floar = 1f;
            EVflag = false;
        }
    }

    IEnumerator El()
    {
        while (EVflag)
        {
            Debug.Log(floar);
            if (Ele.transform.position.y < max && floar == 1f && EVflag == true)
            {
                Ele.transform.Translate(0, 1f * Time.deltaTime, 0);

            }
            if (Ele.transform.position.y > minimum && floar == 2f && EVflag == true)
            {
                Ele.transform.Translate(0, -1f * Time.deltaTime, 0);
            }
            yield return null;
        }
    }
}