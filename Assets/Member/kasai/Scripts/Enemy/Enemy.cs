using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Rigidbody2D rb;
    public EnemyDate enemyDate;//EnemyDate����̗͂Ȃǂ̏����Ă�ł���
    protected string Name = null;
    protected int Hp = 0;
    protected int Atk1 = 0;
    protected int Atk2 = 0;
    protected float Speed = 0;
    private int _direction = 1;
    private bool _moveFrag = true;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Name = enemyDate.enemyName;
        Hp = enemyDate.hp;
        Atk1 = enemyDate.atk1;
        Atk2 = enemyDate.atk2;
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
        if(_moveFrag)
        {
            Move();
        }
        
    }

    void Move()
    {
        Vector2 scale = transform.localScale;
        rb.velocity = new Vector2(enemyDate.speed * _direction, rb.velocity.y);
    }
    public void Reverse()
    {//���]�������Ƃ�������Ă�
        _direction *= -1;
    }

    public void Frag()
    {
        _moveFrag ^= false;
        Debug.Log("�G�l�~�[�̈ړ��t���O"+_moveFrag);
    }
}
