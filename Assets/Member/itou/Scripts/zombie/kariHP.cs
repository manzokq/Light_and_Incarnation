using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kariHP : MonoBehaviour
{
    public Animator Anim;
    public EnemyDate enemyDate;//EnemyDate����̗͂Ȃǂ̏����Ă�ł���
    protected int Hp = 0;
    public int enemyHP;

    private void Start()
    {
        Hp = enemyDate.hp;
        enemyHP = Hp;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        // �Ԃ���������ɁuAttack�v�Ƃ����^�O�iTag�j�����Ă�����A
        //if (other.gameObject.CompareTag("Attack"))
        if (other.gameObject.CompareTag("Player"))
        {

            // �G��HP���v���C���[��atk���A����������
            //enemyHP -= playerstates.atk;

            enemyHP -= 1;

            // �G��HP���O�ɂȂ�����G�I�u�W�F�N�g��j�󂷂�B
            if (enemyHP == 0)
            {

                // �I�u�W�F�N�g��j�󂷂�
                Destroy(transform.root.gameObject);


            }

        }



        Debug.Log(enemyHP);
    }
}