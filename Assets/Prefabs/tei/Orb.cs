using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
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
        Debug.Log("�ԂɐG����");
        //�ڐG�����I�u�W�F�N�g�̃^�O��"��"�̂Ƃ�
        if (collision.gameObject.tag == ("Flower"))
        {
            GameObject have = collision.gameObject;

            if (have.GetComponent<Flour>().touch == false)
            {
                Orb_score += have.GetComponent<Flour>().Orb_count;
                Debug.Log("�I�[�u���������");
            }

            have.GetComponent<Flour>().touch = true;

            Debug.Log("�I�[�u��" + Orb_score + "�����Ă���");

        }
    }

}


