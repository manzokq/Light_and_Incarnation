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

    public int PlayerAtk(int EnemyHP)　//エネミーにダメージ
    {
        //プレイヤーの攻撃をもらって計算、エネミーHPを返す

        return EnemyHP;

    }
    public int PlayerDamage(int EnemyATK) //プレイヤーにダメージ
    { 
        //_playerHP = 
        _playerHP -= EnemyATK;
        return _playerHP;
        //プレイヤーHPを減らす文　エネミーが呼び出す
    }

        /*

        public void PlayerDamage(int Damage) //プレイヤーにダメージ
        {
            //プレイヤーを呼び出す
            PlayerHP -= Damage;


            Debug.Log(PlayerHP);
            //Player.Instance.PlayerHP -= Damage;
        }
        public int PlayerAtk(int EnemyHP)　//エネミーにダメージ
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
