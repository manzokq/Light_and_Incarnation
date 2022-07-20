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
    public byte boss_changechara = 0;
    public int boss_atack_judge = 0;

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
    [SerializeField,Header("�_���[�W�󂯂����̖��G����")]
    public float Invincible_Time;

    private float Invincibletime = 0;
    //���
    private bool Avoidance = false;

    //��苗���Œ�~
    private bool Boss_Stop = false;
    [SerializeField, Header("�v���C���[��~����")]
    private float Boss_stop = 1;

    //[SerializeField] Animator gilranim;
    //[SerializeField] Animator swordmananim;
    //[SerializeField] Animator archeranim;

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
        if(Player==null)
        {
            Player = GameObject.FindWithTag("Player");
        }
        

        anim = GetComponent<Animator>();
        anim.SetBool("changeIncarnation", true);
        
        //�̗͔���p
        bosshp = Boss_HP;
        Boss_Hp_half = Boss_HP / 3;
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ��֐����Ăяo��
        if (!Boss_Stop)
        {
            if (!Invincible)
            {//�߂Â�
                boss_move();
            }
            else if (Invincible)
            {//�����
                boss_move_reverse();
                Invincible_check();
                Boss_girl();
            }
        }

        //���Ԍo�߂Ńv���C���[�Ƃ̋������`�F�b�N
        if(Range_Check && !Boss_Damage && !Invincible)
        {
            time_check();
        }
        //�_���[�W�`�F�b�N
        if (Boss_HP < bosshp)
        {
            Invincible = true;
            bosshp = Boss_HP;
            Debug.Log("�_���[�W���󂯂�,���G�ɂȂ�");
        }

        //�̗͌���
        if (Boss_HP <= Boss_Hp_half && !Boss_hp_half)
        {
            Debug.Log("�̗͌����ŃX�e�[�^�X�ω�");
            Boss_Atk1 = Boss_Atk1 * 2;
            Boss_Atk2 = Boss_Atk2 * 2;
            Range_Time = Range_Time * 0.8f;
            Boss_hp_half = true;
        }
        if (Boss_HP <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("�{�X���|�ꂽ");
        }
    }
    //�_���[�W
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            Boss_HP = GameManagement.Instance.PlayerAtk(Boss_HP);
            Debug.Log("�U�����󂯂�");
        }
    }

    private void Invincible_check()
    {//���G���Ԍo��
        Debug.Log("���G����");
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
        Debug.Log("���G�I��");
        Avoidance = false;
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
        rigidboody2d.velocity = direction * -boss_x_speed;
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

    //�v���C���[�Ƃ̋������v�����`�ԕω�
    private void Range()
    {
        //�����v��
        Vector2 pos_Player = Player.transform.position;
        Vector2 pos_Boss = this.gameObject.transform.position;
        float range_Boss_player = Vector2.Distance(pos_Player, pos_Boss);
        Debug.Log("������" + range_Boss_player);
        //��~
        if (range_Boss_player <= Boss_stop)
        {
            Boss_Stop = true;
            rigidboody2d.velocity = Vector2.zero;
        }
        else if (range_Boss_player > Boss_stop)
        {
            Boss_Stop = false;
        }
        //�|�Ɍ`�ԕω�
        if (range_Boss_player > Range_Change)
        {
            Boss_atacking_Archer = true;
            boss_atack_judge = 2;
            GameManagement.Instance.Boss_Character = (GameManagement.CharacterID)Enum.
                ToObject(typeof(GameManagement.CharacterID),boss_atack_judge);
            Boss_Chang();
        }
        //���Ɍ`�ԕω�
        if (range_Boss_player < Range_Change)
        {
            Boss_atacking_Sword = true;
            boss_atack_judge = 1;
            GameManagement.Instance.Boss_Character = (GameManagement.CharacterID)Enum.
                ToObject(typeof(GameManagement.CharacterID), boss_atack_judge);
            Boss_Chang();
        }
    }

    public void Boss_girl()
    {
        if (!Avoidance)
        {
            Avoidance = true;
            //�����ɖ߂�
            boss_atack_judge = 0;
            GameManagement.Instance.Boss_Character =
             (GameManagement.CharacterID)Enum.ToObject(typeof(GameManagement.CharacterID),
             boss_changechara);
            Boss_Chang();
        }
    }

    public void Boss_Chang()
    {
        //0=����
        //1�����m
        //2���A�[�`���[
        switch (GameManagement.Instance.Boss_Character)
        {
            case GameManagement.CharacterID.Girl:
                //switch (GameManagement.Instance.BossCharacter)
                //{
                //    case GameManagement.CharacterID.Swordsman:
                //        GameManagement.Instance.Boss_Character = GameManagement.CharacterID.Swordsman;
                //        boss_changechara = 1;
                //        break;
                //    case GameManagement.CharacterID.Bowman:
                //        GameManagement.Instance.Boss_Character = GameManagement.CharacterID.Bowman;
                //        boss_changechara = 2;
                //        break;
                //    default:
                //        break;
                //}
                //boss_anim.SetBool("changeIncarnation",false); 
                boss_atack_judge = 0;
                anim.SetBool("changeArcher", false);
                anim.SetBool("changeWitch", true);
                anim.SetBool("changeSwordman", false);
                GameManagement.Instance.BossCharacter = GameManagement.CharacterID.Girl;
                Debug.Log("�����ɖ߂���");
                break;
            case GameManagement.CharacterID.Swordsman:
                //switch (GameManagement.Instance.BossCharacter)
                //{
                //    case GameManagement.CharacterID.Girl:
                //        GameManagement.Instance.Boss_Character = GameManagement.CharacterID.Girl;
                //        boss_changechara = 0;
                //        break;
                //    case GameManagement.CharacterID.Bowman:
                //        GameManagement.Instance.Boss_Character = GameManagement.CharacterID.Bowman;
                //        boss_changechara = 2;
                //        break;
                //    default:
                //        break;
                //}
                Debug.Log("�\�[�h�}���ɃW���u�ύX");
                boss_atack_judge = 1;
                anim.SetBool("changeArcher", false);
                anim.SetBool("changeWitch", false);
                anim.SetBool("changeSwordman", true);
                GameManagement.Instance.BossCharacter = GameManagement.CharacterID.Swordsman;
                break;
            case GameManagement.CharacterID.Bowman:
                //switch (GameManagement.Instance.BossCharacter)
                //{
                //    case GameManagement.CharacterID.Swordsman:
                //        GameManagement.Instance.Boss_Character = GameManagement.CharacterID.Swordsman;
                //        boss_changechara = 1;
                //        break;
                //    case GameManagement.CharacterID.Girl:
                //        GameManagement.Instance.Boss_Character = GameManagement.CharacterID.Girl;
                //        boss_changechara = 0;
                //        break;
                //    default:
                //        break;
                //}
                Debug.Log("�A�[�`���[�Ƀt�H�����`�F���W�I�I�I");
                GameManagement.Instance.BossCharacter = GameManagement.CharacterID.Bowman;
                boss_atack_judge = 2;
                anim.SetBool("changeArcher", true);
                anim.SetBool("changeWitch", false);
                anim.SetBool("changeSwordman", false);
                break;
        }
        Range_Check = true;
        Avoidance = false;
    }
}
