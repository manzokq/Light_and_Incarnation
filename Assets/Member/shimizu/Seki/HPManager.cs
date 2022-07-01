using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    public static HPManager Instance { get => _instance; }
    static HPManager _instance;

    [SerializeField]

    private GameObject _player;

    private int _playerHP;
    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
        }
    }

    private void Start()
    {
        if(_player ==null)
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public int PlayerAtk(int EnemyHP)�@//�G�l�~�[�Ƀ_���[�W
    {
        //�v���C���[�̍U����������Čv�Z�A�G�l�~�[HP��Ԃ�

        return EnemyHP;

    }
    public int PlayerDamage(int EnemyATK) //�v���C���[�Ƀ_���[�W
    { 
        //_playerHP = 
        _playerHP -= EnemyATK;
        return _playerHP;
        //�v���C���[HP�����炷���@�G�l�~�[���Ăяo��
    }

        /*

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
                case Character.Swordsman:
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
                case Character.Bowman:
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
                case Character.Wizard:
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
        }*/
    }
