using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyDate enemyDate;//EnemyDate����̗͂Ȃǂ̏����Ă�ł���
    private string Name = null;
    [HideInInspector] public int Hp = 0;
    private int Atk = 0;
    public float Speed = 0;

   
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Name = enemyDate.enemyName;
        Hp = enemyDate.hp;
        Atk = enemyDate.atk;
        Speed = enemyDate.speed;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //�̗͂̔���
        if (this.Hp <= 0)
        {
            //se���Ăяo��
            //
            this.gameObject.SetActive(false);
        }
        
        
    }
}
