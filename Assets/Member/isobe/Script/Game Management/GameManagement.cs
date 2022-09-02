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
    private static int playerHp;
    private static int playerMp;
    private static int playerOrb;
    [SerializeField]
    XboxPlayerContorol xboxPlayer;
    public static GameManagement Instance { get => _instance; }
    static GameManagement _instance;
    [SerializeField, Range(0, 100)]
    public int PlayerHP;
    [SerializeField, Range(0, 100)]
    public int PlayerMP;

    public int PlayerOrb;
    [SerializeField]
    public CharacterID PlayerCharacter;
    [SerializeField]
    public CharacterID Character;
    [SerializeField]
    public string Map;
    [SerializeField]
    public AtkID Atk;

    //Boss用
    [SerializeField]
    public CharacterID BossCharacter;
    [SerializeField]
    public CharacterID Boss_Character;

    //プレイヤーのスクリプトを呼び出だす。
    #endregion
    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
        }


    }
    private void Start()
    {
        if (!(Map == null))
            //if ((Map == "MapTutorial" || Map == "MapOP" || Map == "GameOver") && SceneManager.GetActiveScene().name == "Map1")
            if ( SceneManager.GetActiveScene().name == "Map1")
            {
                PlayerHP = 100;
                PlayerMP = 100;
                PlayerOrb = 100;
                playerHp = 100;
                playerMp = 100;
                playerOrb = 100;
            }
            else if (SceneManager.GetActiveScene().name == "PVMap" || SceneManager.GetActiveScene().name == "MapTutorial")
            {
                PlayerHP = 100;
                PlayerMP = 100;
                PlayerOrb = 100;
                playerHp = 100;
                playerMp = 100;
                playerOrb = 100;
            }
            else
            {
                PlayerHP = playerHp;
                PlayerMP = playerMp;
                PlayerOrb = playerOrb;
            }

        Map = SceneManager.GetActiveScene().name;
        var xbox = GameObject.FindGameObjectWithTag("Player");
        xboxPlayer = xbox.GetComponent<XboxPlayerContorol>();
        StartCoroutine(GetOrb());
        Application.targetFrameRate = 60;
    }
    private void Update()
    {
        playerHp = PlayerHP;
        playerMp = PlayerMP;
        playerOrb = PlayerOrb;
    }
    //Orb回復
    IEnumerator GetOrb()
    {
        while (true)
        {
            if (PlayerOrb <= 100)
            {
                //Debug.Log("");
                PlayerOrb += 1;
                if (PlayerOrb >= 100)
                    PlayerOrb = 100;
            }
            playerOrb = PlayerOrb;
            yield return new WaitForSeconds(1f);
        }
    }
    public void PlayerDamage(int Damage) //プレイヤーにダメージ
    {
        //プレイヤーを呼び出す
        PlayerHP -= Damage;
        playerHp = PlayerHP;
        xboxPlayer.ReturnGirlKey();

        if (PlayerHP <= 0)
        {
            Debug.Log("プレイヤーが死んだ");
            SceneManager.LoadScene("GameOver");
        }

        //Player.Instance.PlayerHP -= Damage;
    }
    public int PlayerAtk(int EnemyHP)　//エネミーにダメージ
    {
        Debug.Log(EnemyHP);
        switch (PlayerCharacter)
        {
            case CharacterID.Swordsman:
                switch (Atk)
                {
                    case AtkID.Atk1:
                        EnemyHP -= 4;
                        break;
                    case AtkID.Atk2:
                        EnemyHP -= 4;
                        break;
                    case AtkID.Atk3:
                        EnemyHP -= 4;
                        break;
                }
                break;
            case CharacterID.Bowman:
                switch (Atk)
                {
                    case AtkID.Atk1:
                        EnemyHP -= 3;
                        break;
                    case AtkID.Atk2:
                        EnemyHP -= 3;
                        break;
                    case AtkID.Atk3:
                        EnemyHP -= 3;
                        break;
                }
                break;
        }
        Debug.Log(EnemyHP);
        Debug.Log("EnemyDame");
        return EnemyHP;
    }
    //MP追加予定
}
