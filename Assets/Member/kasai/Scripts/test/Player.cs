using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //��������e
    [SerializeField] GameObject bullet = null;

    //�e��ێ��i�v�[�����O�j�����̃I�u�W�F�N�g
    Transform bullets;
    void Start()
    {
        //�e��ێ������̃I�u�W�F�N�g�𐶐�
        bullets = new GameObject("PlayerBullets").transform;
    }

    void Update()
    {
        //�܂��܁[��ꃁ���[�S�[�����h
        transform.Rotate(0, 0, 0.5f);

        //�e�����֐����Ăяo��
        InstBullet(transform.position, transform.rotation);
    }

    /// <summary>
    /// �e�����֐�
    /// </summary>
    /// <param name="pos">�����ʒu</param>
    /// <param name="rotation">�������̉�]</param>
    void InstBullet(Vector3 pos, Quaternion rotation)
    {
        //�A�N�e�B�u�łȂ��I�u�W�F�N�g��bullets�̒�����T��
        foreach (Transform t in bullets)
        {
            if (!t.gameObject.activeSelf)
            {
                //��A�N�e�B�u�ȃI�u�W�F�N�g�̈ʒu�Ɖ�]��ݒ�
                t.SetPositionAndRotation(pos, rotation);
                //�A�N�e�B�u�ɂ���
                t.gameObject.SetActive(true);
                return;
            }
        }
        //��A�N�e�B�u�ȃI�u�W�F�N�g���Ȃ��ꍇ�V�K����

        //��������bullets�̎q�I�u�W�F�N�g�ɂ���
        Instantiate(bullet, pos, rotation, bullets);
    }
}