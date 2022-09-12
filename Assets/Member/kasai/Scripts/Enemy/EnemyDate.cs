using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Create EnemyDate")]

public class EnemyDate : ScriptableObject
{
    public string enemyName;//�G�l�~�[�̖���
    public int hp;          //�̗�
    public int atk1;        //�ʏ�U��
    public int atk2;        //����U��
    public float speed;     //�ړ����x
}
