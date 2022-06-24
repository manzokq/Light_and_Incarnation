using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kariHP : MonoBehaviour
{
    public Animator Anim;
    public EnemyDate enemyDate;//EnemyDateから体力などの情報を呼んでくる
    protected int Hp = 0;
    public int enemyHP;

    private void Start()
    {
        Hp = enemyDate.hp;
        enemyHP = Hp;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        // ぶつかった相手に「Attack」というタグ（Tag）がついていたら、
        //if (other.gameObject.CompareTag("Attack"))
        if (other.gameObject.CompareTag("Player"))
        {

            // 敵のHPをプレイヤーのatk分、減少させる
            //enemyHP -= playerstates.atk;

            enemyHP -= 1;

            // 敵のHPが０になったら敵オブジェクトを破壊する。
            if (enemyHP == 0)
            {

                // オブジェクトを破壊する
                Destroy(transform.root.gameObject);


            }

        }



        Debug.Log(enemyHP);
    }
}