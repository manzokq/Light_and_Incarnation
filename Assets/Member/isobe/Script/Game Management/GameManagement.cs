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
    #region ������  
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
    public MapID Map;
    [SerializeField]
    public AtkID Atk;

    //Boss�p
    [SerializeField]
    public CharacterID BossCharacter;
    [SerializeField]
    public CharacterID Boss_Character;

    //�v���C���[�̃X�N���v�g���Ăяo�����B
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
        PlayerHP = playerHp;
        PlayerMP = playerMp;
        PlayerOrb = playerOrb;
        var xbox = GameObject.FindGameObjectWithTag("Player");
        xboxPlayer =xbox.GetComponent<XboxPlayerContorol>();
        StartCoroutine(GetOrb());
        Application.targetFrameRate = 30;
    }
    private void Update()
    {
        playerHp = PlayerHP;
        playerMp = PlayerMP;
        playerOrb = PlayerOrb;
    }
    //Orb��
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
    public void PlayerDamage(int Damage) //�v���C���[�Ƀ_���[�W
    {
        //�v���C���[���Ăяo��
        PlayerHP -= Damage;
        playerHp = PlayerHP;
        xboxPlayer.ReturnGirlKey();

        if (PlayerHP <= 0)
        {
            Debug.Log("�v���C���[������");
            SceneManager.LoadScene("GameOver");
        }

        //Player.Instance.PlayerHP -= Damage;
    }
    public int PlayerAtk(int EnemyHP)�@//�G�l�~�[�Ƀ_���[�W
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
    //MP�ǉ��\��
}
