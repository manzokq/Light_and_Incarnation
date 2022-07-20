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
    public byte boss_changechara = 0;
    public int boss_atack_judge = 0;

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
    [SerializeField,Header("ダメージ受けた時の無敵時間")]
    public float Invincible_Time;

    private float Invincibletime = 0;
    //回避
    private bool Avoidance = false;

    //一定距離で停止
    private bool Boss_Stop = false;
    [SerializeField, Header("プレイヤー停止距離")]
    private float Boss_stop = 1;

    //[SerializeField] Animator gilranim;
    //[SerializeField] Animator swordmananim;
    //[SerializeField] Animator archeranim;

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
        if(Player==null)
        {
            Player = GameObject.FindWithTag("Player");
        }
        

        anim = GetComponent<Animator>();
        anim.SetBool("changeIncarnation", true);
        
        //体力判定用
        bosshp = Boss_HP;
        Boss_Hp_half = Boss_HP / 3;
    }

    // Update is called once per frame
    void Update()
    {
        //移動関数を呼び出し
        if (!Boss_Stop)
        {
            if (!Invincible)
            {//近づく
                boss_move();
            }
            else if (Invincible)
            {//離れる
                boss_move_reverse();
                Invincible_check();
                Boss_girl();
            }
        }

        //時間経過でプレイヤーとの距離をチェック
        if(Range_Check && !Boss_Damage && !Invincible)
        {
            time_check();
        }
        //ダメージチェック
        if (Boss_HP < bosshp)
        {
            Invincible = true;
            bosshp = Boss_HP;
            Debug.Log("ダメージを受けた,無敵になる");
        }

        //体力減少
        if (Boss_HP <= Boss_Hp_half && !Boss_hp_half)
        {
            Debug.Log("体力減少でステータス変化");
            Boss_Atk1 = Boss_Atk1 * 2;
            Boss_Atk2 = Boss_Atk2 * 2;
            Range_Time = Range_Time * 0.8f;
            Boss_hp_half = true;
        }
        if (Boss_HP <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("ボスが倒れた");
        }
    }
    //ダメージ
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            Boss_HP = GameManagement.Instance.PlayerAtk(Boss_HP);
            Debug.Log("攻撃を受けた");
        }
    }

    private void Invincible_check()
    {//無敵時間経過
        Debug.Log("無敵時間");
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
        Debug.Log("無敵終了");
        Avoidance = false;
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
        rigidboody2d.velocity = direction * -boss_x_speed;
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

    //プレイヤーとの距離を計測し形態変化
    private void Range()
    {
        //距離計測
        Vector2 pos_Player = Player.transform.position;
        Vector2 pos_Boss = this.gameObject.transform.position;
        float range_Boss_player = Vector2.Distance(pos_Player, pos_Boss);
        Debug.Log("距離は" + range_Boss_player);
        //停止
        if (range_Boss_player <= Boss_stop)
        {
            Boss_Stop = true;
            rigidboody2d.velocity = Vector2.zero;
        }
        else if (range_Boss_player > Boss_stop)
        {
            Boss_Stop = false;
        }
        //弓に形態変化
        if (range_Boss_player > Range_Change)
        {
            Boss_atacking_Archer = true;
            boss_atack_judge = 2;
            GameManagement.Instance.Boss_Character = (GameManagement.CharacterID)Enum.
                ToObject(typeof(GameManagement.CharacterID),boss_atack_judge);
            Boss_Chang();
        }
        //剣に形態変化
        if (range_Boss_player < Range_Change)
        {
            Boss_atacking_Sword = true;
            boss_atack_judge = 1;
            GameManagement.Instance.Boss_Character = (GameManagement.CharacterID)Enum.
                ToObject(typeof(GameManagement.CharacterID), boss_atack_judge);
            Boss_Chang();
        }
    }

    public void Boss_girl()
    {
        if (!Avoidance)
        {
            Avoidance = true;
            //少女に戻す
            boss_atack_judge = 0;
            GameManagement.Instance.Boss_Character =
             (GameManagement.CharacterID)Enum.ToObject(typeof(GameManagement.CharacterID),
             boss_changechara);
            Boss_Chang();
        }
    }

    public void Boss_Chang()
    {
        //0=少女
        //1＝剣士
        //2＝アーチャー
        switch (GameManagement.Instance.Boss_Character)
        {
            case GameManagement.CharacterID.Girl:
                //switch (GameManagement.Instance.BossCharacter)
                //{
                //    case GameManagement.CharacterID.Swordsman:
                //        GameManagement.Instance.Boss_Character = GameManagement.CharacterID.Swordsman;
                //        boss_changechara = 1;
                //        break;
                //    case GameManagement.CharacterID.Bowman:
                //        GameManagement.Instance.Boss_Character = GameManagement.CharacterID.Bowman;
                //        boss_changechara = 2;
                //        break;
                //    default:
                //        break;
                //}
                //boss_anim.SetBool("changeIncarnation",false); 
                boss_atack_judge = 0;
                anim.SetBool("changeArcher", false);
                anim.SetBool("changeWitch", true);
                anim.SetBool("changeSwordman", false);
                GameManagement.Instance.BossCharacter = GameManagement.CharacterID.Girl;
                Debug.Log("少女に戻った");
                break;
            case GameManagement.CharacterID.Swordsman:
                //switch (GameManagement.Instance.BossCharacter)
                //{
                //    case GameManagement.CharacterID.Girl:
                //        GameManagement.Instance.Boss_Character = GameManagement.CharacterID.Girl;
                //        boss_changechara = 0;
                //        break;
                //    case GameManagement.CharacterID.Bowman:
                //        GameManagement.Instance.Boss_Character = GameManagement.CharacterID.Bowman;
                //        boss_changechara = 2;
                //        break;
                //    default:
                //        break;
                //}
                Debug.Log("ソードマンにジョブ変更");
                boss_atack_judge = 1;
                anim.SetBool("changeArcher", false);
                anim.SetBool("changeWitch", false);
                anim.SetBool("changeSwordman", true);
                GameManagement.Instance.BossCharacter = GameManagement.CharacterID.Swordsman;
                break;
            case GameManagement.CharacterID.Bowman:
                //switch (GameManagement.Instance.BossCharacter)
                //{
                //    case GameManagement.CharacterID.Swordsman:
                //        GameManagement.Instance.Boss_Character = GameManagement.CharacterID.Swordsman;
                //        boss_changechara = 1;
                //        break;
                //    case GameManagement.CharacterID.Girl:
                //        GameManagement.Instance.Boss_Character = GameManagement.CharacterID.Girl;
                //        boss_changechara = 0;
                //        break;
                //    default:
                //        break;
                //}
                Debug.Log("アーチャーにフォルムチェンジ！！！");
                GameManagement.Instance.BossCharacter = GameManagement.CharacterID.Bowman;
                boss_atack_judge = 2;
                anim.SetBool("changeArcher", true);
                anim.SetBool("changeWitch", false);
                anim.SetBool("changeSwordman", false);
                break;
        }
        Range_Check = true;
        Avoidance = false;
    }
}
