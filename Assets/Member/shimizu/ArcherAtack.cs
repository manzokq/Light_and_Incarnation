using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAtack : MonoBehaviour
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
    ct_atack2,
    ct_atack3,
    ct_atack4;

    private bool arrowAble = true;
    private bool firearrowAble = true;
    private bool doublearrowAble = true;
    private bool longbowAble = true;

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
        //PÇâüÇ∑Ç∆í èÌã|çUåÇ
        if (Input.GetKeyDown(KeyCode.P) && arrowAble)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var archer_judge = playerControl.atack_judge;
            if (archer_judge == 2)
            {
                playerControl.atacking = true;
                anim.SetTrigger("Arrow");
                animArcher.SetTrigger("Arrow2");
                archerRig.SetTrigger("ArcherAtack1");
                //GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Bowman;
                //.Instance.Atk = GameManagement.AtkID.Atk1;
                StartCoroutine(Atack1());
            }
        }

        //LÇâüÇ∑Ç∆âŒñÓ
        if (Input.GetKeyDown(KeyCode.L) && firearrowAble)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var archer_judge = playerControl.atack_judge;
            if (archer_judge == 2)
            {
                playerControl.atacking = true;  
                anim.SetTrigger("FireArrow");
                animArcher.SetTrigger("FireArrow2");
                archerRig.SetTrigger("ArcherAtack2");
                //GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Bowman;
                //.Instance.Atk = GameManagement.AtkID.Atk1;
                StartCoroutine(Atack2());
            }
        }

        //OÇâüÇ∑Ç∆ìÒñÓ
        if (Input.GetKeyDown(KeyCode.O) && doublearrowAble)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var archer_judge = playerControl.atack_judge;
            if (archer_judge == 2)
            {
                playerControl.atacking = true;
                anim.SetTrigger("DoubleArrow");
                animArcher.SetTrigger("DoubleArrow2");
                StartCoroutine(Atack3());
            }
        }

        //XÇâüÇ∑Ç∆(ì¡éÍçUåÇ)
        if (Input.GetKeyDown(KeyCode.J) && longbowAble)
        {
            PlayerControl playerContorol = GetComponent<PlayerControl>();
            var archer_judge = playerContorol.atack_judge;
            if (archer_judge == 2)
            {
                playerContorol.atacking = true;
                arrow.tag = "LongBow";
                anim.SetTrigger("LongBow");
                animArcher.SetTrigger("LongBow2");
                archerRig.SetTrigger("ArcherSpAtack");
                StartCoroutine("TagReset");
                StartCoroutine(Atack4());
            }
        }
        //Debug.Log(GameManagement.Instance.Atk);
        //----ÉRÉìÉgÉçÅ[ÉâÅ[ëÄçÏ----
        //í èÌã|çUåÇ
        if (Input.GetKeyDown("joystick button 2") && arrowAble && GameManagement.Instance.Atk == GameManagement.AtkID.Atk1)
        {
            //Debug.Log("í èÌ");
            XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
            var archer_judge = xboxPlayerContorol.atack_judge_con;
            if (archer_judge == 2)
            {
                arrowAble = false;
                xboxPlayerContorol.xatacking = true;
                anim.SetBool("Arrow", true);
                animArcher.SetTrigger("Arrow2");
                archerRig.SetTrigger("ArcherAtack1");
                //GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Swordsman;
                //GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
                StartCoroutine(Atack1());
            }

            //slashable = false;
        }

        //âŒñÓ
        if (Input.GetKeyDown("joystick button 2") && firearrowAble && GameManagement.Instance.Atk == GameManagement.AtkID.Atk2)
        {
            XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
            var archer_judge = xboxPlayerContorol.atack_judge_con;
            if (archer_judge == 2)
            {
                xboxPlayerContorol.xatacking = true;
                anim.SetTrigger("FireArrow");
                animArcher.SetTrigger("FireArrow2");
                archerRig.SetTrigger("ArcherAtack2");
                StartCoroutine(Atack2());
            }
        }

        //ìÒñÓ
        if (Input.GetKeyDown("joystick button 2") && doublearrowAble && GameManagement.Instance.Atk == GameManagement.AtkID.Atk3)
        {
            XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
            var archer_judge = xboxPlayerContorol.atack_judge_con;
            if (archer_judge == 2)
            {
                xboxPlayerContorol.xatacking = true;
                anim.SetTrigger("DoubleArrow");
                animArcher.SetTrigger("DoubleArrow2");
                StartCoroutine(Atack3());
            }
        }

        //Ç∆ÇËÇ†Ç¶Ç∏
        ////(ì¡éÍçUåÇ)
        //if (Input.GetKeyDown("joystick button 2") && longbowAble)
        //{
        //    XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
        //    var archer_judge = xboxPlayerContorol.atack_judge_con;
        //    if (archer_judge == 2)
        //    {
        //        xboxPlayerContorol.xatacking = true;
        //        //Debug.Log("ì¡éÍçUåÇ");
        //        arrow.tag = "LongBow";
        //        anim.SetTrigger("LongBow");
        //        animArcher.SetTrigger("LongBow2");
        //        archerRig.SetTrigger("ArcherSpAtack");
        //        StartCoroutine("TagReset");
        //        StartCoroutine(Atack4());
        //    }
        //}
    }
    private IEnumerator TagReset()
    {
        yield return new WaitForSeconds(1f);
        arrow.tag = "Arrow";
    }
    IEnumerator Atack1()
    {
        yield return new WaitForSeconds(ct_atack1);
        XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
        PlayerControl playerContorol = GetComponent<PlayerControl>();
        xboxPlayerContorol.xatacking = false;
        playerContorol.atacking = false;
        arrowAble = true;
    }
    IEnumerator Atack2()
    {
        yield return new WaitForSeconds(ct_atack2);
        XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
        PlayerControl playerContorol = GetComponent<PlayerControl>();
        xboxPlayerContorol.xatacking = false;
        playerContorol.atacking = false;
        firearrowAble = true;
    }
    IEnumerator Atack3()
    {
        yield return new WaitForSeconds(ct_atack3);
        XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
        PlayerControl playerContorol = GetComponent<PlayerControl>();
        xboxPlayerContorol.xatacking = false;
        playerContorol.atacking = false;
        doublearrowAble = true;
    }
    IEnumerator Atack4()
    {
        yield return new WaitForSeconds(ct_atack4);
        XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
        PlayerControl playerContorol = GetComponent<PlayerControl>();
        xboxPlayerContorol.xatacking = false;
        playerContorol.atacking = false;
        longbowAble = true;
    }
}
//í èÌçUåÇÅAâŒñÓÅAìÒñÓ
