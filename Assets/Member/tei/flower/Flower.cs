using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flour : MonoBehaviour
{
    [SerializeField,Header("�FID")]
    int ID;

    [SerializeField,Header("�F")]
    Color[] color;

    [SerializeField, Header("�I�[�u�𐶎Y��")]
    public int Orb_count;

    public bool touch = false;

    [SerializeField, Header("��������")]
    float ResponTime = 0;

    float TimeCount = 0;

    private void Update()
    {
        if (!touch)
        {
            //�X�C�b�`�ŐF�ς���
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

//R,B,G�͐F���l�Aa�͓����x��0����1�܂Ŏw�肷��.

