using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToEnemy : MonoBehaviour
{
    private bool cooltime = true;
    [SerializeField]
    private int hp;
    [SerializeField]
    private Animator anim;
    //public int playeratk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Enemy") && cooltime)
        {
            cooltime = false;
            StartCoroutine(CoolTime());
            GameManagement.Instance.PlayerAtk(hp);
            anim.SetBool("changeArcher", false);
            anim.SetBool("changeWitch", false);
            anim.SetBool("changeSwordman", false);
            anim.SetBool("changeIncarnation", false);
        }

    }

    

    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(1.0f);
        cooltime = true;

    }
}
