using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;//プレイヤー
    private float playerRange;//プレイヤーとの距離

    public EnemyDate enemyDate;//EnemyDateから体力などの情報を呼んでくる
    private string Name = null;
    [HideInInspector] public int Hp = 0;
    private int Atk = 0;
    private float Speed = 0;

    //アニメーター
    public Animator Anim;

    // Start is called before the first frame update
    protected virtual void Start()
    {
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
        //プレイヤーまでの距離を出す
        this.playerRange = Vector2.Distance(playerObject.transform.position, transform.position);
        
    }
}
