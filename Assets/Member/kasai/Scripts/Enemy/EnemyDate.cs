using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Create EnemyDate")]

public class EnemyDate : ScriptableObject
{
    public string enemyName;//エネミーの名称
    public int hp;          //体力
    public int atk1;        //通常攻撃
    public int atk2;        //特殊攻撃
    public float speed;     //移動速度
}
