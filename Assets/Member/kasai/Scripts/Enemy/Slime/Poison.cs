using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    //public EnemyDate enemyDate;//EnemyDateから体力などの情報を呼んでくる

    [SerializeField] private float _randMin = 1.0f;//倍率の最小値
    [SerializeField] private float _randMax = 1.0f;//倍率の最大値
    private float _magnification = 0;//実際にかかる倍率
    private float _poisonAtk; //magnification*atk
    [SerializeField] private int _repeat = 0;//ダメージ処理の繰り返しの回数
    private bool _hit = false;//ここがtrueの間ダメージ判定をつける
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
            //dot処理
            _magnification = Random.Range(_randMin, _randMax);//atk12~18 倍率min0.6max1.8を想定
            _poisonAtk = _magnification * atk;
            _intPoison = (int)_poisonAtk;
            if (_hit)
            {
                //SEを呼び出す
                SEManager.Instance.Sound(SEManager.SoundState.Sound5);
                GameManagement.Instance.PlayerDamage(_intPoison);//体力を減らす
                
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
            //Debug.Log(_poisonAtk + "ダメージ");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _hit = false;
            //Debug.Log("あたってないよ");
        }
    }
}
