using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordmanAttack : MonoBehaviour
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
     ct_atack2,
     ct_atack3,
     ct_atack4;

    private bool slashAble = true;
    private bool thrustAble = true;
    private bool chargeslashAble = true;
    private bool wallbreakAble = true;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerControl pcon = GetComponent<PlayerControl>();
        anim = GetComponent<Animator>();
        //swordCollider = GameObject.Find("swordnonamae").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
        //PÇâüÇ∑Ç∆éaåÇ
        if (Input.GetKeyDown(KeyCode.P) && slashAble)
        {
            
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var swordman_judge = playerControl.atack_judge;
            if (swordman_judge == 1)
            {
                anim.SetTrigger("Slash");
                animSword.SetTrigger("Slash2");
                swordmanRig.SetTrigger("SwordAtack1");
                //GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Swordsman;
                //GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
                StartCoroutine(Atack1());
            }

            //slashable = false;
        }

        //LÇâüÇ∑Ç∆ìÀÇ´
        if (Input.GetKeyDown(KeyCode.L) && thrustAble)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var swordman_judge = playerControl.atack_judge;
            if (swordman_judge == 1)
            {
                anim.SetTrigger("Thrust");
                animSword.SetTrigger("Thrust2");
                swordmanRig.SetTrigger("SwordAtack2");
                StartCoroutine(Atack2());
            }
        }

        //OÇâüÇ∑Ç∆ÇΩÇﬂêÿÇË
        if (Input.GetKeyDown(KeyCode.O) && chargeslashAble)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var swordman_judge = playerControl.atack_judge;
            if (swordman_judge == 1)
            {
                anim.SetTrigger("ChargeSlash");
                animSword.SetTrigger("ChargeSlash2");
                StartCoroutine(Atack3());
            }
        }

        //XÇâüÇ∑Ç∆ï«îjâÛ(ì¡éÍçUåÇ)
        if(Input.GetKeyDown(KeyCode.J) && wallbreakAble)
        {
            PlayerControl playerContorol = GetComponent<PlayerControl>();
            var swordman_judge = playerContorol.atack_judge;
            if(swordman_judge == 1)
            {
                sword.tag = "WallBreak";
                anim.SetTrigger("WallBreak");
                animSword.SetTrigger("WallBreak2");
                swordmanRig.SetTrigger("SwordSpAtack");
                StartCoroutine("TagReset");
                StartCoroutine(Atack4());
            }
        }

        //----ÉRÉìÉgÉçÅ[ÉâÅ[ëÄçÏ----
        //éaåÇ
        if (Input.GetKeyDown("joystick button 2") && slashAble && GameManagement.Instance.Atk ==GameManagement.AtkID.Atk1)
        {
            XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
            var swordman_judge = xboxPlayerContorol.atack_judge_con;
            if (swordman_judge == 1)
            {
                anim.SetBool("Slash", true);
                animSword.SetTrigger("Slash2");
                swordmanRig.SetTrigger("SwordAtack1");
                //GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Swordsman;
                //GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
                StartCoroutine(Atack1());
            }

            //slashable = false;
        }
        
        //ìÀÇ´
        if (Input.GetKeyDown("joystick button 2") && thrustAble &&GameManagement.Instance.Atk == GameManagement.AtkID.Atk2)
        {
            XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
            var swordman_judge = xboxPlayerContorol.atack_judge_con;
            if (swordman_judge == 1)
            {
                anim.SetTrigger("Thrust");
                animSword.SetTrigger("Thrust2");
                swordmanRig.SetTrigger("SwordAtack2");
                StartCoroutine(Atack2());
            }
        }

        //ÇΩÇﬂêÿÇË
        if (Input.GetKeyDown("joystick button 2") && chargeslashAble && GameManagement.Instance.Atk == GameManagement.AtkID.Atk3)
        {
            XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
            var swordman_judge = xboxPlayerContorol.atack_judge_con;
            if (swordman_judge == 1)
            {
                anim.SetTrigger("ChargeSlash");
                animSword.SetTrigger("ChargeSlash2");
                
                StartCoroutine(Atack3());
            }
        }
        //Ç∆ÇËÇ†Ç¶Ç∏îpé~
        ////ï«îjâÛ(ì¡éÍçUåÇ)
        //if (Input.GetKeyDown("joystick button 2") && wallbreakAble)
        //{
        //    XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
        //    var swordman_judge = xboxPlayerContorol.atack_judge_con;
        //    if (swordman_judge == 1)
        //    {
        //        sword.tag = "WallBreak";
        //        anim.SetTrigger("WallBreak");
        //        animSword.SetTrigger("WallBreak2");
        //        swordmanRig.SetTrigger("SwordSpAtack");
        //        StartCoroutine("TagReset");
        //        StartCoroutine(Atack4());
        //    }
        //}
    }
    private IEnumerator TagReset()
    {
        yield return  new WaitForSeconds(1f);
        sword.tag = "Sword";
    }
    IEnumerator Atack1()
    {
        yield return new WaitForSeconds(ct_atack1);
        XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
        PlayerControl playerContorol = GetComponent<PlayerControl>();
        xboxPlayerContorol.xatacking = false;
        playerContorol.atacking = false;
        slashAble = true;
    }
    IEnumerator Atack2()
    {
        yield return new WaitForSeconds(ct_atack2);
        XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
        PlayerControl playerContorol = GetComponent<PlayerControl>();
        xboxPlayerContorol.xatacking = false;
        playerContorol.atacking = false;
        thrustAble = true;
    }
    IEnumerator Atack3()
    {
        yield return new WaitForSeconds(ct_atack3);
        XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
        PlayerControl playerContorol = GetComponent<PlayerControl>();
        xboxPlayerContorol.xatacking = false;
        playerContorol.atacking = false;
        chargeslashAble = true;
    }
    IEnumerator Atack4()
    {
        yield return new WaitForSeconds(ct_atack4);
        XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
        PlayerControl playerContorol = GetComponent<PlayerControl>();
        xboxPlayerContorol.xatacking = false;
        playerContorol.atacking = false;
        wallbreakAble = true;
    }
}

//éaåÇÅAìÀÇ´ÅAÇΩÇﬂêÿÇË