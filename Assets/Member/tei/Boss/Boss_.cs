using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boss_ : MonoBehaviour
{
    //Boss�X�e�[�^�X
    public EnemyDate enemyDate;
    protected int Hp = 0;
    protected int Atk1 = 0;
    protected int Atk2 = 0;
    protected float speed = 0;
    public int Boss_HP;
    public int Boss_Atk1;
    public int Boss_Atk2;
    public float boss_x_speed;

    //�`�ԕω��̎��ԊǗ�
    [SerializeField, Header("�����`�F�b�N�N�[���^�C��")]
    float Range_Time;

    private bool Range_Check = true;
    private float Time_Count = 0;

    //�`�ԕω��̋����Ǘ�
    [SerializeField, Header("�`�ԕω�����")]
    float Range_Change;

    //�ړ��֘A
    [SerializeField]
    private GameObject Player;
    private Rigidbody2D rigidboody2d;
    //�L�����N�^�[�؂�ւ�
    [SerializeField]
    public int boss_atack_judge = 0;

    private bool boss_isGirl = true;
    private bool boss_isSwordman = false;
    private bool boss_isArcher = false;

    //�A�j��
    private Animator anim;

    //�_���[�W
    public bool Boss_Damage = false;
    public bool Boss_hp_half = false;

    //�U��
    public bool Boss_atacking_Sword = false;
    public bool Boss_atacking_Archer = false;

    //�ω��p
    private float Boss_Hp_half;
    private float bosshp;
    //���G
    public bool Invincible = false;
    [SerializeField, Header("�_���[�W�󂯂����̖��G����")]
    public float Invincible_Time;

    private float Invincibletime = 0;
    //���
    private bool Avoidance = false;
    [SerializeField, Header("�����鑬�x")]
    private float Escape = 2;

    //��苗���Œ�~
    private bool Boss_Stop = false;
    [SerializeField, Header("�v���C���[��~����")]
    private float Boss_stop = 1;

    private Vector3 boss_scale = new Vector3(2, 2, 1);

    //�ڒn
    private bool Boss_Ground = false;

    [SerializeField] Animator gilranim;
    [SerializeField] Animator swordmananim;
    [SerializeField] Animator archeranim;

    //���U������
    public bool Boss_Sword_Attack = false;
    [SerializeField, Header("���̃��[�`")]
    private float Boss_Sword_Reach = 1;

    //�Q�[�g
    [SerializeField, Header("�Q�[�g")]
    public GameObject EndGate;

    //�ǉ�
    private bool Threefold = false;
    private float Threefold_speed = 3;
    private float Threefold_Ct = 2;
    private float Threefold_range = 7;
    //�e���|�[�g
    private float Teleport_Hp;
    private float Teleport_Hp2;
    private float Teleport_Hp3;
    private bool Teleport_Hp_1 = false;
    private bool Teleport_Hp_2 = false;
    private bool Teleport_Hp_3 = false;
    [SerializeField, Header("�e���|�[�g��")]
    public GameObject Tp_pos_1;
    public GameObject Tp_pso_2;
    public GameObject Tp_pos_3;

    [SerializeField, Header("�A�[�`����~")]
    public float Bowman_Stop = 15;

    public static Boss_ instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Hp = enemyDate.hp;
        Boss_HP = Hp;
        Atk1 = enemyDate.atk1;
        Boss_Atk1 = Atk1;
        Atk2 = enemyDate.atk2;
        Boss_Atk2 = Atk2;
        speed = enemyDate.speed;
        boss_x_speed = speed;

        //�I�u�W�F�N�g��Rigidbody2D���擾
        rigidboody2d = GetComponent<Rigidbody2D>();
        //Player�I�u�W�F�g���擾
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");
        }


        anim = GetComponent<Animator>();
        anim.SetBool("changeIncarnation", true);

        //�̗͔���p
        bosshp = Boss_HP;
        Boss_Hp_half = Boss_HP / 3;

        Teleport_Hp = Boss_HP / 2;
        Teleport_Hp2 = Boss_HP / 4;
        Teleport_Hp3 = Boss_HP / 5;

        boss_scale.x = -2;
        transform.localScale = boss_scale;

    }

    // Update is called once per frame
    void Update()
    {
        //���ɂ��Ă��瓮���o��
        if (Boss_Ground)
        {
            //�ړ��֐����Ăяo��
            if (!Boss_Stop)
            {
                if (!Invincible || boss_atack_judge == 1 || boss_atack_judge == 0)
                {//�߂Â�
                    boss_move();
                }
                if (boss_atack_judge == 2)
                {//�|�Ȃ痣���
                    boss_move_reverse_Bowman();
                }
            }
            if (Invincible)
            {//�����
                boss_move_reverse();
                Invincible_check();
                Boss_girl();
            }

            //���Ԍo�߂Ńv���C���[�Ƃ̋������`�F�b�N
            if (Range_Check && !Boss_Damage && !Invincible)
            {
                time_check();
            }
            //�ҋ@���[�V����
            if (rigidboody2d.velocity.x < 0.1f && rigidboody2d.velocity.x > -0.1f)
            {
                if (boss_atack_judge == 0)
                {
                    gilranim.SetBool("Moving", false);
                }
                else if (boss_atack_judge == 1)
                {
                    swordmananim.SetBool("SwordRun", false);
                }
                else if (boss_atack_judge == 2)
                {
                    archeranim.SetBool("ArcherMove", false);
                }
            }
            else
            {

                if (boss_atack_judge == 0)
                {
                    gilranim.SetBool("Moving", true);
                }
                else if (boss_atack_judge == 1)
                {
                    swordmananim.SetBool("SwordRun", true);
                }
                else if (boss_atack_judge == 2)
                {
                    archeranim.SetBool("ArcherMove", true);
                }
            }
        }

        //�_���[�W�`�F�b�N
        if (Boss_HP < bosshp)
        {
            Invincible = true;
            bosshp = Boss_HP;
            //Debug.Log("�_���[�W���󂯂�,���G�ɂȂ�");
            Avoidance = true;
        }

        //�̗͌���
        if (Boss_HP <= Boss_Hp_half && !Boss_hp_half)
        {
            //Debug.Log("�̗͌����ŃX�e�[�^�X�ω�");
            Boss_Atk1 = Boss_Atk1 * 2;
            Boss_Atk2 = Boss_Atk2 * 2;
            Range_Time = Range_Time * 0.8f;
            Boss_hp_half = true;
        }
        if (Boss_HP <= 0)
        {
            //Win���o��
            WinTextsp.instance.str=true;

            //�Z�b�g�A�N�e�B�u�ŃQ�[�g�o��
            EndGate.SetActive(true);

            Destroy(this.gameObject);
            //Debug.Log("�{�X���|�ꂽ");

        }
        //�e���|�[�g
        if (Boss_HP <= Teleport_Hp && !Teleport_Hp_1)
        {
            Teleport_Hp_1 = true;
            Vector2 Gate = Tp_pos_1.transform.position;
            float x = Gate.x;
            float y = -6;
            transform.position = new Vector2(x, y);
        }
        if (Boss_HP <= Teleport_Hp2 && !Teleport_Hp_2)
        {
            Teleport_Hp_2 = true;
            Vector2 Gate = Tp_pso_2.transform.position;
            float x = Gate.x;
            float y = -6;
            transform.position = new Vector2(x, y);
        }
        if (Boss_HP <= Teleport_Hp3 && !Teleport_Hp_3)
        {
            Teleport_Hp_3 = true;
            Vector2 Gate = Tp_pos_3.transform.position;
            float x = Gate.x;
            float y = -6;
            transform.position = new Vector2(x, y);
        }

        if (boss_atack_judge == 2)
        {
            if (rigidboody2d.velocity.x < -0.5)
            {
                boss_scale.x = 2;
                transform.localScale = boss_scale;
            }
            if (rigidboody2d.velocity.x > 0.5)
            {
                boss_scale.x = -2;
                transform.localScale = boss_scale;
            }
        }
        //���E���]
        if (boss_atack_judge == 1 || boss_atack_judge == 0)
        {
            if (rigidboody2d.velocity.x < -0.5)
            {
                boss_scale.x = -2;
                transform.localScale = boss_scale;
            }
            if (rigidboody2d.velocity.x > 0.5)
            {
                boss_scale.x = 2;
                transform.localScale = boss_scale;
            }
        }

        Boss_Move_Stop();
        Invoke("Threefold_", 3.0f);


        //Bosssword�A�^�b�N
        Vector2 pos_Player = Player.transform.position;
        Vector2 pos_Boss = this.gameObject.transform.position;
        float Sword_Boss_player = Vector2.Distance(pos_Player, pos_Boss);
        if (Sword_Boss_player <= Boss_Sword_Reach)
        {//�U����
            Boss_Sword_Attack = true;
        }
        if (Sword_Boss_player > Boss_Sword_Reach)
        {//�U���s��
            Boss_Sword_Attack = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //��
        if (collision.gameObject.CompareTag("Wall"))
        {
            Boss_Ground = true;
        }
        //�U��
        if (!Invincible && collision.gameObject.CompareTag("Arrow") || !Invincible && collision.gameObject.CompareTag("Sword"))
        {
            Boss_HP = GameManagement.Instance.PlayerAtk(Boss_HP);
            //Debug.Log("�U�����󂯂�");

        }
    }

    private void Invincible_check()
    {//���G���Ԍo��
        //Debug.Log("���G����");
        Invincibletime += Time.deltaTime;
        if (Invincible_Time <= Invincibletime)
        {
            Invincibletime = 0;
            Avoidancecheck();
        }
    }
    //���G�I��
    private void Avoidancecheck()
    {//�ʏ�s���ɖ߂�
        //GetComponent<BoxCollider>().enabled = true;
        Invincible = false;
        //Debug.Log("���G�I��");
        Avoidance = false;
    }
    //����
    private void time_check()
    {
        Time_Count += Time.deltaTime;
        if (Range_Time <= Time_Count)
        {
            Range_Check = false;
            Time_Count = 0;
            Range();
        }
    }

    //�v���C���[�ɋ߂Â�
    private void boss_move()
    {
        //�v���C���[�̈ʒu�擾
        Vector2 targetPos = Player.transform.position;
        //player��x���W
        float x = targetPos.x;
        //player��y���W
        float y = 0;
        //�ړ����v�Z�����邽�߂ɓ񎟌��x�N�g�������
        Vector2 direction = new Vector2(x - transform.position.x, y).normalized;
        //�ړ����x���w��
        rigidboody2d.velocity = direction * boss_x_speed;

    }
    private void boss_move_reverse_Bowman()
    {
        //�v���C���[�̈ʒu�擾
        Vector2 targetPos = Player.transform.position;
        //player��x���W
        float x = targetPos.x;
        //player��y���W
        float y = 0;
        //�ړ����v�Z�����邽�߂ɓ񎟌��x�N�g�������
        Vector2 direction = new Vector2(x - transform.position.x, y).normalized;
        //�ړ����x���w��
        rigidboody2d.velocity = direction * -speed / 2;
    }
    //�v���C���[���痣���
    private void boss_move_reverse()
    {
        //�v���C���[�̈ʒu�擾
        Vector2 targetPos = Player.transform.position;
        //player��x���W
        float x = targetPos.x;
        //player��y���W
        float y = 0;
        //�ړ����v�Z�����邽�߂ɓ񎟌��x�N�g�������
        Vector2 direction = new Vector2(x - transform.position.x, y).normalized;
        //�ړ����x���w��
        rigidboody2d.velocity = direction * speed * -Escape;
    }
    //��~
    private void Boss_Move_Stop()
    {
        if (!Avoidance)
        {//�����v��
            Vector2 pos_Player = Player.transform.position;
            Vector2 pos_Boss = this.gameObject.transform.position;
            float range_Boss_player = Vector2.Distance(pos_Player, pos_Boss);
            //��~
            if (range_Boss_player <= Boss_stop || range_Boss_player >= Bowman_Stop)
            {
                Boss_Stop = true;
                rigidboody2d.velocity = Vector2.zero;
            }
            else if (range_Boss_player > Boss_stop)
            {
                Boss_Stop = false;
            }
        }
    }

    //�����v�����ړ����x�ω�
    private void Threefold_()
    {
        //�����v��
        Vector2 pos_Player = Player.transform.position;
        Vector2 pos_Boss = this.gameObject.transform.position;
        float Boss_player = Vector2.Distance(pos_Player, pos_Boss);
        //�����̃N�[���^�C��
        Time_Count += Time.deltaTime;
        if (Threefold_Ct <= Time_Count)
        {
            Time_Count = 0;

            if (Boss_player >= Threefold_range)
            {//�O�{�ŋ߂Â�
             //�v���C���[�̈ʒu�擾
                Vector2 targetPos = Player.transform.position;
                //player��x���W
                float x = targetPos.x;
                //player��y���W
                float y = 0;
                //�ړ����v�Z�����邽�߂ɓ񎟌��x�N�g�������
                Vector2 direction = new Vector2(x - transform.position.x, y).normalized;
                //�ړ����x���w��
                rigidboody2d.velocity = direction * boss_x_speed * Threefold_speed;
            }
        }
        Threefold = false;

    }

    //�v���C���[�Ƃ̋������v�����`�ԕω�
    private void Range()
    {
        //�����v��
        Vector2 pos_Player = Player.transform.position;
        Vector2 pos_Boss = this.gameObject.transform.position;
        float range_Boss_player = Vector2.Distance(pos_Player, pos_Boss);
        //Debug.Log("������" + range_Boss_player);

        //�߂Â��ω�


        //�|�Ɍ`�ԕω�
        if (range_Boss_player > Range_Change && !boss_isArcher)
        {
            boss_isGirl = false;
            boss_isSwordman = false;
            boss_isArcher = true;
            //Debug.Log("Boss�|�ɕω�");
            anim.SetBool("changeWitch", false);
            anim.SetBool("changeSwordman", false);
            anim.SetBool("changeArcher", true);
            Boss_atacking_Archer = true;
            Boss_atacking_Sword = false;
            boss_atack_judge = 2;
        }
        //���Ɍ`�ԕω�
        if (range_Boss_player < Range_Change && !boss_isSwordman)
        {
            boss_isGirl = false;
            boss_isSwordman = true;
            boss_isArcher = false;
            //Debug.Log("Boss���m�ɕω�");
            anim.SetBool("changeArcher", false);
            anim.SetBool("changeWitch", false);
            anim.SetBool("changeSwordman", true);
            Boss_atacking_Sword = true;
            Boss_atacking_Archer = false;
            boss_atack_judge = 1;
        }
        Range_Check = true;
    }

    public void Boss_girl()
    {
        //�����ɖ߂�
        //Debug.Log("Boss�����ɕω�");
        boss_isGirl = true;
        boss_isSwordman = false;
        boss_isArcher = false;
        anim.SetBool("changeArcher", false);
        anim.SetBool("changeSwordman", false);
        anim.SetBool("changeWitch", true);
        Range_Check = true;
        Boss_atacking_Sword = false;
        Boss_atacking_Archer = false;
        boss_atack_judge = 0;
    }
}

