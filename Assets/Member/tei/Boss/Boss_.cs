using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_ : MonoBehaviour
{
    //ボスとプレイヤーの距離管理
    public GameObject Range_Player;
    public GameObject Range_Boss;

    //形態変化の時間管理
    [SerializeField, Header("距離チェッククールタイム")]
    float Range_Time;
    private bool Range_Check = true;
    private float Time_Count = 0;

    //形態変化の距離管理
    [SerializeField, Header("形態変化距離")]
    float Range_Change;

    //移動関連
    GameObject Player;
    private Rigidbody2D rigidboody2d;
    [SerializeField,Header("Bossの移動速度")]
    int boss_x_speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトのRigidbody2Dを取得
        rigidboody2d = GetComponent<Rigidbody2D>();
        //Playerオブジェトを取得
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //移動関数を呼び出し
        boss_move();
        //時間経過でプレイヤーとの距離をチェック
        if(Range_Check == true)
        {
            time_check();
        }
    }

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
        Vector2 pos_Player = Range_Player.transform.position;
        Vector2 pos_Boss = Range_Boss.transform.position;
        float range_Boss_player = Vector2.Distance(pos_Player, pos_Boss);
        Debug.Log("距離は" + range_Boss_player);
        //弓に形態変化
        if (range_Boss_player > Range_Change)
        {
            Change_Boss_Archer();
            Range_Check = true;
            Debug.Log("アーチャーにフォルムチェンジ！！！");
        }
        //剣に形態変化
        if (range_Boss_player < Range_Change)
        {
            Change_Boss_Swordman();
            Range_Check = true;
            Debug.Log("ソードマンにジョブ変更");
        }
    }

    //剣士に形態変化
    private void Change_Boss_Swordman()
    {
       

    }

    //弓に形態変化
    private void Change_Boss_Archer()
    {

    }
}
