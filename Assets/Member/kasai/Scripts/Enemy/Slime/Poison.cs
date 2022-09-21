using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    //public EnemyDate enemyDate;//EnemyDate����̗͂Ȃǂ̏����Ă�ł���

    [SerializeField] private float _randMin = 1.0f;//�{���̍ŏ��l
    [SerializeField] private float _randMax = 1.0f;//�{���̍ő�l
    private float _magnification = 0;//���ۂɂ�����{��
    private float _poisonAtk; //magnification*atk
    [SerializeField] private int _repeat = 0;//�_���[�W�����̌J��Ԃ��̉�
    private bool _hit = false;//������true�̊ԃ_���[�W���������
    private int _intPoison=0;

    public int atk=0;
    private void OnEnable()
    {
        StartCoroutine(PoisonIns());
        //Debug.Log(atk);
    }
    public IEnumerator PoisonIns()
    {
        for (int i = 0; i < _repeat; i++)
        {
            //dot����
            _magnification = Random.Range(_randMin, _randMax);//atk12~18 �{��min0.6max1.8��z��
            _poisonAtk = _magnification * atk;
            _intPoison = (int)_poisonAtk;
            if (_hit)
            {
                //SE���Ăяo��
                SEManager.Instance.Sound(SEManager.SoundState.Sound5);
                GameManagement.Instance.PlayerDamage(_intPoison);//�̗͂����炷
                
            }
            
            //Debug.Log(_poisonAtk);
            yield return new WaitForSeconds(1.0f);
        }

        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _hit = true;
            //Debug.Log(_poisonAtk + "�_���[�W");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _hit = false;
            //Debug.Log("�������ĂȂ���");
        }
    }
}
