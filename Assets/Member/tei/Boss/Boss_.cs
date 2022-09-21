using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boss_ : MonoBehaviour
{
    //Bossステータス
    public EnemyDate enemyDate;
    protected int Hp = 0;
    protected int Atk1 = 0;
    protected int Atk2 = 0;
    protected float speed = 0;
    public int Boss_HP;
    public int Boss_Atk1;
    public int Boss_Atk2;
    public float boss_x_speed;

    //形態変化の時間管理
    [SerializeField, Header("距離チェッククールタイム")]
    float Range_Time;

    private bool Range_Check = true;
    private float Time_Count = 0;

    //形態変化の距離管理
    [SerializeField, Header("形態変化距離")]
    float Range_Change;

    //移動関連
    [SerializeField]
    private GameObject Player;
    private Rigidbody2D rigidboody2d;
    //キャラクター切り替え
    [SerializeField]
    public int boss_atack_judge = 0;

    private bool boss_isGirl = true;
    private bool boss_isSwordman = false;
    private bool boss_isArcher = false;

    //アニメ
    private Animator anim;

    //ダメージ
    public bool Boss_Damage = false;
    public bool Boss_hp_half = false;

    //攻撃
    public bool Boss_atacking_Sword = false;
    public bool Boss_atacking_Archer = false;

    //変化用
    private float Boss_Hp_half;
    private float bosshp;
    //無敵
    public bool Invincible = false;
    [SerializeField, Header("ダメージ受けた時の無敵時間")]
    public float Invincible_Time;

    private float Invincibletime = 0;
    //回避
    private bool Avoidance = false;
    [SerializeField, Header("逃げる速度")]
    private float Escape = 2;

    //一定距離で停止
    private bool Boss_Stop = false;
    [SerializeField, Header("プレイヤー停止距離")]
    private float Boss_stop = 1;

    private Vector3 boss_scale = new Vector3(2, 2, 1);

    //接地
    private bool Boss_Ground = false;

    [SerializeField] Animator gilranim;
    [SerializeField] Animator swordmananim;
    [SerializeField] Animator archeranim;

    //剣攻撃判定
    public bool Boss_Sword_Attack = false;
    [SerializeField, Header("剣のリーチ")]
    private float Boss_Sword_Reach = 1;

    //ゲート
    [SerializeField, Header("ゲート")]
    public GameObject EndGate;

    //追加
    private bool Threefold = false;
    private float Threefold_speed = 3;
    private float Threefold_Ct = 2;
    private float Threefold_range = 7;
    //テレポート
    private float Teleport_Hp;
    private float Teleport_Hp2;
    private float Teleport_Hp3;
    private bool Teleport_Hp_1 = false;
    private bool Teleport_Hp_2 = false;
    private bool Teleport_Hp_3 = false;
    [SerializeField, Header("テレポート先")]
    public GameObject Tp_pos_1;
    public GameObject Tp_pso_2;
    public GameObject Tp_pos_3;

    [SerializeField, Header("アーチャ停止")]
    public float Bowman_Stop = 15;

    public static Boss_ instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Hp = enemyDate.hp;
        Boss_HP = Hp;
        Atk1 = enemyDate.atk1;
        Boss_Atk1 = Atk1;
        Atk2 = enemyDate.atk2;
        Boss_Atk2 = Atk2;
        speed = enemyDate.speed;
        boss_x_speed = speed;

        //オブジェクトのRigidbody2Dを取得
        rigidboody2d = GetComponent<Rigidbody2D>();
        //Playerオブジェトを取得
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");
        }


        anim = GetComponent<Animator>();
        anim.SetBool("changeIncarnation", true);

        //体力判定用
        bosshp = Boss_HP;
        Boss_Hp_half = Boss_HP / 3;

        Teleport_Hp = Boss_HP / 2;
        Teleport_Hp2 = Boss_HP / 4;
        Teleport_Hp3 = Boss_HP / 5;

        boss_scale.x = -2;
        transform.localScale = boss_scale;

    }

    // Update is called once per frame
    void Update()
    {
        //床についてから動き出し
        if (Boss_Ground)
        {
            //移動関数を呼び出し
            if (!Boss_Stop)
            {
                if (!Invincible || boss_atack_judge == 1 || boss_atack_judge == 0)
                {//近づく
                    boss_move();
                }
                if (boss_atack_judge == 2)
                {//弓なら離れる
                    boss_move_reverse_Bowman();
                }
            }
            if (Invincible)
            {//離れる
                boss_move_reverse();
                Invincible_check();
                Boss_girl();
            }

            //時間経過でプレイヤーとの距離をチェック
            if (Range_Check && !Boss_Damage && !Invincible)
            {
                time_check();
            }
            //待機モーション
            if (rigidboody2d.velocity.x < 0.1f && rigidboody2d.velocity.x > -0.1f)
            {
                if (boss_atack_judge == 0)
                {
                    gilranim.SetBool("Moving", false);
                }
                else if (boss_atack_judge == 1)
                {
                    swordmananim.SetBool("SwordRun", false);
                }
                else if (boss_atack_judge == 2)
                {
                    archeranim.SetBool("ArcherMove", false);
                }
            }
            else
            {

                if (boss_atack_judge == 0)
                {
                    gilranim.SetBool("Moving", true);
                }
                else if (boss_atack_judge == 1)
                {
                    swordmananim.SetBool("SwordRun", true);
                }
                else if (boss_atack_judge == 2)
                {
                    archeranim.SetBool("ArcherMove", true);
                }
            }
        }

        //ダメージチェック
        if (Boss_HP < bosshp)
        {
            Invincible = true;
            bosshp = Boss_HP;
            //Debug.Log("ダメージを受けた,無敵になる");
            Avoidance = true;
        }

        //体力減少
        if (Boss_HP <= Boss_Hp_half && !Boss_hp_half)
        {
            //Debug.Log("体力減少でステータス変化");
            Boss_Atk1 = Boss_Atk1 * 2;
            Boss_Atk2 = Boss_Atk2 * 2;
            Range_Time = Range_Time * 0.8f;
            Boss_hp_half = true;
        }
        if (Boss_HP <= 0)
        {
            //Winを出す
            WinTextsp.instance.str=true;

            //セットアクティブでゲート出す
            EndGate.SetActive(true);

            Destroy(this.gameObject);
            //Debug.Log("ボスが倒れた");

        }
        //テレポート
        if (Boss_HP <= Teleport_Hp && !Teleport_Hp_1)
        {
            Teleport_Hp_1 = true;
            Vector2 Gate = Tp_pos_1.transform.position;
            float x = Gate.x;
            float y = -6;
            transform.position = new Vector2(x, y);
        }
        if (Boss_HP <= Teleport_Hp2 && !Teleport_Hp_2)
        {
            Teleport_Hp_2 = true;
            Vector2 Gate = Tp_pso_2.transform.position;
            float x = Gate.x;
            float y = -6;
            transform.position = new Vector2(x, y);
        }
        if (Boss_HP <= Teleport_Hp3 && !Teleport_Hp_3)
        {
            Teleport_Hp_3 = true;
            Vector2 Gate = Tp_pos_3.transform.position;
            float x = Gate.x;
            float y = -6;
            transform.position = new Vector2(x, y);
        }

        if (boss_atack_judge == 2)
        {
            if (rigidboody2d.velocity.x < -0.5)
            {
                boss_scale.x = 2;
                transform.localScale = boss_scale;
            }
            if (rigidboody2d.velocity.x > 0.5)
            {
                boss_scale.x = -2;
                transform.localScale = boss_scale;
            }
        }
        //左右反転
        if (boss_atack_judge == 1 || boss_atack_judge == 0)
        {
            if (rigidboody2d.velocity.x < -0.5)
            {
                boss_scale.x = -2;
                transform.localScale = boss_scale;
            }
            if (rigidboody2d.velocity.x > 0.5)
            {
                boss_scale.x = 2;
                transform.localScale = boss_scale;
            }
        }

        Boss_Move_Stop();
        Invoke("Threefold_", 3.0f);


        //Bossswordアタック
        Vector2 pos_Player = Player.transform.position;
        Vector2 pos_Boss = this.gameObject.transform.position;
        float Sword_Boss_player = Vector2.Distance(pos_Player, pos_Boss);
        if (Sword_Boss_player <= Boss_Sword_Reach)
        {//攻撃可
            Boss_Sword_Attack = true;
        }
        if (Sword_Boss_player > Boss_Sword_Reach)
        {//攻撃不可
            Boss_Sword_Attack = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //床
        if (collision.gameObject.CompareTag("Wall"))
        {
            Boss_Ground = true;
        }
        //攻撃
        if (!Invincible && collision.gameObject.CompareTag("Arrow") || !Invincible && collision.gameObject.CompareTag("Sword"))
        {
            Boss_HP = GameManagement.Instance.PlayerAtk(Boss_HP);
            //Debug.Log("攻撃を受けた");

        }
    }

    private void Invincible_check()
    {//無敵時間経過
        //Debug.Log("無敵時間");
        Invincibletime += Time.deltaTime;
        if (Invincible_Time <= Invincibletime)
        {
            Invincibletime = 0;
            Avoidancecheck();
        }
    }
    //無敵終了
    private void Avoidancecheck()
    {//通常行動に戻る
        //GetComponent<BoxCollider>().enabled = true;
        Invincible = false;
        //Debug.Log("無敵終了");
        Avoidance = false;
    }
    //時間
    private void time_check()
    {
        Time_Count += Time.deltaTime;
        if (Range_Time <= Time_Count)
        {
            Range_Check = false;
            Time_Count = 0;
            Range();
        }
    }

    //プレイヤーに近づく
    private void boss_move()
    {
        //プレイヤーの位置取得
        Vector2 targetPos = Player.transform.position;
        //playerのx座標
        float x = targetPos.x;
        //playerのy座標
        float y = 0;
        //移動を計算させるために二次元ベクトルを作る
        Vector2 direction = new Vector2(x - transform.position.x, y).normalized;
        //移動速度を指定
        rigidboody2d.velocity = direction * boss_x_speed;

    }
    private void boss_move_reverse_Bowman()
    {
        //プレイヤーの位置取得
        Vector2 targetPos = Player.transform.position;
        //playerのx座標
        float x = targetPos.x;
        //playerのy座標
        float y = 0;
        //移動を計算させるために二次元ベクトルを作る
        Vector2 direction = new Vector2(x - transform.position.x, y).normalized;
        //移動速度を指定
        rigidboody2d.velocity = direction * -speed / 2;
    }
    //プレイヤーから離れる
    private void boss_move_reverse()
    {
        //プレイヤーの位置取得
        Vector2 targetPos = Player.transform.position;
        //playerのx座標
        float x = targetPos.x;
        //playerのy座標
        float y = 0;
        //移動を計算させるために二次元ベクトルを作る
        Vector2 direction = new Vector2(x - transform.position.x, y).normalized;
        //移動速度を指定
        rigidboody2d.velocity = direction * speed * -Escape;
    }
    //停止
    private void Boss_Move_Stop()
    {
        if (!Avoidance)
        {//距離計測
            Vector2 pos_Player = Player.transform.position;
            Vector2 pos_Boss = this.gameObject.transform.position;
            float range_Boss_player = Vector2.Distance(pos_Player, pos_Boss);
            //停止
            if (range_Boss_player <= Boss_stop || range_Boss_player >= Bowman_Stop)
            {
                Boss_Stop = true;
                rigidboody2d.velocity = Vector2.zero;
            }
            else if (range_Boss_player > Boss_stop)
            {
                Boss_Stop = false;
            }
        }
    }

    //距離計測し移動速度変化
    private void Threefold_()
    {
        //距離計測
        Vector2 pos_Player = Player.transform.position;
        Vector2 pos_Boss = this.gameObject.transform.position;
        float Boss_player = Vector2.Distance(pos_Player, pos_Boss);
        //加速のクールタイム
        Time_Count += Time.deltaTime;
        if (Threefold_Ct <= Time_Count)
        {
            Time_Count = 0;

            if (Boss_player >= Threefold_range)
            {//三倍で近づく
             //プレイヤーの位置取得
                Vector2 targetPos = Player.transform.position;
                //playerのx座標
                float x = targetPos.x;
                //playerのy座標
                float y = 0;
                //移動を計算させるために二次元ベクトルを作る
                Vector2 direction = new Vector2(x - transform.position.x, y).normalized;
                //移動速度を指定
                rigidboody2d.velocity = direction * boss_x_speed * Threefold_speed;
            }
        }
        Threefold = false;

    }

    //プレイヤーとの距離を計測し形態変化
    private void Range()
    {
        //距離計測
        Vector2 pos_Player = Player.transform.position;
        Vector2 pos_Boss = this.gameObject.transform.position;
        float range_Boss_player = Vector2.Distance(pos_Player, pos_Boss);
        //Debug.Log("距離は" + range_Boss_player);

        //近づく変化


        //弓に形態変化
        if (range_Boss_player > Range_Change && !boss_isArcher)
        {
            boss_isGirl = false;
            boss_isSwordman = false;
            boss_isArcher = true;
            //Debug.Log("Boss弓に変化");
            anim.SetBool("changeWitch", false);
            anim.SetBool("changeSwordman", false);
            anim.SetBool("changeArcher", true);
            Boss_atacking_Archer = true;
            Boss_atacking_Sword = false;
            boss_atack_judge = 2;
        }
        //剣に形態変化
        if (range_Boss_player < Range_Change && !boss_isSwordman)
        {
            boss_isGirl = false;
            boss_isSwordman = true;
            boss_isArcher = false;
            //Debug.Log("Boss剣士に変化");
            anim.SetBool("changeArcher", false);
            anim.SetBool("changeWitch", false);
            anim.SetBool("changeSwordman", true);
            Boss_atacking_Sword = true;
            Boss_atacking_Archer = false;
            boss_atack_judge = 1;
        }
        Range_Check = true;
    }

    public void Boss_girl()
    {
        //少女に戻す
        //Debug.Log("Boss少女に変化");
        boss_isGirl = true;
        boss_isSwordman = false;
        boss_isArcher = false;
        anim.SetBool("changeArcher", false);
        anim.SetBool("changeSwordman", false);
        anim.SetBool("changeWitch", true);
        Range_Check = true;
        Boss_atacking_Sword = false;
        Boss_atacking_Archer = false;
        boss_atack_judge = 0;
    }
}

