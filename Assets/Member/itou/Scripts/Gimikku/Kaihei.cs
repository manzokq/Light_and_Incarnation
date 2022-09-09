using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Kaihei : MonoBehaviour
{
    public int time;
    bool ok = true;
    [SerializeField]
    private bool EVflag;
    private float floar;
    [SerializeField]
    private GameObject Ele;
    [SerializeField]
    float max = 0f;
    [SerializeField]
    float minimum = 0f;
    public Sprite doaon;
    public Sprite doaoff;
    SpriteRenderer doasprite;

    // Start is called before the first frame update
    void Start()
    {
        doasprite = gameObject.GetComponent<SpriteRenderer>();
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
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.C) && ok)
        {
            doasprite.sprite = doaon;
            StartCoroutine(El());
            ok = false;
        }
    }
    IEnumerator El()
    {
        int times = 0;
        while (times < time)
        {
            Transform myTransform = Ele.transform;
            myTransform.Translate(new Vector3(0, 0.1f, 0));
            times++;
            yield return new WaitForSeconds(0.001f);
        }
        yield return new WaitForSeconds(5);
        times = 0;
        while (times < time)
        {
            Transform myTransform = Ele.transform;
            myTransform.Translate(new Vector3(0, -0.1f, 0));
            times++;
            yield return new WaitForSeconds(0.001f);
        }
        EVflag = false;
        ok = true;
        doasprite.sprite = doaoff;
    }
}
