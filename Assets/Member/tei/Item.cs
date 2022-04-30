using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
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
        Debug.Log("a");
        //接触したオブジェクトのタグが"花"のとき
        if (collision.gameObject.tag == ("flour"))
        {
            GameObject have = collision.gameObject;

            if (have.GetComponent<flour>().touch == false)
            {
                Orb_score += have.GetComponent<flour>().Orb_count;
                Debug.Log("d");
            }

            have.GetComponent<flour>().touch = true;

            Debug.Log(Orb_score);
        }
    }
}


////Triggerはぶつかるとき
////collisionはすり抜けるとき

////collision.gameObject.             GetComponent<Orb>().                score_;
////判定を持っているオブジェクト.       持ってくる<どこから>(戻り値)        変数

