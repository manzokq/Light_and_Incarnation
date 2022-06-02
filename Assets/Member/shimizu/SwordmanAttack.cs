using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordmanAttack : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    Animator animSword;

    private bool slashAble = true;
    private bool thrustAble = true;
    private bool chargeslashAble = true;
    private float slashTime = 0;
    private float thrustTime = 0;
    private float chargeslashTime = 0;
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
        anim.SetBool("Slash", false);
        animSword.SetBool("Slash2", false);
        #region クールタイム処理(未実装)
        if (slashAble == false)
        {
            slashTime += Time.deltaTime;
            if(slashTime >= 2)
            {
                slashAble = true;
                slashTime = 0;
            }
        }
        if (thrustAble == false)
        {
            thrustTime += Time.deltaTime;
            if (thrustTime >= 5)
            {
                thrustAble = true;
                thrustTime = 0;
            }
        }
        if (chargeslashAble == false)
        {
            chargeslashTime += Time.deltaTime;
            if (chargeslashTime >= 10)
            {
                chargeslashAble = true;
                chargeslashTime = 0;
            }
        }
        #endregion
        GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
        //Pを押すと斬撃
        if (Input.GetKeyDown(KeyCode.P) && slashAble)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var swordman_judge = playerControl.changechara;
            if (swordman_judge == 2)
            {
                anim.SetBool("Slash", true);
                animSword.SetTrigger("Slash2");
                GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Swordsman;
                GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
            }

            //slashable = false;
        }

        //Lを押すと突き
        if (Input.GetKeyDown(KeyCode.L) && thrustAble)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var swordman_judge = playerControl.changechara;
            if (swordman_judge == 2)
            {
                anim.SetTrigger("Thrust");
                animSword.SetTrigger("Thrust2");
            }
        }

        //Oを押すとため切り
        if (Input.GetKeyDown(KeyCode.O) && chargeslashAble)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var swordman_judge = playerControl.changechara;
            if (swordman_judge == 2)
            {
                anim.SetTrigger("ChargeSlash");
                animSword.SetTrigger("ChargeSlash2");
            }
        }

        //----コントローラー操作----
        //斬撃
        if (Input.GetKeyDown("joystick button 1") && slashAble && GameManagement.Instance.Atk ==GameManagement.AtkID.Atk1)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var swordman_judge = playerControl.changechara;
            if (swordman_judge == 2)
            {
                anim.SetBool("Slash", true);
                animSword.SetTrigger("Slash2");
                GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Swordsman;
                GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
            }

            //slashable = false;
        }
        
        //突き
        if (Input.GetKeyDown("joystick button 1") && thrustAble &&GameManagement.Instance.Atk == GameManagement.AtkID.Atk2)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var swordman_judge = playerControl.changechara;
            if (swordman_judge == 2)
            {
                anim.SetTrigger("Thrust");
                animSword.SetTrigger("Thrust2");
            }
        }

        //ため切り
        if (Input.GetKeyDown("joystick button 1") && chargeslashAble && GameManagement.Instance.Atk == GameManagement.AtkID.Atk3)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var swordman_judge = playerControl.changechara;
            if (swordman_judge == 2)
            {
                anim.SetTrigger("ChargeSlash");
                animSword.SetTrigger("ChargeSlash2");
            }
        }
    }


}

//斬撃、突き、ため切り