using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Bowman : MonoBehaviour
{
    private Animator boss_anim_Bowman;

    [SerializeField]
    Animator boss_animBowman;
    //[SerializeField]
    //GameObject boss_Bowman;
    [SerializeField]
    private float boss_ct_atack1,
     boss_ct_atack2;

    private bool boss_arrowAble = true;
    private bool boss_firearrowAble = true;

    //çUåÇêßå‰
    //çUåÇëIë
    private float Boss_random_Atk_Bowman = 0;

    //ÉNÅ[ÉãÉ^ÉCÉÄóp
    private float Boss_Cool_time = 0;
    [SerializeField, Header("çUåÇÉNÅ[ÉãÉ^ÉCÉÄ")]
    private int Boss_Atk_time = 2;


    // Start is called before the first frame update
    void Start()
    {
        boss_anim_Bowman = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Boss_ Boss_Contorol = GetComponent<Boss_>();
        if (Boss_Contorol.Boss_atacking)
        {
            Boss_Contorol.Boss_atacking = false;
            Debug.Log("çUåÇíäëI");
            Boss_Cool_time += Time.deltaTime;
            if (Boss_Atk_time <= Boss_Cool_time)
            {
                Boss_Cool_time = 0;
                Boss_random_Atk_Bowman = Random.Range(1, 3);
                switch (Boss_random_Atk_Bowman)
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

    public void Boss_Atk1()
    {
        GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
        //PÇâüÇ∑Ç∆í èÌã|çUåÇ
        if (boss_arrowAble && GameManagement.Instance.Atk == GameManagement.AtkID.Atk1)
        {
            boss_arrowAble = false;
            Boss_ Boss_Control = GetComponent<Boss_>();
            var swordman_judge = Boss_Control.boss_atack_judge;
            if (swordman_judge == 1)
            {
                boss_anim_Bowman.SetTrigger("Arrow");
                boss_animBowman.SetTrigger("Arrow2");
                //GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Bowman;
                //.Instance.Atk = GameManagement.AtkID.Atk1;
                StartCoroutine(Atack1());
            }
            //slashable = false;
        }
    }

    public void Boss_Atk2()
    {
        if (boss_firearrowAble && GameManagement.Instance.Atk == GameManagement.AtkID.Atk2)
        {
            boss_firearrowAble = false;
            Boss_ Boss_Control = GetComponent<Boss_>();
            var swordman_judge = Boss_Control.boss_atack_judge;
            if (swordman_judge == 1)
            {
                boss_anim_Bowman.SetTrigger("Thrust");
                boss_animBowman.SetTrigger("Thrust2");
                //GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Bowman;
                //.Instance.Atk = GameManagement.AtkID.Atk1;
                StartCoroutine(Atack2());
            }
        }
    }

    private IEnumerator TagReset()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.tag = "Arrow";
    }
    IEnumerator Atack1()
    {
        yield return new WaitForSeconds(boss_ct_atack1);
        Boss_ Boss = GetComponent<Boss_>();
        Boss.Boss_atacking = true;
        boss_arrowAble = true;
    }

    IEnumerator Atack2()
    {
        yield return new WaitForSeconds(boss_ct_atack2);
        Boss_ Boss_Contorol = GetComponent<Boss_>();
        Boss_Contorol.Boss_atacking = true;
        boss_firearrowAble = true;
    }
}
