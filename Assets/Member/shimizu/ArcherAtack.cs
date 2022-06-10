using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAtack : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    Animator animArcher;

    private bool arrowAble = true;
    private bool firearrowAble = true;
    private bool doublearrowAble = true;
    private bool longbowAble = true;
    private float arrowTime = 0;
    private float firearrowTime = 0;
    private float doublearrowTime = 0;
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
        anim.SetBool("Arrow", false);
        animArcher.SetBool("Arrow2", false);
        #region ÉNÅ[ÉãÉ^ÉCÉÄèàóù(ñ¢é¿ëï)
        if (arrowAble == false)
        {
            arrowTime += Time.deltaTime;
            if (arrowTime >= 2)
            {
                arrowAble = true;
                arrowTime = 0;
            }
        }
        if (firearrowAble == false)
        {
            firearrowTime += Time.deltaTime;
            if (firearrowTime >= 5)
            {
                firearrowAble = true;
                firearrowTime = 0;
            }
        }
        if (doublearrowAble == false)
        {
            doublearrowTime += Time.deltaTime;
            if (doublearrowTime >= 10)
            {
                doublearrowAble = true;
                doublearrowTime = 0;
            }
        }
        #endregion
        GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
        //PÇâüÇ∑Ç∆í èÌã|çUåÇ
        if (Input.GetKeyDown(KeyCode.P) && arrowAble)
        {

            PlayerControl playerControl = GetComponent<PlayerControl>();
            var swordman_judge = playerControl.changechara;
            if (swordman_judge == 3)
            {
                anim.SetBool("Arrow", true);
                animArcher.SetTrigger("Arrow2");
                GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Swordsman;
                GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
            }

            //slashable = false;
        }

        //LÇâüÇ∑Ç∆âŒñÓ
        if (Input.GetKeyDown(KeyCode.L) && firearrowAble)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var swordman_judge = playerControl.changechara;
            if (swordman_judge == 3)
            {
                anim.SetTrigger("FireArrow");
                animArcher.SetTrigger("FireArrow2");
            }
        }

        //OÇâüÇ∑Ç∆ìÒñÓ
        if (Input.GetKeyDown(KeyCode.O) && doublearrowAble)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var swordman_judge = playerControl.changechara;
            if (swordman_judge == 3)
            {
                anim.SetTrigger("DoubleArrow");
                animArcher.SetTrigger("DoubleArrow2");
            }
        }

        //XÇâüÇ∑Ç∆(ì¡éÍçUåÇ)
        if (Input.GetKeyDown(KeyCode.J) && longbowAble)
        {
            PlayerControl playerContorol = GetComponent<PlayerControl>();
            var swordman_judge = playerContorol.changechara;
            if (swordman_judge == 3)
            {
                anim.SetTrigger("LongBow");
                animArcher.SetTrigger("LongBow2");
            }
        }

        //----ÉRÉìÉgÉçÅ[ÉâÅ[ëÄçÏ----
        //í èÌã|çUåÇ
        if (Input.GetKeyDown("joystick button 1") && arrowAble && GameManagement.Instance.Atk == GameManagement.AtkID.Atk1)
        {
            XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
            var swordman_judge = xboxPlayerContorol.changechara;
            if (swordman_judge == 3)
            {
                anim.SetBool("Arrow", true);
                animArcher.SetTrigger("Arrow2");
                GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Swordsman;
                GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
            }

            //slashable = false;
        }

        //âŒñÓ
        if (Input.GetKeyDown("joystick button 1") && firearrowAble && GameManagement.Instance.Atk == GameManagement.AtkID.Atk2)
        {
            XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
            var swordman_judge = xboxPlayerContorol.changechara;
            if (swordman_judge == 3)
            {
                anim.SetTrigger("FireArrow");
                animArcher.SetTrigger("FireArrow2");
            }
        }

        //ìÒñÓ
        if (Input.GetKeyDown("joystick button 1") && doublearrowAble && GameManagement.Instance.Atk == GameManagement.AtkID.Atk3)
        {
            XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
            var swordman_judge = xboxPlayerContorol.changechara;
            if (swordman_judge == 3)
            {
                anim.SetTrigger("DoubleArrow");
                animArcher.SetTrigger("DoubleArrow2");
            }
        }

        //(ì¡éÍçUåÇ)
        if (Input.GetKeyDown("joystick button 2") && longbowAble)
        {
            XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
            var swordman_judge = xboxPlayerContorol.changechara;
            if (swordman_judge == 2)
            {
                anim.SetTrigger("LongBow");
                animArcher.SetTrigger("LongBow2");
            }
        }
    }
}
