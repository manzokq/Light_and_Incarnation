using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Arrow : MonoBehaviour
{
    private bool cooltime = true;
    [SerializeField]
    private int hp;
    [SerializeField]
    private Animator anim;
    //攻撃
    private int Boss_Archer_Atk1;
    private int Boss_Archer_Atk2;
    // Start is called before the first frame update
    void Start()
    {

        Boss_ boss = GetComponent<Boss_>();
        Boss_Archer_Atk1 = boss.Boss_Atk1;
        Boss_Archer_Atk2 = boss.Boss_Atk2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        GameManagement.Instance.PlayerDamage(Boss_Archer_Atk1);

        GameManagement.Instance.PlayerDamage(Boss_Archer_Atk2); 

        Debug.LogWarning("プレイヤーにダメージ");
        cooltime = false;
        StartCoroutine(CoolTime());
        GameManagement.Instance.PlayerAtk(hp);
        //anim.SetBool("changeArcher", false);
        //anim.SetBool("changeWitch", false);
        //anim.SetBool("changeSwordman", false);
        //anim.SetBool("changeIncarnation", false);
    }
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(1.0f);
        cooltime = true;

    }
}


