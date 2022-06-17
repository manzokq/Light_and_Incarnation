using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Rigidbody2D rb;
    //アニメーター
    public Animator Anim;
    public EnemyDate enemyDate;//EnemyDateから体力などの情報を呼んでくる
    protected string Name = null;
    protected int Hp = 0;
    protected int Atk1 = 0;
    protected int Atk2 = 0;
    protected float Speed = 0;
    /// <summary>
    /// 右は1 左は-1
    /// </summary>
    private int _direction=1;
    /// <summary>
    /// 動くかどうかのフラグ
    /// </summary>
    private bool _moveFrag = true;

    

    public enum Direction
    {//方向のenum
        Right = 0,
        Left,
    }
    //↑の宣言
    Direction direction;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Name = enemyDate.enemyName;
        Hp = enemyDate.hp;
        Atk1 = enemyDate.atk1;
        Atk2 = enemyDate.atk2;
        Speed = enemyDate.speed;

        _direction = 1;            //方向を右に初期化
        direction= Direction.Right;//方向を右に初期化

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
        if(_moveFrag)
        {
           
            Move();
        }
        
    }

    void Move()
    {//移動　アップデートで呼ばれてる
        Vector2 scale = transform.localScale;
        rb.velocity = new Vector2(enemyDate.speed * _direction, rb.velocity.y);
        Debug.Log("move");
    }

    /// <summary>
    /// 反転する関数
    /// 実行したら移動方向が逆になる
    /// デフォは右向き
    /// </summary>
    public void Reverse()
    {//反転したいときこれを呼ぶ
        if(direction ==Direction.Right)
        {//右の時左に
            direction = Direction.Left;
            _direction =-1;
            this.gameObject.transform.localRotation= Quaternion.Euler(0,-180,0);//オブジェクトの向き逆にしてる
        }
        else if(direction == Direction.Left)
        {//逆
            direction = Direction.Right;
            _direction = 1;
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }
    /// <summary>
    /// 動くかどうかのフラグを切り替える関数
    /// デフォはtrue
    /// </summary>
    public void MoveFragSwitch(bool move)
    {
        if(!move)
        {
            _moveFrag = false;
            rb.velocity = Vector2.zero;
        }
        else
        {
            _moveFrag= true;
        }
        //_moveFrag ^= true;
        Debug.Log("エネミーの移動フラグ"+_moveFrag);
    }
}
