using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boos_Move : MonoBehaviour
{
    //ボスとプレイヤーの距離管理
    public GameObject Range_Player;
    public GameObject Range_Boos;

    //形態変化の時間管理
    [SerializeField, Header("距離チェッククールタイム")]
    float Range_Time;
    private bool Range_Check = true;
    private float Time_Count = 0;

    //形態変化の距離管理
    [SerializeField, Header("形態変化距離")]
    float Range_Change;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //時間経過でプレイヤーとの距離をチェック
        if(Range_Check == true)
        {
            
            time_check();
        }
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
        Vector2 pos_Boos = Range_Boos.transform.position;
        float range_boos_player = Vector2.Distance(pos_Player, pos_Boos);
        Debug.Log("距離は" + range_boos_player);
        
        Range_Check = true;

        //弓に形態変化
        if (range_boos_player > Range_Change)
        {
            Change_Boos_Archer();
            Debug.Log("アーチャーにフォルムチェンジ！！！");
        }
        //剣に形態変化
        if (range_boos_player < Range_Change)
        {
            Change_Boos_Swordman();
            Debug.Log("ソードマンにジョブ変更");
        }
    }

    //剣士に形態変化
    private void Change_Boos_Swordman()
    {

    }

    //弓に形態変化
    private void Change_Boos_Archer()
    {

    }


}
