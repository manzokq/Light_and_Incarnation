using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    public int atk=0;
    private float waitTime = 1.0f;
    private bool _hit = false;//ここがtrueの間ダメージ判定をつける
    private void OnEnable()
    {
        StartCoroutine(ChargeAtk());
        
    }

    IEnumerator ChargeAtk()
    {
        yield return new WaitForSeconds(waitTime);
        if (_hit)
        {
            GameManagement.Instance.PlayerDamage(atk);//体力を減らす
            //SEを呼び出す
            SEManager.Instance.Sound(SEManager.SoundState.Sound5);
        }
        this.gameObject.SetActive(false);
        yield return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _hit = true;
            //Debug.Log(atk+"ダメージ");
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
