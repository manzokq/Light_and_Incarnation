using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Sword : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    Animator swordmanRig;
    [SerializeField]
    Animator animSword;
    [SerializeField]
    GameObject sword;
    [SerializeField]
    private float ct_atack1,
     ct_atack2;

    private bool slashAble = true;
    private bool thrustAble = true;

    //çUåÇêßå‰
    //çUåÇëIë
    private float Boss_random_Atk_Sword = 0;

    //ÉNÅ[ÉãÉ^ÉCÉÄóp
    private float Boss_Cool_time = 0;
    [SerializeField, Header("çUåÇÉNÅ[ÉãÉ^ÉCÉÄ")]
    private int Boss_Atk_time = 1;

    //çUåÇ
    private int Boss_Sword_Atk1;
    private int Boss_Sword_Atk2;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        Boss_ boss = GetComponent<Boss_>();
        Boss_Sword_Atk1 = boss.Boss_Atk1;
        Boss_Sword_Atk2 = boss.Boss_Atk2;
    }

    // Update is called once per frame
    void Update()
    {
        Boss_ Boss_Contorol = GetComponent<Boss_>();
        if (Boss_Contorol.Boss_atacking_Sword)
        {
            Boss_Cool_time += Time.deltaTime;
            if (Boss_Atk_time <= Boss_Cool_time)
            {
                Debug.Log("çUåÇíäëI");
                Boss_Cool_time = 0;
                Boss_random_Atk_Sword = Random.Range(1, 3);
                switch (Boss_random_Atk_Sword)
                {
                    case 1:
                        Boss_Atk1();
                        Debug.Log("åïçUåÇ1");
                        break;
                    case 2:
                        Boss_Atk2();
                        Debug.Log("åïçUåÇ2");
                        break;
                }
            }
        }
    }

    //éaåÇ
    public void Boss_Atk1()
    {
        if (slashAble && GameManagement.Instance.Atk == GameManagement.AtkID.Atk1)
        {
            slashAble = false;
            Boss_ Boss_Control = GetComponent<Boss_>();
            var swordman_judge = Boss_Control.boss_atack_judge;
            if (swordman_judge == 1)
            {
                anim.SetBool("Slash",true);
                animSword.SetTrigger("Slash2");
                swordmanRig.SetTrigger("SwordAtack1");
                //GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Swordsman;
                //GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
                StartCoroutine(Atack1());
            }
            //slashable = false;
        }
    }

    //ìÀÇ´
    public void Boss_Atk2()
    {
        if (thrustAble && GameManagement.Instance.Atk == GameManagement.AtkID.Atk2)
        {
            thrustAble = false;
            Boss_ Boss_Control = GetComponent<Boss_>();
            var swordman_judge = Boss_Control.boss_atack_judge;
            if (swordman_judge == 1)
            {
                anim.SetTrigger("Thrust");
                animSword.SetTrigger("Thrust2");
                swordmanRig.SetTrigger("SwordAtack2");
                StartCoroutine(Atack2());
            }
        }
    }


    IEnumerator Atack1()
    {
        yield return new WaitForSeconds(ct_atack1);
        Boss_ Boss = GetComponent<Boss_>();
        GameManagement.Instance.PlayerDamage(Boss_Sword_Atk1);
        Boss.Boss_atacking_Sword = true;
        slashAble = true;
    }

    IEnumerator Atack2()
    {
        yield return new WaitForSeconds(ct_atack2);
        Boss_ Boss_Contorol = GetComponent<Boss_>();
        GameManagement.Instance.PlayerDamage(Boss_Sword_Atk2);
        Boss_Contorol.Boss_atacking_Sword = true;
        thrustAble = true;
    }
}

