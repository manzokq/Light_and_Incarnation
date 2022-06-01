using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    public EnemyDate enemyDate;//EnemyDateから体力などの情報を呼んでくる
    private string Name = null;
    private int Hp = 0;
    private int Atk = 0;
    private float Speed = 0;

   
    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Name = enemyDate.enemyName;
        Hp = enemyDate.hp;
        Atk = enemyDate.atk;
        Speed = enemyDate.speed;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //体力の判定
        if (this.Hp <= 0)
        {
            //seを呼び出す
            //
            this.gameObject.SetActive(false);
        }
        
        
    }
}
