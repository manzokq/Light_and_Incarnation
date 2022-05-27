using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordmanAttack : MonoBehaviour
{
    private Animator animator;
    private Collider2D swordCollider;
    [SerializeField]
    GameObject sword;

    private bool slashAble = true;
    private bool thrustAble = true;
    private bool chargeslashAble = true;
    private float slashTime = 0;
    private float thrustTime = 0;
    private float chargeslashTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        animator = sword.GetComponent<Animator>();
        //swordCollider = GameObject.Find("swordnonamae").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        #region クールタイム処理
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
        //Pを押すと斬撃
        if (Input.GetKeyDown(KeyCode.U) && slashAble)
        {
            animator.SetBool("Slash", true);

            ////ソードコライダーをオンにする
            //swordCollider.enabled = true;
            ////
            Invoke("ColliderReset",1f);
            //slashAble = false;
        }

        ////Lを押すと突き
        //if (Input.GetKeyDown(KeyCode.S) && thrustAble)
        //{
        //    animator.SetBool("Thrust", true);
        //    //
        //    swordCollider.enabled = true;
        //    Invoke("ColliderReset", 0.1f);
        //    thrustAble = false;
        //}

        ////Oを押すとため切り
        //if (Input.GetKeyDown(KeyCode.D) && chargeslashAble)
        //{
        //    animator.SetBool("ChargeSlash", true);
        //    //
        //    swordCollider.enabled = true;
        //    Invoke("ColliderReset", 0.1f);
        //    chargeslashAble = false;
        //}
    }
    private void ColliderReset()
    {
        animator.SetBool("Slash", false);
    }
}

//斬撃、突き、ため切り