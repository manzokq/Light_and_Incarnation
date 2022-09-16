using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaitenScript : MonoBehaviour
{
    /*
    [SerializeField]
    private SwitchR _switchrigth;
    [SerializeField]
    private SwitchL _switchleft;
    */
    [SerializeField]
    bool direction = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (_switchrigth.kidourigth)
        //{
        //    _switchrigth.kidourigth = false;
        //    StartCoroutine(Rigth());
        //}
        //if (_switchleft.kidouleft)
        //{
        //    _switchleft.kidouleft = false;
        //    StartCoroutine(Left());
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public void RoteStart()
    {
        if (direction)
        {
            LeftRote();
            direction = false;
        }
        else if (!direction)
        {
            RightRote();
            direction = true;
        }
    }

    public void RightRote()
    {
        StartCoroutine(Right());
    }

    public void LeftRote()
    {
        StartCoroutine(Left());
    }

    IEnumerator Right()
    {
        int time = 0;
        while (true)
        {
            if (time == 90)
            {

                break;
            }
            else
            {
                Transform myTransform = this.transform;
                myTransform.Rotate(new Vector3(0, 0, 1));
                time++;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator Left()
    {
        int time = 0;
        while (true)
        {
            if (time == 90)
            {

                break;
            }
            else
            {
                Transform myTransform = this.transform;
                myTransform.Rotate(new Vector3(0, 0, -1));
                time++;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

}
