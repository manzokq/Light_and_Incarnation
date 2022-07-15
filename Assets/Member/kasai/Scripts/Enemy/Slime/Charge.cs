using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    public int atk=0;
    private float waitTime = 1.0f;
    private bool _hit = false;
    private void OnEnable()
    {
        StartCoroutine(ChargeAtk());
        
    }

    IEnumerator ChargeAtk()
    {
        yield return new WaitForSeconds(waitTime);
        if (_hit)
        {
            GameManagement.Instance.PlayerDamage(atk);//�̗͂����炷
            //se���Ȃ炷
        }
        this.gameObject.SetActive(false);
        yield return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _hit = true;
            //Debug.Log(atk+"�_���[�W");
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
