using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_ : MonoBehaviour
{
    //�{�X�ƃv���C���[�̋����Ǘ�
    public GameObject Range_Player;
    public GameObject Range_Boss;

    //�`�ԕω��̎��ԊǗ�
    [SerializeField, Header("�����`�F�b�N�N�[���^�C��")]
    float Range_Time;
    private bool Range_Check = true;
    private float Time_Count = 0;

    //�`�ԕω��̋����Ǘ�
    [SerializeField, Header("�`�ԕω�����")]
    float Range_Change;

    //�ړ��֘A
    GameObject Player;
    private Rigidbody2D rigidboody2d;
    [SerializeField,Header("Boss�̈ړ����x")]
    int boss_x_speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        //�I�u�W�F�N�g��Rigidbody2D���擾
        rigidboody2d = GetComponent<Rigidbody2D>();
        //Player�I�u�W�F�g���擾
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ��֐����Ăяo��
        boss_move();
        //���Ԍo�߂Ńv���C���[�Ƃ̋������`�F�b�N
        if(Range_Check == true)
        {
            time_check();
        }
    }

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
        Vector2 pos_Player = Range_Player.transform.position;
        Vector2 pos_Boss = Range_Boss.transform.position;
        float range_Boss_player = Vector2.Distance(pos_Player, pos_Boss);
        Debug.Log("������" + range_Boss_player);
        //�|�Ɍ`�ԕω�
        if (range_Boss_player > Range_Change)
        {
            Change_Boss_Archer();
            Range_Check = true;
            Debug.Log("�A�[�`���[�Ƀt�H�����`�F���W�I�I�I");
        }
        //���Ɍ`�ԕω�
        if (range_Boss_player < Range_Change)
        {
            Change_Boss_Swordman();
            Range_Check = true;
            Debug.Log("�\�[�h�}���ɃW���u�ύX");
        }
    }

    //���m�Ɍ`�ԕω�
    private void Change_Boss_Swordman()
    {
       

    }

    //�|�Ɍ`�ԕω�
    private void Change_Boss_Archer()
    {

    }
}
