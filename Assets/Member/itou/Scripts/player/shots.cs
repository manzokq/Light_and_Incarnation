using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shots : MonoBehaviour
{
    // Rigidbody2D �R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D rb;
    // ���@�̈ړ����x���i�[����ϐ��i�����l 5�j
    public float speed = 5;
    // PlayerBullet �v���n�u
    public GameObject bullet;

    // �Q�[���̃X�^�[�g���̏���
    void Start()
    {
        // Rigidbody2D �R���|�[�l���g���擾���ĕϐ� rb �Ɋi�[
        rb = GetComponent<Rigidbody2D>();
        // �e�̔��ˏ����i�R���[�`�� Shot �j�����s
        StartCoroutine("Shot");
    }

    // �Q�[�����s���̌J��Ԃ�����
    void Update()
    {
        // �E�E���̃f�W�^�����͒l�� x �ɓn��
        float x = Input.GetAxisRaw("Horizontal");
        // ��E���̃f�W�^�����͒l y �ɓn��
        float y = Input.GetAxisRaw("Vertical");
        // �ړ�������������߂�
        // x �� y �̓��͒l�𐳋K������ direction �ɓn��
        Vector2 direction = new Vector2(x, y).normalized;
        // �ړ���������ƃX�s�[�h��������
        // Rigidbody2D �R���|�[�l���g�� velocity �ɕ����ƈړ����x���|�����l��n��
        rb.velocity = direction * speed;
    }

    // �e�̔��ˏ����i�R���[�`���j
    IEnumerator Shot()
    {
        while (true)
        {
            // �e���v���C���[�Ɠ����ʒu/�p�x�ō쐬
            Instantiate(bullet, transform.position, transform.rotation);
            // 0.05�b�҂�
            yield return new WaitForSeconds(0.05f);
        }
    }
}