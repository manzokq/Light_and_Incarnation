using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Move : MonoBehaviour
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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԍo�߂Ńv���C���[�Ƃ̋������`�F�b�N
        if(Range_Check == true)
        {
            
            time_check();
        }
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
        
        Range_Check = true;

        //�|�Ɍ`�ԕω�
        if (range_Boss_player > Range_Change)
        {
            Change_Boss_Archer();
            Debug.Log("�A�[�`���[�Ƀt�H�����`�F���W�I�I�I");
        }
        //���Ɍ`�ԕω�
        if (range_Boss_player < Range_Change)
        {
            Change_Boss_Swordman();
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
