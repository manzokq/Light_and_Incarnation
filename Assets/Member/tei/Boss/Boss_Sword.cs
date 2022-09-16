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
    private float Boss_Atk_time = 1;

    public int Atk_Sword;

    public static Boss_Sword Blade;
    public void Awake()
    {
        if (Blade == null)
        {
            Blade = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        Boss_ Boss_Contorol = GetComponent<Boss_>();
        Debug.LogError(Boss_Contorol);
        Debug.LogError(Boss_Contorol.Boss_atacking_Sword);
        if (Boss_Contorol.Boss_atacking_Sword)
        {
            Boss_Cool_time += Time.deltaTime;
            if (Boss_Atk_time <= Boss_Cool_time && Boss_Contorol.Boss_Sword_Attack)
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
        if (slashAble)
        {
            slashAble = false;
            Boss_ Boss_Control = GetComponent<Boss_>();
            var swordman_judge = Boss_Control.boss_atack_judge;
            if (swordman_judge == 1)
            {
                Atk_Sword = 1;
                anim.SetBool("Slash",true);
                animSword.SetTrigger("Slash2");
                swordmanRig.SetTrigger("SwordAtack1");
                //StartCoroutine(Atack1());
                slashAble = true;
            }
        }
    }

    //ìÀÇ´
    public void Boss_Atk2()
    {
        if (thrustAble)
        {
            thrustAble = false;
            Boss_ Boss_Control = GetComponent<Boss_>();
            var swordman_judge = Boss_Control.boss_atack_judge;
            if (swordman_judge == 1)
            {
                Atk_Sword = 2;
                anim.SetTrigger("Thrust");
                animSword.SetTrigger("Thrust2");
                swordmanRig.SetTrigger("SwordAtack2");
                //StartCoroutine(Atack2());
                thrustAble = true;
            }
        }
    }
    public void Atc_()
    {
        slashAble = true;
        thrustAble = true;
        Atk_Sword = 0;
    }

    //IEnumerator Atack1()
    //{
    //    yield return new WaitForSeconds(ct_atack1);
    //    Boss_ Boss = GetComponent<Boss_>();
    //    GameManagement.Instance.PlayerDamage(Boss_Sword_Atk1);
    //    Boss.Boss_atacking_Sword = true;
    //    slashAble = true;
    //    Atk_Sword = 0;
    //}

    //IEnumerator Atack2()
    //{
    //    yield return new WaitForSeconds(ct_atack2);
    //    Boss_ Boss_Contorol = GetComponent<Boss_>();
    //    GameManagement.Instance.PlayerDamage(Boss_Sword_Atk2);
    //    Boss_Contorol.Boss_atacking_Sword = true;
    //    thrustAble = true;
    //    Atk_Sword = 0;
    //}
}

