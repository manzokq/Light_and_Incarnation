using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Rigidbody2D rb;
    //�A�j���[�^�[
    public Animator Anim;
    public EnemyDate enemyDate;//EnemyDate����̗͂Ȃǂ̏����Ă�ł���
    protected string Name = null;
    protected int Hp = 0;
    protected int Atk1 = 0;
    protected int Atk2 = 0;
    protected float Speed = 0;
    /// <summary>
    /// �E��1 ����-1
    /// </summary>
    private int _direction=1;
    /// <summary>
    /// �������ǂ����̃t���O
    /// </summary>
    private bool _moveFrag = true;

    

    public enum Direction
    {//������enum
        Right = 0,
        Left,
    }
    //���̐錾
    Direction direction;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Name = enemyDate.enemyName;
        Hp = enemyDate.hp;
        Atk1 = enemyDate.atk1;
        Atk2 = enemyDate.atk2;
        Speed = enemyDate.speed;

        _direction = 1;            //�������E�ɏ�����
        direction= Direction.Right;//�������E�ɏ�����

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
    {//�ړ��@�A�b�v�f�[�g�ŌĂ΂�Ă�
        Vector2 scale = transform.localScale;
        rb.velocity = new Vector2(enemyDate.speed * _direction, rb.velocity.y);
        Debug.Log("move");
    }

    /// <summary>
    /// ���]����֐�
    /// ���s������ړ��������t�ɂȂ�
    /// �f�t�H�͉E����
    /// </summary>
    public void Reverse()
    {//���]�������Ƃ�������Ă�
        if(direction ==Direction.Right)
        {//�E�̎�����
            direction = Direction.Left;
            _direction =-1;
            this.gameObject.transform.localRotation= Quaternion.Euler(0,-180,0);//�I�u�W�F�N�g�̌����t�ɂ��Ă�
        }
        else if(direction == Direction.Left)
        {//�t
            direction = Direction.Right;
            _direction = 1;
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }
    /// <summary>
    /// �������ǂ����̃t���O��؂�ւ���֐�
    /// �f�t�H��true
    /// </summary>
    public void MoveFragSwitch(bool move)
    {
        if(!move)
        {
            _moveFrag = false;
            rb.velocity = Vector2.zero;
        }
        else
        {
            _moveFrag= true;
        }
        //_moveFrag ^= true;
        Debug.Log("�G�l�~�[�̈ړ��t���O"+_moveFrag);
    }
}
