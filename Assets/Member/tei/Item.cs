using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //�I�[�u�̐�
    public float Orb_score = 0;

    private void Start()
    {
        //�X�R�A���Z�b�g
        Orb_score = 0;
    }

    // 2D�̏ꍇ�̃g���K�[����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���̂��g���K�[�ɐڐG���Ƃ��A�P�x�����Ă΂��
        Debug.Log("a");
        //�ڐG�����I�u�W�F�N�g�̃^�O��"��"�̂Ƃ�
        if (collision.gameObject.tag == ("flour"))
        {
            GameObject have = collision.gameObject;

            if (have.GetComponent<flour>().touch == false)
            {
                Orb_score += have.GetComponent<flour>().Orb_count;
                Debug.Log("d");
            }

            have.GetComponent<flour>().touch = true;

            Debug.Log(Orb_score);
        }
    }
}


////Trigger�͂Ԃ���Ƃ�
////collision�͂��蔲����Ƃ�

////collision.gameObject.             GetComponent<Orb>().                score_;
////����������Ă���I�u�W�F�N�g.       �����Ă���<�ǂ�����>(�߂�l)        �ϐ�

