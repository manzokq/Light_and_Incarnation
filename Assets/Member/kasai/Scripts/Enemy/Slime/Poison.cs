using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public EnemyDate enemyDate;//EnemyDateから体力などの情報を呼んでくる
    float timer;
    int count=0;
    [SerializeField] private float randMin = 1.0f;//倍率の最小値
    [SerializeField] private float randMax = 1.0f;//倍率の最大値
    private float magnification = 0;//実際にかかる倍率
    private int poisonAtk; //magnification*atk
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer<1.0f)
        {
            //dot処理
            count += 1;
            magnification = Random.Range(randMin, randMax);//atk12~18 倍率min0.6max1.8を想定
            poisonAtk = (int)magnification * enemyDate.atk;
            //体力を減らす

            if (count>=5)
            {
                this.gameObject.SetActive(false);
            }
        }
        
    }
}
