using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : Enemy
{
    //public EnemyDate enemyDate;//EnemyDate����̗͂Ȃǂ̏����Ă�ł���

    [SerializeField] private float _randMin = 1.0f;//�{���̍ŏ��l
    [SerializeField] private float _randMax = 1.0f;//�{���̍ő�l
    private float _magnification = 0;//���ۂɂ�����{��
    private int _poisonAtk; //magnification*atk
    [SerializeField] private int _repeat = 0;
    private bool _hit = false;
    //void Update()
    //{

    //}
    private void Start()
    {
        StartCoroutine(PoisonIns());
    }

    public IEnumerator PoisonIns()//���܂ꂽ���̏���
    {
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < _repeat; i++) 
        {
            //dot����
            _magnification = Random.Range(_randMin, _randMax);//atk12~18 �{��min0.6max1.8��z��
            _poisonAtk = (int)_magnification * Atk1;
            if(_hit)
            {
                GameManagement.Instance.PlayerDamage(_poisonAtk);//�̗͂����炷
            }
            
            yield return new WaitForSeconds(1.0f);
        }
        
       this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _hit= true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _hit = false;
        }
    }
}
