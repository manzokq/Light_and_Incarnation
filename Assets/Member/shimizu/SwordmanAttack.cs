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
        
        anim = GetComponent<Animator>();
        //swordCollider = GameObject.Find("swordnonamae").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Slash", false);
        animSword.SetBool("Slash2", false);
        #region �N�[���^�C������
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
        //P�������Ǝa��
        if (Input.GetKeyDown(KeyCode.P) && slashAble)
        {
            anim.SetBool("Slash", true);
            animSword.SetTrigger("Slash2");

            //slashable = false;
        }

        //L�������Ɠ˂�
        if (Input.GetKeyDown(KeyCode.O) && thrustAble)
        {
            anim.SetTrigger("Thrust");
            animSword.SetTrigger("Thrust2");
        }

        //O�������Ƃ��ߐ؂�
        if (Input.GetKeyDown(KeyCode.L) && chargeslashAble)
        {
            anim.SetTrigger("ChargeSlash");
            animSword.SetTrigger("ChargeSlash2");
        }
    }
}

//�a���A�˂��A���ߐ؂�