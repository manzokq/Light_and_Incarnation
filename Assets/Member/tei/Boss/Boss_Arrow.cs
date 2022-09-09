using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Arrow : MonoBehaviour
{
    private bool cooltime = true;
    [SerializeField]
    private Animator anim;
    //攻撃
    private int Boss_Archer_Atk1;
    private int Boss_Archer_Atk2;

    private int Atk_;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Boss_ boss = GetComponent<Boss_>();
        Boss_Archer_Atk1 = boss.Boss_Atk1;
        Boss_Archer_Atk2 = boss.Boss_Atk2;
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {if (collider2D.gameObject.CompareTag("Player"))
        {
            Boss_Bowman boss_Sword = GetComponent<Boss_Bowman>();
            Atk_ = boss_Sword.Atk_Bowman;
            if (Atk_ == 1)
            {
                GameManagement.Instance.PlayerDamage(Boss_Archer_Atk1);
            }

            if (Atk_ == 2)
            {
                GameManagement.Instance.PlayerDamage(Boss_Archer_Atk2);
            }

            Debug.LogWarning("プレイヤーにダメージ");
            cooltime = false;
            StartCoroutine(CoolTime());
            //hp = GameManagement.Instance.PlayerAtk(hp);
            //anim.SetBool("changeArcher", false);
            //anim.SetBool("changeWitch", false);
            //anim.SetBool("changeSwordman", false);
            //anim.SetBool("changeIncarnation", false);
        }
    }
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(1.0f);
        cooltime = true;

    }
}


