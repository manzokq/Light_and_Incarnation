using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flour : MonoBehaviour
{
    [SerializeField,Header("色ID")]
    int ID;

    [SerializeField,Header("色")]
    Color[] color;

    [SerializeField, Header("オーブを生産数")]
    public int Orb_count;

    public bool touch = false;

    [SerializeField, Header("復活時間")]
    float ResponTime = 0;

    float TimeCount = 0;

    private void Update()
    {
        if (!touch)
        {
            //スイッチで色変える
            GetComponent<SpriteRenderer>().color = color[ID];
        }
        else if (touch)
        {
            GetComponent<SpriteRenderer>().color = color[1];
            Respon();
        }
    }

    void Respon()
    {

        TimeCount += Time.deltaTime;
        if(TimeCount >= ResponTime)
        {
            touch = false;
            TimeCount = 0;
        }
    }



}

//R,B,Gは色数値、aは透明度で0から1まで指定する.

