using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    //オーブの数
    public float Orb_score = 0;

    private void Start()
    {
        //スコアリセット
        Orb_score = 0;
    }

    // 2Dの場合のトリガー判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 物体がトリガーに接触しとき、１度だけ呼ばれる
        Debug.Log("花に触った");
        //接触したオブジェクトのタグが"花"のとき
        if (collision.gameObject.tag == ("Flower"))
        {
            GameObject have = collision.gameObject;

            if (have.GetComponent<Flour>().touch == false)
            {
                Orb_score += have.GetComponent<Flour>().Orb_count;
                Debug.Log("オーブを回収した");
            }

            have.GetComponent<Flour>().touch = true;

            Debug.Log("オーブを" + Orb_score + "持っている");

        }
    }

}


