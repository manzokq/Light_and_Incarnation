using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/*
    Num_climb       :壁登り時の移動回数
    Translate_climb :壁登り時の移動幅          →Num_climb * Translate_climb = 最終的に移動する距離
    Time_climb      :壁登り時の移動の時間間隔　→Num_climb * Time_climb = 最終的に移動にかかる時間
    MoveSpeed       :これいじれば移動の速さが変わる
    JumpForce       :これいじればジャンプの高さが変わる
    SlidhingForce   :
    Wallright       :体の横についているやつをアタッチ
    Ground          :体の下についてるやつをアタッチ
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
        //キャラチェンジ
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

        //攻撃方法の変更
        if (Input.GetKeyDown("joystick button 4"))
        {
            changeatack++;
            if (changeatack > 3)
            {
                changeatack = 1;
            }
            GameManagement.Instance.Atk = (GameManagement.AtkID)Enum.ToObject(typeof(GameManagement.AtkID), changeatack); 
        }

        //接地判定と接壁判定
        isGround = ground.IsGround();
        isWallright = wallright.IsWall();

        //横移動
        if (coroutine_able)
        {
            rbody.velocity = new Vector2(Input.GetAxis("L_Stick_H")
                * moveSpeed, rbody.velocity.y);
        }
        //壁登ってる最中の途中で壁から離れるため
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

        //左右反転
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

        //ジャンプ
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
        
        //スライディング
        if (Input.GetAxis("L_Stick_H") != 0 && Input.GetKeyDown("joystick button 5") && isGround && coroutine_able)
        {

            sliding_judge = false;
            //sliding_anim.SetTrigger("Sliding");
            Debug.Log("スライディング");
            //右向き
            if (rbody.velocity.x > 0)
            {
                anim.SetBool("Sliding", true);
                StartCoroutine("AngleRepairRight");
            }
            //左向き
            if (rbody.velocity.x < 0)
            {
                anim.SetBool("SlidingLeft", true);
                StartCoroutine("AngleRepairLeft");
            }
        }

        //壁登り
        if (isGround && isWallright && coroutine_able && Input.GetAxis("L_Stick_V") != 0 && Input.GetKeyDown("joystick button 5"))
        {
            Debug.Log("壁登り");
            coroutine_able = false;
            StartCoroutine("Climb");
        }


    }
    //ジャンプの挙動
    void Jump()
    {
        //rbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
    }
    //スライディングでの回転を直す
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
    //壁登りの挙動
    IEnumerator Climb()
    {
        rbody.velocity = new Vector2(0, 0);
        //rigidbodyを無効化
        rbody.isKinematic = true; 
        //実際に登る
        for (int i = 0; i < num_climb; i++)
        {
            //壁から離れたとき終了
            if(!isWallright)
            {
                Debug.Log("破棄");
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
