using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected SpriteRenderer spriteRenderer;
    //�A�j���[�^�[
    public Animator Anim;
    public EnemyDate enemyDate;//EnemyDate����̗͂Ȃǂ̏����Ă�ł���
    protected string Name = null;
    [SerializeField]
    protected int Hp = 0;
    protected int Atk1 = 0;
    protected int Atk2 = 0;
    protected float Speed = 0;
    /// <summary>
    /// �E��1 ����-1
    /// </summary>
    private int _direction=1;
    [SerializeField] private bool _directionTrigger = false;
    protected GameObject playerObject;//�v���C���[
    /// <summary>
    /// �������ǂ����̃t���O
    /// </summary>
    private bool _moveFrag = true;
    private bool _process = false;
    private int _repeat = 6;
    [SerializeReference]private float _recast = 0.2f;
    

    //private bool movetest=false;
    

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
        spriteRenderer = GetComponent<SpriteRenderer>();
        //EnemyData����e������
        Name = enemyDate.enemyName;
        Hp = enemyDate.hp;
        Atk1 = enemyDate.atk1;
        Atk2 = enemyDate.atk2;
        Speed = enemyDate.speed;

        PlayerDetection();
        Invoke("PlayerDetection", 1.0f);

        if (_directionTrigger)
        {
            _direction = -1;            //�������E�ɏ�����
            direction = Direction.Left;//�������E�ɏ�����
        }
        else
        {
            _direction = 1;            //�������E�ɏ�����
            direction = Direction.Right;//�������E�ɏ�����
        }
        

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //�̗͂̔���
        if (this.Hp <= 0)
        {
            this.gameObject.SetActive(false);
        }
        if(_moveFrag)
        {
            Move();//�ړ������̌Ăяo��
        }


    }

    void PlayerDetection()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    void Move()
    {//�ړ�
        Vector2 scale = transform.localScale;
        rb.velocity = new Vector2(enemyDate.speed * _direction, rb.velocity.y);
        Anim.SetBool("Walk", true);
        //Debug.Log("move");
    }

    /// <summary>
    /// ���]����֐�
    /// ���s������ړ��������t�ɂȂ�
    /// �f�t�H�͉E����
    /// </summary>
    public void Reverse()
    {//���]�������Ƃ�������Ă�
        if(direction ==Direction.Right)
        {//�E�������Ă���Ƃ��ɍ��Ɍ�����
            direction = Direction.Left;
            _direction =-1;
            this.gameObject.transform.localRotation= Quaternion.Euler(0,-180,0);//�I�u�W�F�N�g�̌������t�ɂ���
        }
        else if(direction == Direction.Left)
        {//���������Ă���Ƃ��ɉE�Ɍ�����
            direction = Direction.Right;
            _direction = 1;
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }
    /// <summary>
    /// �������ǂ����̃t���O��؂�ւ���֐�
    /// �f�t�H���g��true
    /// </summary>
    public void MoveFragSwitch(bool move)//�ړ����邩�������Ő؂�ւ���
    {
        if(!move)
        {
            _moveFrag = false;
            rb.velocity = Vector2.zero; 
            Anim.SetBool("Walk", false);
        }
        else
        {
            _moveFrag= true;
            Anim.SetBool("Walk", true);
        }
        //_moveFrag ^= true;
        //Debug.Log("�G�l�~�[�̈ړ��t���O"+_moveFrag);
    }

    public void Damaged()
    {
        if (spriteRenderer.enabled)
        {
            StartCoroutine(Blink());
        }
        Hp = GameManagement.Instance.PlayerAtk(Hp);


        
    }
    public IEnumerator Blink()
    {
        if (!_process)
        {
            _process = true;
            for (int i = 0; i < _repeat; i++)
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
                //Debug.Log(spriteRenderer);
                yield return new WaitForSeconds(_recast);
                _process = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//�G�l�~�[�̗̑͂����炷����
    {
        if (collision.gameObject.CompareTag("WallBreak") || collision.gameObject.CompareTag("Sword") || collision.gameObject.CompareTag("Arrow"))
        {
           Damaged();
        }
    }
}
