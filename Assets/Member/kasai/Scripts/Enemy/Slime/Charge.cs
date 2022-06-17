using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    public int atk;
    private bool _hit = false;
    private void OnEnable()
    {
        StartCoroutine(ChargeAtk());
    }

    IEnumerator ChargeAtk()
    {
        yield return new WaitForSeconds(1.0f);
        if (_hit)
        {
            GameManagement.Instance.PlayerDamage(atk);//‘Ì—Í‚ðŒ¸‚ç‚·
            //se‚ð‚È‚ç‚·
        }
        yield return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _hit = true;
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
