using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    [SerializeField]
    GameObject doorObj;

    bool playerFrag = false;

    bool moveFrag = true;
    [SerializeField]
    int upY,waitTime,upTime = 0;

    Vector3 startVec = new Vector3(0, 0, 0);


    [SerializeField]
    Sprite[] _switchImage = null;
    // Start is called before the first frame update
    void Start()
    {
        startVec = doorObj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 1"))
        {
            if (playerFrag == true)
            {
                if(moveFrag)
                {
                    StartCoroutine(Move());
                }
            }
        }
    }
    IEnumerator Move()
    {

        moveFrag = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = _switchImage[1];
        //スイッチの画像切り替え

        float time = 0;
        while(time<upTime)
        {//ドアがupTimeの時間をかけて上昇
            doorObj.transform.Translate(0,  (upY*Time.deltaTime)/upTime, 0);
            yield return null;
            time += Time.deltaTime;
        }
        doorObj.transform.position = new Vector3(startVec.x, startVec.y+upY, startVec.z);//ズレ防止

        yield return new WaitForSeconds(waitTime);//ドア開放時間

        time = 0;
        while (time < 1)
        {//ドア下降
            doorObj.transform.Translate(0, (-upY * Time.deltaTime)/upTime, 0);
            yield return null;
            time += Time.deltaTime;
        }
        doorObj.transform.position=startVec;
        moveFrag = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = _switchImage[0];
        //画像戻し

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerFrag = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerFrag = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerFrag = false;
        }
    }
}
