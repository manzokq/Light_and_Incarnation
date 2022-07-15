using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Sword : MonoBehaviour
{
    private Animator boss_anim_sword;

    [SerializeField]
    Animator boss_animSword;
    //[SerializeField]
    //GameObject boss_sword;
    [SerializeField]
    private float boss_ct_atack1_Sword,
     boss_ct_atack2_Sword;

    private bool boss_slashAble = true;
    private bool boss_thrustAble = true;

    //攻撃制御
    //攻撃選択
    private float Boss_random_Atk_Sword = 0;

    //クールタイム用
    private float Boss_Cool_time = 0;
    [SerializeField, Header("攻撃クールタイム")]
    private int Boss_Atk_time = 2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Boss_ Boss_Contorol = GetComponent<Boss_>();
        if (Boss_Contorol.Boss_atacking)
        {
            Boss_Contorol.Boss_atacking = false;
            Debug.Log("攻撃抽選");
            Boss_Cool_time += Time.deltaTime;
            if (Boss_Atk_time <= Boss_Cool_time)
            {
                Boss_Cool_time = 0;
                Boss_random_Atk_Sword = Random.Range(1, 3);
                switch (Boss_random_Atk_Sword)
                {
                    case 1:
                        Boss_Atk1();
                        break;
                    case 2:
                        Boss_Atk2();
                        break;
                }
            }
        }
    }

    //斬撃
    public void Boss_Atk1()
    {
        if (boss_slashAble && GameManagement.Instance.Atk == GameManagement.AtkID.Atk1)
        {
            boss_slashAble = false;
            Boss_ Boss_Control = GetComponent<Boss_>();
            var swordman_judge = Boss_Control.boss_atack_judge;
            if (swordman_judge == 1)
            {
                boss_anim_sword.SetTrigger("Slash");
                boss_animSword.SetTrigger("Slash2");
                //GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Swordsman;
                //GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
                StartCoroutine(Atack1());
            }
            //slashable = false;
        }
    }

    //突き
    public void Boss_Atk2()
    {
        if (boss_thrustAble && GameManagement.Instance.Atk == GameManagement.AtkID.Atk2)
        {
            boss_thrustAble = false;
            Boss_ Boss_Control = GetComponent<Boss_>();
            var swordman_judge = Boss_Control.boss_atack_judge;
            if (swordman_judge == 1)
            {
                boss_anim_sword.SetTrigger("Thrust");
                boss_animSword.SetTrigger("Thrust2");
                StartCoroutine(Atack2());
            }
        }
    }
    private IEnumerator TagReset()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.tag = "Sword";
    }

    IEnumerator Atack1()
    {
        yield return new WaitForSeconds(boss_ct_atack1_Sword);
        Boss_ Boss = GetComponent<Boss_>();
        Boss.Boss_atacking = true;
        boss_slashAble = true;
    }

    IEnumerator Atack2()
    {
        yield return new WaitForSeconds(boss_ct_atack2_Sword);
        Boss_ Boss_Contorol = GetComponent<Boss_>();
        Boss_Contorol.Boss_atacking = true;
        boss_thrustAble = true;
    }
}

