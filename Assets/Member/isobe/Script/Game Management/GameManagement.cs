using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    #region IDリスト
    public enum CharacterID
    {
        Girl = 0,
        Swordsman,
        Bowman,
        Wizard
    }
    public enum MapID
    {
        MapTutorial = 0,
        Map1,
        Map2,
        Map3,
        MapBoss

    }
    public enum AtkID
    {
        Atk1,
        Atk2,
        Atk3
    }
    #endregion
    #region 初期化  
    public static GameManagement Instance { get => _instance; }
    static GameManagement _instance;
    [SerializeField, Range(0, 100)]
    public int PlayerHP;
    [SerializeField, Range(0, 100)]
    public int PlayerMP;
    [SerializeField, Range(0, 100)]
    public int PlayerOrb;
    [SerializeField]
    public CharacterID PlayerCharacter;
    [SerializeField]
    public CharacterID Character;
    [SerializeField]
    public MapID Map;
    [SerializeField]
    public AtkID Atk;
    [SerializeField]
    private PlayerControl player;
    //プレイヤーのスクリプトを呼び出だす。
    #endregion
    #region 処理
    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
        }
    }
    private void Start()
    {
        //名前が変われば変更を行う!!
        if(GameObject.Find("chara")!=null)
        player = GameObject.Find("chara").GetComponent<PlayerControl>();
    }
    public void PlayerDamage(int Damage) //プレイヤーにダメージ
    {
        //プレイヤーを呼び出す
        PlayerHP -= Damage;

        
        //Debug.Log("PlayerHP"+PlayerHP);
        //Player.Instance.PlayerHP -= Damage;
    }
    public int PlayerAtk(int EnemyHP)　//エネミーにダメージ
    {
        switch (PlayerCharacter)
        {
            case CharacterID.Swordsman:
                switch (Atk)
                {
                    case AtkID.Atk1:
                        EnemyHP -= 1;
                        break;
                    case AtkID.Atk2:
                        EnemyHP -= 2;
                        break;
                    case AtkID.Atk3:
                        EnemyHP -= 3;
                        break;
                }
                break;
            case CharacterID.Bowman:
                switch (Atk)
                {
                    case AtkID.Atk1:
                        EnemyHP -= 1;
                        break;
                    case AtkID.Atk2:
                        EnemyHP -= 2;
                        break;
                    case AtkID.Atk3:
                        EnemyHP -= 3;
                        break;
                }
                break;
            case CharacterID.Wizard:
                switch (Atk)
                {
                    case AtkID.Atk1:
                        EnemyHP -= 1;
                        break;
                    case AtkID.Atk2:
                        EnemyHP -= 2;
                        break;
                    case AtkID.Atk3:
                        EnemyHP -= 3;
                        break;
                }
                break;

            default:
                break;
        }
        return EnemyHP;
    }
    #endregion
}
