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
    [SerializeField]
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

    //private bool movetest=false;
    

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
        //EnemyDataから各情報を代入
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
           
            Move();//移動処理の呼び出し
        }

        
    }

    void Move()
    {//移動　アップデートで呼ばれてる
        Vector2 scale = transform.localScale;
        rb.velocity = new Vector2(enemyDate.speed * _direction, rb.velocity.y);
        Anim.SetBool("Walk", true);
        //Debug.Log("move");
    }

    /// <summary>
    /// 反転する関数
    /// 実行したら移動方向が逆になる
    /// デフォは右向き
    /// </summary>
    public void Reverse()
    {//反転したいときこれを呼ぶ
        if(direction ==Direction.Right)
        {//右を向いているときに左に向ける
            direction = Direction.Left;
            _direction =-1;
            this.gameObject.transform.localRotation= Quaternion.Euler(0,-180,0);//オブジェクトの向きを逆にする
        }
        else if(direction == Direction.Left)
        {//左を向いているときに右に向ける
            direction = Direction.Right;
            _direction = 1;
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }
    /// <summary>
    /// 動くかどうかのフラグを切り替える関数
    /// デフォルトはtrue
    /// </summary>
    public void MoveFragSwitch(bool move)//移動するかをここで切り替える
    {
        if(!move)
        {
            _moveFrag = false;
            rb.velocity = Vector2.zero; 
            Anim.SetBool("Walk", false);
        }
        else
        {
            _moveFrag= true;
            Anim.SetBool("Walk", true);
        }
        //_moveFrag ^= true;
        //Debug.Log("エネミーの移動フラグ"+_moveFrag);
    }

    private void OnTriggerEnter2D(Collider2D collision)//エネミーの体力を減らす処理
    {
        if (collision.gameObject.CompareTag("WallBreak") || collision.gameObject.CompareTag("Sword") || collision.gameObject.CompareTag("Arrow"))
        {
            Hp = GameManagement.Instance.PlayerAtk(Hp);
            //Debug.LogWarning("腱に触れた");
        }
    }
}
