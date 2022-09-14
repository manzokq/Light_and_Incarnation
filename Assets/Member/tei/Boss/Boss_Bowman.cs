using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Bowman : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    Animator archerRig;
    [SerializeField]
    Animator animArcher;
    [SerializeField]
    GameObject arrow;
    [SerializeField]
    float ct_atack1,
    ct_atack2;

    private bool arrowAble = true;
    private bool firearrowAble = true;

    //çUåÇêßå‰
    //çUåÇëIë
    private float Boss_random_Atk_Bowman = 0;

    //ÉNÅ[ÉãÉ^ÉCÉÄóp
    private float Boss_Cool_time = 0;
    [SerializeField, Header("çUåÇÉNÅ[ÉãÉ^ÉCÉÄ")]
    private float Boss_Atk_time = 2;

    //çUåÇ
    private int Boss_Archer_Atk1;
    private int Boss_Archer_Atk2;

    public int Atk_Bowman;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        Boss_ boss = GetComponent<Boss_>();
        Boss_Archer_Atk1 = boss.Boss_Atk1;
        Boss_Archer_Atk2 = boss.Boss_Atk2;
    }

    // Update is called once per frame
    void Update()
    {
        Boss_ Boss_Contorol = GetComponent<Boss_>();
        if (Boss_Contorol.Boss_atacking_Archer)
        {
            Boss_Cool_time += Time.deltaTime;
            if (Boss_Atk_time <= Boss_Cool_time)
            {
                Boss_Contorol.Boss_atacking_Archer = false;
                Debug.Log("çUåÇíäëI");
                Boss_Cool_time = 0;
                Boss_random_Atk_Bowman = Random.Range(1, 3);
                switch (Boss_random_Atk_Bowman)
                {
                    case 1:
                        Boss_Atk1();
                        Debug.Log("ã|çUåÇ1");
                        break;
                    case 2:
                        Boss_Atk2();
                        Debug.Log("ã|çUåÇ2");
                        break;
                }
            }
        }
    }

    public void Boss_Atk1()
    {
        if (arrowAble && GameManagement.Instance.Atk == GameManagement.AtkID.Atk1)
        {
            arrowAble = false;
            Boss_ Boss_Control = GetComponent<Boss_>();
            var archer_judge = Boss_Control.boss_atack_judge;
            if (archer_judge == 2)
            {
                Atk_Bowman = 1;
                anim.SetTrigger("Arrow");
                animArcher.SetTrigger("Arrow2");
                archerRig.SetTrigger("ArcherAtack1");
                //GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Swordsman;
                //GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
                StartCoroutine(Atack1());
            }
            //slashable = false;
        }
    }

    public void Boss_Atk2()
    {
        if (firearrowAble && GameManagement.Instance.Atk == GameManagement.AtkID.Atk2)
        {
            firearrowAble = false;
            Boss_ Boss_Control = GetComponent<Boss_>();
            var archer_judge = Boss_Control.boss_atack_judge;
            if (archer_judge == 2)
            {
                Atk_Bowman = 2;
                anim.SetTrigger("FireArrow");
                animArcher.SetTrigger("FireArrow2");
                archerRig.SetTrigger("ArcherAtack2");
                //GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Bowman;
                //.Instance.Atk = GameManagement.AtkID.Atk1;
                StartCoroutine(Atack2());
            }
        }
    }

    IEnumerator Atack1()
    {
        yield return new WaitForSeconds(ct_atack1);
        Boss_ Boss = GetComponent<Boss_>();
        GameManagement.Instance.PlayerDamage(Boss_Archer_Atk1);
        Boss.Boss_atacking_Archer = true;
        arrowAble = true;
        Atk_Bowman = 0;
    }

    IEnumerator Atack2()
    {
        yield return new WaitForSeconds(ct_atack2);
        Boss_ Boss_Contorol = GetComponent<Boss_>();
        GameManagement.Instance.PlayerDamage(Boss_Archer_Atk2);
        Boss_Contorol.Boss_atacking_Archer = true;
        firearrowAble = true;
        Atk_Bowman = 0;
    }
}
