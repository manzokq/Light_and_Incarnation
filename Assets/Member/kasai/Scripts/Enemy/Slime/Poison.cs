using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public EnemyDate enemyDate;//EnemyDate����̗͂Ȃǂ̏����Ă�ł���
    float timer;
    int count=0;
    [SerializeField] private float randMin = 1.0f;//�{���̍ŏ��l
    [SerializeField] private float randMax = 1.0f;//�{���̍ő�l
    private float magnification = 0;//���ۂɂ�����{��
    private int poisonAtk; //magnification*atk
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer<1.0f)
        {
            //dot����
            count += 1;
            magnification = Random.Range(randMin, randMax);//atk12~18 �{��min0.6max1.8��z��
            poisonAtk = (int)magnification * enemyDate.atk;
            GameManagement.Instance.PlayerDamage(poisonAtk);
            //�̗͂����炷

            if (count>=5)
            {
                this.gameObject.SetActive(false);
            }
        }
        
    }
}
