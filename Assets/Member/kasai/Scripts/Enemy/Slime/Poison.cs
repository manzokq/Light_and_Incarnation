using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : Enemy
{
    //public EnemyDate enemyDate;//EnemyDateから体力などの情報を呼んでくる

    [SerializeField] private float _randMin = 1.0f;//倍率の最小値
    [SerializeField] private float _randMax = 1.0f;//倍率の最大値
    private float _magnification = 0;//実際にかかる倍率
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

    public IEnumerator PoisonIns()//踏まれた時の処理
    {
        yield return new WaitForSeconds(1.0f);
        for (int i = 0; i < _repeat; i++) 
        {
            //dot処理
            _magnification = Random.Range(_randMin, _randMax);//atk12~18 倍率min0.6max1.8を想定
            _poisonAtk = (int)_magnification * Atk1;
            if(_hit)
            {
                GameManagement.Instance.PlayerDamage(_poisonAtk);//体力を減らす
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
