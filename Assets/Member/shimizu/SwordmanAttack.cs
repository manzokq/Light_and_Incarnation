using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordmanAttack : MonoBehaviour
{
    private Animator animator;
    private Collider2D swordCollider;
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
        if (Input.GetKeyDown("joystick button 1") && slashAble)
        {
            //spren.enabled = false;
            anim.SetBool("Slash", true);
            animSword.SetBool("Slash2", true);

            ////�\�[�h�R���C�_�[���I���ɂ���
            //swordCollider.enabled = true;
            //slashable = false;
        }

        ////L�������Ɠ˂�
        //if (Input.GetKeyDown(KeyCode.S) && thrustAble)
        //{
        //    animator.SetBool("Thrust", true);
        //    //
        //    swordCollider.enabled = true;
        //    Invoke("ColliderReset", 0.1f);
        //    thrustAble = false;
        //}

        ////O�������Ƃ��ߐ؂�
        //if (Input.GetKeyDown(KeyCode.D) && chargeslashAble)
        //{
        //    animator.SetBool("ChargeSlash", true);
        //    //
        //    swordCollider.enabled = true;
        //    Invoke("ColliderReset", 0.1f);
        //    chargeslashAble = false;
        //}
    }
}

//�a���A�˂��A���ߐ؂�