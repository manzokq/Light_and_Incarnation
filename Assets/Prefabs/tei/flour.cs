using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flour : MonoBehaviour
{
    [SerializeField,Header("�FID")]
    int ID;

    [SerializeField,Header("�F")]
    Color[] color;

    [SerializeField, Header("�I�[�u��")]
    public int Orb_count;

    public bool touch = false;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (!touch)
        {
            //�X�C�b�`�ŐF�ς���
            GetComponent<SpriteRenderer>().color = color[ID];
        }
        else
        {
            GetComponent<SpriteRenderer>().color = color[0];
        }
    }


}

//R,B,G�͐F���l�Aa�͓����x��0����1�܂Ŏw�肷��.

