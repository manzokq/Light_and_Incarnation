using System.Collections;
using System.Collections.Generic;
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
        Atk1,
        Atk2,
        Atk3
    }
    #region ������  
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
    //�v���C���[�̃X�N���v�g���Ăяo�����B
    #endregion
    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
        }


    }
    public void PlayerDamage(int Damage) //�v���C���[�Ƀ_���[�W
    {
        //�v���C���[���Ăяo��
        PlayerHP -= Damage;


        Debug.Log(PlayerHP);
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
}