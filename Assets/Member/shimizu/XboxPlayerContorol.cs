using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/*
    Num_climb       :�Ǔo�莞�̈ړ���
    Translate_climb :�Ǔo�莞�̈ړ���          ��Num_climb * Translate_climb = �ŏI�I�Ɉړ����鋗��
    Time_climb      :�Ǔo�莞�̈ړ��̎��ԊԊu�@��Num_climb * Time_climb = �ŏI�I�Ɉړ��ɂ����鎞��
    MoveSpeed       :���ꂢ����Έړ��̑������ς��
    JumpForce       :���ꂢ����΃W�����v�̍������ς��
    SlidhingForce   :
    Wallright       :�̂̉��ɂ��Ă������A�^�b�`
    Ground          :�̂̉��ɂ��Ă����A�^�b�`
 */

public class XboxPlayerContorol : MonoBehaviour
{
    private Rigidbody2D rbody;
    private Animator anim;
    private bool sliding_judge = true;
    public float changechara = 2;
    public float changeatack = 1;

    private bool isGround = false;

    private bool isWallright = false;
    private bool coroutine_able = true;
    [SerializeField] private float num_climb, translate_climb,time_climb;
    
    private Vector2 scale = new Vector2(100, 100);
    
    private float jumpCount;


    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float slidingForce;
    [SerializeField] WallCheck wallright;
    [SerializeField] GroundCheck ground;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�L�����`�F���W
        if (Input.GetKeyDown(KeyCode.B))
        {
            anim.SetBool("changeIncarnation", true);
        }
        if (Input.GetAxis("L_R_Trigger") < 0)
        {
            changechara--;
            //Debug.Log(changechara);
            if (changechara < 1)
            {
                changechara = 3;
            }
            if (changechara == 1)
            {
                anim.SetBool("changeSwordman", false);
                anim.SetBool("changeArcher", false);
                anim.SetBool("changeWitch", true);

            }
            else if (changechara == 2)
            {
                anim.SetBool("changeArcher", false);
                anim.SetBool("changeWitch", false);
                anim.SetBool("changeSwordman", true);

            }
            else if (changechara == 3)
            {
                anim.SetBool("changeSwordman", false);
                anim.SetBool("changeWitch", false);
                anim.SetBool("changeArcher", true);

            }
            GameManagement.Instance.PlayerCharacter = (GameManagement.Character)Enum.ToObject(typeof(GameManagement.Character), changechara);
        }
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    changechara++;
        //    if (changechara > 3)
        //    {
        //        changechara = 1;
        //    }
        //    if (changechara == 1)
        //    {
        //        anim.SetBool("changeSwordman", false);
        //        anim.SetBool("changeArcher", false);
        //        anim.SetBool("changeWitch", true);

        //    }
        //    else if (changechara == 2)
        //    {
        //        anim.SetBool("changeArcher", false);
        //        anim.SetBool("changeWitch", false);
        //        anim.SetBool("changeSwordman", true);

        //    }
        //    else if (changechara == 3)
        //    {
        //        anim.SetBool("changeSwordman", false);
        //        anim.SetBool("changeWitch", false);
        //        anim.SetBool("changeArcher", true);

        //    }
        //}

        //�U�����@�̕ύX
        if (Input.GetKeyDown("joystick button 4"))
        {
            changeatack++;
            if (changeatack > 3)
            {
                changeatack = 1;
            }
            GameManagement.Instance.Atk = (GameManagement.AtkID)Enum.ToObject(typeof(GameManagement.AtkID), changeatack); 
        }

        //�ڒn����Ɛڕǔ���
        isGround = ground.IsGround();
        isWallright = wallright.IsWall();

        //���ړ�
        if (coroutine_able)
        {
            rbody.velocity = new Vector2(Input.GetAxis("L_Stick_H")
                * moveSpeed, rbody.velocity.y);
        }
        //�Ǔo���Ă�Œ��̓r���ŕǂ��痣��邽��
        if (!coroutine_able)
        {
            if (isWallright)
            {
                if (Input.GetAxis("L_Stick_H") > 0 && scale.x <0)
                {
                    rbody.isKinematic = false;
                    rbody.AddForce(new Vector2(1, 0) * 100);
                
                }
                if (Input.GetAxis("L_Stick_H") < 0 && scale.x > 0)
                {
                    rbody.isKinematic = false;
                    rbody.AddForce(new Vector2(-1, 0) * 100);
                }
            }
        }

        //���E���]
        if (rbody.velocity.x < 0)
        {
            scale.x = -100;
            transform.localScale = scale;
        }
        if (rbody.velocity.x > 0)
        {

            scale.x = 100;
            transform.localScale = scale; ;
        }

        //�W�����v
        if (Input.GetKeyDown("joystick button 0") && jumpCount < 2 && coroutine_able)
        {
            jumpCount++;
            //Debug.Log("jump!");
            Jump();
        }
        if (jumpCount > 1 && isGround)
        {
            jumpCount = 0;
        }
        
        //�X���C�f�B���O
        if (Input.GetAxis("L_Stick_H") != 0 && Input.GetKeyDown("joystick button 5") && isGround && coroutine_able)
        {

            sliding_judge = false;
            //sliding_anim.SetTrigger("Sliding");
            Debug.Log("�X���C�f�B���O");
            //�E����
            if (rbody.velocity.x > 0)
            {
                anim.SetBool("Sliding", true);
                StartCoroutine("AngleRepairRight");
            }
            //������
            if (rbody.velocity.x < 0)
            {
                anim.SetBool("SlidingLeft", true);
                StartCoroutine("AngleRepairLeft");
            }
        }

        //�Ǔo��
        if (isGround && isWallright && coroutine_able && Input.GetAxis("L_Stick_V") != 0 && Input.GetKeyDown("joystick button 5"))
        {
            Debug.Log("�Ǔo��");
            coroutine_able = false;
            StartCoroutine("Climb");
        }


    }
    //�W�����v�̋���
    void Jump()
    {
        //rbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
    }
    //�X���C�f�B���O�ł̉�]�𒼂�
    IEnumerator AngleRepairRight()
    {
        float j = Input.GetAxis("L_Stick_H");
        for (int i = 0; i < 150; i++)
        {
            if (Input.GetAxis("L_Stick_H") < j)
            {

                anim.SetBool("Sliding", false);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                sliding_judge = true;
                yield break;
            }
            yield return new WaitForSeconds(0.01f);
        }
        sliding_judge = true;
        anim.SetBool("Sliding", false);
    }
    IEnumerator AngleRepairLeft()
    {
        float j = Input.GetAxis("L_Stick_H");
        for (int i = 0; i < 150; i++)
        {
            if (Input.GetAxis("L_Stick_H") > j)
            {

                anim.SetBool("SlidingLeft", false);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                sliding_judge = true;
                yield break;
            }
            yield return new WaitForSeconds(0.01f);
        }
        sliding_judge = true;
        anim.SetBool("SlidingLeft", false);
    }
    //�Ǔo��̋���
    IEnumerator Climb()
    {
        rbody.velocity = new Vector2(0, 0);
        //rigidbody�𖳌���
        rbody.isKinematic = true; 
        //���ۂɓo��
        for (int i = 0; i < num_climb; i++)
        {
            //�ǂ��痣�ꂽ�Ƃ��I��
            if(!isWallright)
            {
                Debug.Log("�j��");
                coroutine_able = true;
                
                rbody.constraints = RigidbodyConstraints2D.None;
                rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
                yield break;
            }
            transform.Translate(0, translate_climb, 0);
            yield return new WaitForSeconds(time_climb);
        }
        coroutine_able = true;
        rbody.isKinematic = false;
        rbody.constraints = RigidbodyConstraints2D.None;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
