using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    //public EnemyDate enemyDate;//EnemyDate‚©‚ç‘Ì—Í‚È‚Ç‚Ìî•ñ‚ğŒÄ‚ñ‚Å‚­‚é

    [SerializeField] private float _randMin = 1.0f;//”{—¦‚ÌÅ¬’l
    [SerializeField] private float _randMax = 1.0f;//”{—¦‚ÌÅ‘å’l
    private float _magnification = 0;//ÀÛ‚É‚©‚©‚é”{—¦
    private int _poisonAtk; //magnification*atk
    [SerializeField] private int _repeat = 0;
    private bool _hit = false;

    public int atk=1;
    private void OnEnable()
    {
        StartCoroutine(PoisonIns());
    }
    public IEnumerator PoisonIns()
    {
        for (int i = 0; i < _repeat; i++)
        {
            //dotˆ—
            _magnification = Random.Range(_randMin, _randMax);//atk12~18 ”{—¦min0.6max1.8‚ğ‘z’è
            _poisonAtk = (int)_magnification * atk;
            if (_hit)
            {

                GameManagement.Instance.PlayerDamage(_poisonAtk);//‘Ì—Í‚ğŒ¸‚ç‚·
                
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
            Debug.Log(_poisonAtk + "ƒ_ƒ[ƒW");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _hit = false;
            Debug.Log("‚ ‚½‚Á‚Ä‚È‚¢‚æ");
        }
    }
}
