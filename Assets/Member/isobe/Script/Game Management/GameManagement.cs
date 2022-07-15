using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
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
        Atk1 = 0,
        Atk2,
        Atk3
    }
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

    //Boss用
    [SerializeField]
    public CharacterID BossCharacter;
    [SerializeField]
    public CharacterID Boss_character;

    //プレイヤーのスクリプトを呼び出だす。
    #endregion
    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
        }


    }
    public void PlayerDamage(int Damage) //プレイヤーにダメージ
    {
        //プレイヤーを呼び出す
        PlayerHP -= Damage;

        if(PlayerHP<=0)
        {
            Debug.LogError("プレイヤーが死んだ");
            SceneManager.LoadScene("GameOver");
        }
        
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
        }
        return EnemyHP;
    }

    //Boss
    public int Boss_Atk(int Damage)
    {
        switch (Boss_character)
        {
            //剣士
            case CharacterID.Swordsman:
                switch (Atk)
                {
                    case AtkID.Atk1:
                        PlayerHP -= Damage;
                        break;
                    case AtkID.Atk2:
                        PlayerHP -= Damage;
                        break;
                }
                break;
            //アーチャー
            case CharacterID.Bowman:
                switch (Atk)
                {
                    case AtkID.Atk1:
                        PlayerHP -= Damage;
                        break;
                    case AtkID.Atk2:
                        PlayerHP -= Damage;
                        break;
                }
                break;
        }
        return PlayerHP;
    }
}
