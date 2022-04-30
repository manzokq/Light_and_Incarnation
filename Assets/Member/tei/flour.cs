using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flour : MonoBehaviour
{
    [SerializeField,Header("色ID")]
    int ID;

    [SerializeField,Header("色")]
    Color[] color;

    [SerializeField, Header("オーブ数")]
    public int Orb_count;

    public bool touch = false;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (!touch)
        {
            //スイッチで色変える
            GetComponent<SpriteRenderer>().color = color[ID];
        }
        else
        {
            GetComponent<SpriteRenderer>().color = color[0];
        }
    }


}

//R,B,Gは色数値、aは透明度で0から1まで指定する.

