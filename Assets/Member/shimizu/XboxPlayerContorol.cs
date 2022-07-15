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
    private SpriteRenderer spren;
    private Animator anim;
    private bool sliding_judge = true;
    public bool xatacking = false;
    public int changechara = 2;
    private int changeatack = 0;
 
    private float beforeTrigger = 0;
    private float beforeTrigger2 = 0;
    private float view_button;
    [SerializeField] GameObject chara;

    public float atack_judge_con;

    private bool isGround = false;
    private bool head_sliding = false;
    private bool jumpreset = false;
    private bool slidingContinue = false;

    private bool isWallright = false;
    private bool coroutine_able = true;
    [SerializeField] private float num_climb, translate_climb,time_climb;
    
    private Vector3 scale = new Vector3(100, 100,1);
    
    private float jumpCount;


    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float slidingForce;
    [SerializeField] WallCheck wallright;
    [SerializeField] GroundCheck ground;
    [SerializeField] Animator gilranim;
    [SerializeField] Animator swordmananim;
    [SerializeField] Animator archeranim;
    // Start is called before the first frame update
    void Start()
    {
        spren = GetComponent<SpriteRenderer>();
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(atack_judge_con);
        //待機モーション
        if (rbody.velocity.x < 0.1f && rbody.velocity.x > -0.1f)
        {
            if (atack_judge_con == 0)
            {
                gilranim.SetBool("Moving", false);
            }
            else if (atack_judge_con == 1)
            {
                swordmananim.SetBool("SwordRun", false);
            }
            else if (atack_judge_con == 2)
            {
                archeranim.SetBool("ArcherMove", false);
            }
        }
        else
        {
            if (atack_judge_con == 0)
            {
                gilranim.SetBool("Moving", true);
            }
            else if (atack_judge_con == 1)
            {
                swordmananim.SetBool("SwordRun", true);
            }
            else if (atack_judge_con == 2)
            {
                archeranim.SetBool("ArcherMove", true);
            }
        }

        //
        //キャラチェンジ
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameManagement.Instance.PlayerOrb += 10;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            GameManagement.Instance.PlayerOrb -= 10;
        }
        if (GameManagement.Instance.PlayerOrb >= 15)
        {
            anim.SetBool("changeIncarnation", true);
        }
        view_button = Input.GetAxis("L_R_Trigger");
        //キャラ切り替え(変身)
        if (view_button > 0 && beforeTrigger == 0 && GameManagement.Instance.PlayerOrb > 15)  //つまりRT入力
        {
            GameManagement.Instance.PlayerOrb -= 15;
            switch (GameManagement.Instance.Character)
            {
                case GameManagement.CharacterID.Girl:
                    switch (GameManagement.Instance.PlayerCharacter)
                    {
                        case GameManagement.CharacterID.Swordsman:
                            GameManagement.Instance.Character = GameManagement.CharacterID.Swordsman;
                            changechara = 1;
                            break;
                        case GameManagement.CharacterID.Bowman:
                            GameManagement.Instance.Character = GameManagement.CharacterID.Bowman;
                            changechara = 2;
                            break;
                        default:
                            break;
                    }
                    //anim.SetBool("changeIncarnation",false); 
                    atack_judge_con = 0;
                    anim.SetBool("changeArcher", false);
                    anim.SetBool("changeWitch", true);
                    anim.SetBool("changeSwordman", false);
                    GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Girl;
                    //changechara = 0;
                    break;
                case GameManagement.CharacterID.Swordsman:
                    switch (GameManagement.Instance.PlayerCharacter)
                    {
                        case GameManagement.CharacterID.Girl:
                            GameManagement.Instance.Character = GameManagement.CharacterID.Girl;
                            changechara = 0;
                            break;
                        case GameManagement.CharacterID.Bowman:
                            GameManagement.Instance.Character = GameManagement.CharacterID.Bowman;
                            changechara = 2;
                            break;
                        default:
                            break;
                    }
                    GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Swordsman;
                    atack_judge_con = 1;
                    anim.SetBool("changeArcher", false);
                    anim.SetBool("changeWitch", false);
                    anim.SetBool("changeSwordman", true);
                    break;
                case GameManagement.CharacterID.Bowman:
                    switch (GameManagement.Instance.PlayerCharacter)
                    {
                        case GameManagement.CharacterID.Swordsman:
                            GameManagement.Instance.Character = GameManagement.CharacterID.Swordsman;
                            changechara = 1;
                            break;
                        case GameManagement.CharacterID.Girl:
                            GameManagement.Instance.Character = GameManagement.CharacterID.Girl;
                            changechara = 0;
                            break;
                        default:
                            break;
                    }
                    GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Bowman;
                    //anim.SetBool("changeIncarnation", true);
                    atack_judge_con = 2;
                    anim.SetBool("changeWitch", false);
                    anim.SetBool("changeSwordman", false);
                    anim.SetBool("changeArcher", true);
                    break;

            }

        }
        //キャラ選択
        
        if (view_button < 0 && beforeTrigger == 0) //つまりLT入力
        {
            Debug.Log("aaa");
            changechara++;
            if (changechara > 2)
            {
                changechara = 0;
            }
            if (GameManagement.Instance.PlayerCharacter == (GameManagement.CharacterID)Enum.ToObject(typeof(GameManagement.CharacterID),
                changechara) ||
                GameManagement.Instance.Character == (GameManagement.CharacterID)Enum.ToObject(typeof(GameManagement.CharacterID),
                changechara))
            {
                changechara++;
                if (changechara > 2)
                {
                    changechara = 0;
                }
            }
            GameManagement.Instance.Character =
                (GameManagement.CharacterID)Enum.ToObject(typeof(GameManagement.CharacterID),
                changechara);
        }
        beforeTrigger = view_button;
        //攻撃方法の変更
        if (Input.GetKeyDown("joystick button 4"))
        {
            
            changeatack++;
            if (changeatack > 2)
            {
                changeatack = 0;
            }
            GameManagement.Instance.Atk = (GameManagement.AtkID)Enum.ToObject(typeof(GameManagement.AtkID), changeatack);
            Debug.Log(GameManagement.Instance.Atk);
        }

        //接地判定と接壁判定
        isGround = ground.IsGround();
        isWallright = wallright.IsWall();

        //横移動
        if (coroutine_able && !head_sliding)
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
                    swordmananim.SetBool("SwordClimb", false);
                    gilranim.SetBool("GirlClimb", false);
                    anim.SetBool("GirlSliding", false);
                    anim.SetBool("GirlSlidingL", false);
                    rbody.AddForce(new Vector2(1, 0) * 100);
                
                }
                if (Input.GetAxis("L_Stick_H") < 0 && scale.x > 0)
                {
                    rbody.isKinematic = false;
                    swordmananim.SetBool("SwordClimb", false);
                    gilranim.SetBool("GirlClimb", false);
                    anim.SetBool("GirlSliding", false);
                    anim.SetBool("GirlSlidingL", false);
                    rbody.AddForce(new Vector2(-1, 0) * 100);
                }
            }
        }

        //左右反転
        if (rbody.velocity.x < 0 && !xatacking && sliding_judge)
        {
            scale.x = -100;
            transform.localScale = scale;
        }
        if (rbody.velocity.x > 0 && !xatacking && sliding_judge)
        {
            scale.x = 100;
            transform.localScale = scale;
        }

        
        //ジャンプ
        if(jumpCount > 0 && isGround && jumpreset)
        {
            jumpreset = false;
            jumpCount = 0;
        }
        if (Input.GetKeyDown("joystick button 0") && jumpCount == 0 && coroutine_able)
        {
            jumpCount++;
            //Debug.Log("jump!");
            Jump();
            StartCoroutine(JumpReset());
        }
        else if (Input.GetKeyDown("joystick button 0") && jumpCount == 1 && coroutine_able)
        {
            jumpCount++;
            Jump2();
        }
        
        //スライディング
        if (Input.GetAxis("L_Stick_H") != 0 && Input.GetKeyDown("joystick button 5") && isGround && coroutine_able)
        {
            if (GameManagement.Instance.PlayerCharacter == GameManagement.CharacterID.Bowman)
            {
                sliding_judge = false;
                head_sliding = true;
                //sliding_anim.SetTrigger("Sliding");
                Debug.Log("スライディング");
                //右向き
                if (rbody.velocity.x > 0)
                {
                    anim.SetBool("Sliding", true);
                    gilranim.SetBool("GirlSliding", true);
                    StartCoroutine("AngleRepairRight");
                    StartCoroutine("DodgeTag");
                }
                //左向き
                if (rbody.velocity.x < 0)
                {
                    anim.SetBool("SlidingLeft", true);
                    gilranim.SetBool("GirlSliding", true);
                    StartCoroutine("AngleRepairLeft");
                    StartCoroutine("DodgeTag");
                }
            }
            //少女のやつ
            if (GameManagement.Instance.PlayerCharacter == GameManagement.CharacterID.Girl)
            {
                sliding_judge = false;
                head_sliding = true;
                gilranim.SetBool("GirlSliding", true);
                StartCoroutine("DodgeTag");
                if (rbody.velocity.x > 0)
                {
                    anim.SetBool("GirlSliding", true);
                    StartCoroutine(HeadSlidingRepairR());

                }
                if (rbody.velocity.x < 0)
                {
                    anim.SetBool("GirlSlidingL", true);
                    StartCoroutine(HeadSlidingRepairL());

                }

            }
        }

        //壁登り
        if (isWallright && coroutine_able &&Input.GetAxis("L_Stick_H") != 0 && Input.GetKeyDown("joystick button 3"))
        {
            coroutine_able = false;
            if (atack_judge_con == 0)
            {
                gilranim.SetBool("GirlClimb", true);
            }
            else if (atack_judge_con == 1)
            {
                swordmananim.SetBool("SwordClimb", true);
            }
            
            StartCoroutine("Climb");
        }


    }
    //ジャンプの挙動
    void Jump()
    {
        //rbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);

        if (atack_judge_con == 0)
        {
            gilranim.SetTrigger("GirlJumping");
        }
        else if (atack_judge_con == 1)
        {
            swordmananim.SetTrigger("SwordJump");
        }
        else if (atack_judge_con == 2)
        {
            archeranim.SetTrigger("ArcherJump");
        }
    }
    void Jump2()
    {
        rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
    }
    //スライディングでの回転を直す
    IEnumerator AngleRepairRight()
    {
        //float j = Input.GetAxis("L_Stick_H");
        //for (int i = 0; i < 150; i++)
        //{
        //    if (Input.GetAxis("L_Stick_H") < j)
        //    {

        //        anim.SetBool("Sliding", false);
        //        transform.localRotation = Quaternion.Euler(0, 0, 0);
        //        sliding_judge = true;
        //        yield break;
        //    }
        //    yield return new WaitForSeconds(0.01f);
        //}
        yield return new WaitForSeconds(0.2f);
        rbody.AddForce(new Vector2(170, 0));
        yield return new WaitForSeconds(2.8f);
        sliding_judge = true;
        head_sliding = false;
        anim.SetBool("Sliding", false);
    }
    IEnumerator AngleRepairLeft()
    {
        //float j = Input.GetAxis("L_Stick_H");
        //for (int i = 0; i < 150; i++)
        //{
        //    if (Input.GetAxis("L_Stick_H") > j)
        //    {

        //        anim.SetBool("SlidingLeft", false);
        //        transform.localRotation = Quaternion.Euler(0, 0, 0);
        //        sliding_judge = true;
        //        yield break;
        //    }
        //    yield return new WaitForSeconds(0.01f);
        //}
        yield return new WaitForSeconds(0.2f);
        rbody.AddForce(new Vector2(-170, 0));
        yield return new WaitForSeconds(2.8f);
        sliding_judge = true;
        head_sliding = false;
        anim.SetBool("SlidingLeft", false);
    }
    IEnumerator DodgeTag()
    {
        chara.tag = "Dodge";
        yield return new WaitForSeconds(1f);
        chara.tag = "Player";
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
                rbody.isKinematic = false;
                rbody.constraints = RigidbodyConstraints2D.None;
                rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
                swordmananim.SetBool("SwordClimb", false);
                gilranim.SetBool("GirlClimb", false);
                yield break;
            }
            transform.Translate(0, translate_climb, 0);
            yield return new WaitForSeconds(time_climb);
        }
        coroutine_able = true;
        rbody.isKinematic = false;
        rbody.constraints = RigidbodyConstraints2D.None;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        swordmananim.SetBool("SwordClimb", false);
        gilranim.SetBool("GirlClimb", false);
    }
    void DamageColor()
    {
        spren.color = new Color(1, 0, 0, 1);
        StartCoroutine("RepairColor");
    }
    IEnumerator RepairColor()
    {
        yield return new WaitForSeconds(0.2f);
        spren.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("changeincarnation", false);
    }
    IEnumerator HeadSlidingRepairR()
    {
        yield return new WaitForSeconds(0.2f);
        //rbody.velocity = new Vector2(4, rbody.velocity.y);
        rbody.AddForce(new Vector2(170, 0));
        yield return new WaitForSeconds(0.3f);
        if (!slidingContinue)
        {
            StartCoroutine(NonSliContinue());
        }
    }
    IEnumerator HeadSlidingRepairL()
    {
        yield return new WaitForSeconds(0.2f);
        //rbody.velocity = new Vector2(4, rbody.velocity.y);
        rbody.AddForce(new Vector2(-170, 0));
        yield return new WaitForSeconds(0.3f);
        if (!slidingContinue)
        {
            StartCoroutine(NonSliContinue());
        }
    }
    IEnumerator NonSliContinue()
    {
        Debug.Log("aaaaaaaaaaaaa");
        yield return new WaitForSeconds(0.2f);
        gilranim.SetBool("GirlSliding1", true);
        gilranim.SetBool("GirlSliding2", true);
        sliding_judge = true;
        head_sliding = false;
        

        StartCoroutine(Sliding2F());
        slidingContinue = false;
    }
    IEnumerator Sliding2F()
    {
        yield return new WaitForSeconds(1.2f);
        anim.SetBool("GirlSliding", false);
        anim.SetBool("GirlSlidingL", false);
        gilranim.SetBool("GirlSliding", false);
        gilranim.SetBool("GirlSliding1", false);
        gilranim.SetBool("GirlSliding2", false);
    }
    IEnumerator JumpReset()
    {
        yield return new WaitForSeconds(0.1f);
        jumpreset = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tunnel"))
        {
            Debug.Log("Enter!");
            slidingContinue = true;
            rbody.AddForce(new Vector2(50, 0));
            gilranim.SetTrigger("GirlSliding1");
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Tunnel"))
        {
            Debug.Log("Stay!");
            if (rbody.velocity.x > 0)
            {
                rbody.velocity = new Vector2(5, 0);
            }
            else if (rbody.velocity.x < 0)
            {
                rbody.velocity = new Vector2(-5, 0);
            }
            gilranim.SetTrigger("GirlSliding1");
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Tunnel"))
        {
            Debug.Log("Exit!");
            gilranim.SetBool("GirlSliding2", true);
            sliding_judge = true;
            head_sliding = false;
            anim.SetBool("GirlSliding", false);
            anim.SetBool("GirlSlidingL", false);
            slidingContinue = false;
            gilranim.SetBool("GirlSliding", false);
            gilranim.SetBool("GirlSliding1", false);
            StartCoroutine(Sliding2F());
        }

    }
    public void ReturnGirlKey()
    {
        anim.SetBool("changeWitch", false);
        anim.SetBool("changeSwordman", false);
        anim.SetBool("changeArcher", false);
        anim.SetBool("changeIncarnation", false);
    }
}
