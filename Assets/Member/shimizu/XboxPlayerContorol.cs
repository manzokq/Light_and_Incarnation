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

    private bool isGirl = true;
    private bool isSwordman = false;
    private bool isArcher = false;
    
    private float beforeTrigger = 0;
    private float beforeTrigger2 = 0;
    private float view_button;
    [SerializeField] GameObject chara;

    public float atack_judge_con;

    private bool isGround = false;
    private bool head_sliding = false;
    private bool jumpreset = false;
    private bool slidingContinue = false;
    private bool isHeading = false;

    private bool isWallright = false;
    private bool coroutine_able = true;
    [SerializeField] private float num_climb, translate_climb,time_climb;
    
    private Vector3 scale = new Vector3(100, 100,1);
    
    private float jumpCount;

    private bool parryAble = true;


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
        //if(transform.localPosition.x)
        //Debug.Log(atack_judge_con);
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
        //キャラチェンジ(デバッグ用)
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameManagement.Instance.PlayerOrb += 10;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            GameManagement.Instance.PlayerOrb -= 10;
        }
        //キャラ切り替え(新)
        if (GameManagement.Instance.PlayerOrb >= 15)
        {
            anim.SetBool("changeIncarnation", true);
        }
        if(Input.GetAxisRaw("D_Pad_H") == 1 && !isSwordman && GameManagement.Instance.PlayerOrb>=15) //想定では→　剣士
        {
            atack_judge_con = 1;
            isGirl = false;
            isSwordman = true;
            isArcher = false;
            Debug.Log("a");
            GameManagement.Instance.PlayerOrb -= 15;
            anim.SetBool("changeArcher", false);
            anim.SetBool("changeWitch", false);
            anim.SetBool("changeSwordman", true);
        }
        if (Input.GetAxisRaw("D_Pad_H") == -1 && !isArcher && GameManagement.Instance.PlayerOrb >= 15) //想定では←　弓使
        {
            atack_judge_con = 2;
            isGirl = false;
            isSwordman = false;
            isArcher = true;
            Debug.Log("b");
            GameManagement.Instance.PlayerOrb -= 15;
            anim.SetBool("changeWitch", false);
            anim.SetBool("changeSwordman", false);
            anim.SetBool("changeArcher", true);
        }
        if (Input.GetAxisRaw("D_Pad_V") == 1 && !isGirl) //想定では↑  少女
        {
            atack_judge_con = 0;
            Debug.Log("c");
            isGirl = true;
            isSwordman = false;
            isArcher = false;
            anim.SetBool("changeArcher", false);
            anim.SetBool("changeSwordman", false);
            anim.SetBool("changeWitch", true);
        }
        //view_button = Input.GetAxis("L_R_Trigger");
        //キャラ切り替え(変身)
        //if (view_button > 0 && beforeTrigger == 0 && GameManagement.Instance.PlayerOrb > 15)  //つまりRT入力
        //{

        //    switch (GameManagement.Instance.Character)
        //    {
        //        case GameManagement.CharacterID.Girl:
        //            switch (GameManagement.Instance.PlayerCharacter)
        //            {
        //                case GameManagement.CharacterID.Swordsman:
        //                    GameManagement.Instance.Character = GameManagement.CharacterID.Swordsman;
        //                    changechara = 1;
        //                    break;
        //                case GameManagement.CharacterID.Bowman:
        //                    GameManagement.Instance.Character = GameManagement.CharacterID.Bowman;
        //                    changechara = 2;
        //                    break;
        //                default:
        //                    break;
        //            }
        //            //anim.SetBool("changeIncarnation",false); 
        //            atack_judge_con = 0;
        //            anim.SetBool("changeArcher", false);
        //            anim.SetBool("changeWitch", true);
        //            anim.SetBool("changeSwordman", false);
        //            GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Girl;
        //            //changechara = 0;
        //            break;
        //        case GameManagement.CharacterID.Swordsman:
        //            switch (GameManagement.Instance.PlayerCharacter)
        //            {
        //                case GameManagement.CharacterID.Girl:
        //                    GameManagement.Instance.Character = GameManagement.CharacterID.Girl;
        //                    changechara = 0;
        //                    break;
        //                case GameManagement.CharacterID.Bowman:
        //                    GameManagement.Instance.Character = GameManagement.CharacterID.Bowman;
        //                    changechara = 2;
        //                    break;
        //                default:
        //                    break;
        //            }
        //            GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Swordsman;
        //            atack_judge_con = 1;
        //            GameManagement.Instance.PlayerOrb -= 15;
        //            anim.SetBool("changeArcher", false);
        //            anim.SetBool("changeWitch", false);
        //            anim.SetBool("changeSwordman", true);
        //            break;
        //        case GameManagement.CharacterID.Bowman:
        //            switch (GameManagement.Instance.PlayerCharacter)
        //            {
        //                case GameManagement.CharacterID.Swordsman:
        //                    GameManagement.Instance.Character = GameManagement.CharacterID.Swordsman;
        //                    changechara = 1;
        //                    break;
        //                case GameManagement.CharacterID.Girl:
        //                    GameManagement.Instance.Character = GameManagement.CharacterID.Girl;
        //                    changechara = 0;
        //                    break;
        //                default:
        //                    break;
        //            }
        //            GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Bowman;
        //            //anim.SetBool("changeIncarnation", true);
        //            atack_judge_con = 2;
        //            GameManagement.Instance.PlayerOrb -= 15;
        //            anim.SetBool("changeWitch", false);
        //            anim.SetBool("changeSwordman", false);
        //            anim.SetBool("changeArcher", true);
        //            break;

        //    }

        //}
        ////キャラ選択

        //if (view_button < 0 && beforeTrigger == 0) //つまりLT入力
        //{
        //    //Debug.Log("aaa");
        //    changechara++;
        //    if (changechara > 2)
        //    {
        //        changechara = 0;
        //    }
        //    if (GameManagement.Instance.PlayerCharacter == (GameManagement.CharacterID)Enum.ToObject(typeof(GameManagement.CharacterID),
        //        changechara) ||
        //        GameManagement.Instance.Character == (GameManagement.CharacterID)Enum.ToObject(typeof(GameManagement.CharacterID),
        //        changechara))
        //    {
        //        changechara++;
        //        if (changechara > 2)
        //        {
        //            changechara = 0;
        //        }
        //    }
        //    GameManagement.Instance.Character =
        //        (GameManagement.CharacterID)Enum.ToObject(typeof(GameManagement.CharacterID),
        //        changechara);
        //}
        //beforeTrigger = view_button;
        //攻撃方法の変更
        if (Input.GetKeyDown("joystick button 4"))
        {
            
            changeatack++;
            if (changeatack > 2)
            {
                changeatack = 0;
            }
            GameManagement.Instance.Atk = (GameManagement.AtkID)Enum.ToObject(typeof(GameManagement.AtkID), changeatack);
            //Debug.Log(GameManagement.Instance.Atk);
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
        
        isHeading = HeadCheck.heading;
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
                if (isHeading)
                {
                    //Debug.Log("bbb");
                    HeadCheck.heading = false;
                    rbody.isKinematic = false;
                    swordmananim.SetBool("SwordClimb", false);
                    gilranim.SetBool("GirlClimb", false);
                    anim.SetBool("GirlSliding", false);
                    anim.SetBool("GirlSlidingL", false);

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
                archeranim.SetBool("ArcherSliding", true);
                StartCoroutine("DodgeTag");
                if (rbody.velocity.x > 0)
                {
                    anim.SetBool("GirlSliding", true);
                    StartCoroutine(AngleRepairRightArcher());

                }
                if (rbody.velocity.x < 0)
                {
                    anim.SetBool("GirlSliding", true);
                    StartCoroutine(AngleRepairLeftArcher());

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
        if (GameManagement.Instance.PlayerCharacter == GameManagement.CharacterID.Girl || GameManagement.Instance.PlayerCharacter == GameManagement.CharacterID.Swordsman)
        {
            if (isWallright && coroutine_able && Input.GetAxis("L_Stick_H") != 0 && Input.GetKeyDown("joystick button 3"))
            {
                coroutine_able = false;
                if (atack_judge_con == 0)
                {
                    gilranim.SetBool("GirlClimb", true);
                    StartCoroutine("Climb");
                }
                else if (atack_judge_con == 1)
                {
                    swordmananim.SetBool("SwordClimb", true);
                    StartCoroutine("Climb");
                }


            }
        }
        //ガードというかパリィというか
        float viewButton = Input.GetAxis("L_R_Trigger");
        if (parryAble && atack_judge_con == 1 && (Input.GetKeyDown("joystick button 4") || (viewButton > 0 && beforeTrigger == 0)))
        {
            parryAble = false;
            this.gameObject.tag = "Parry";
            beforeTrigger = viewButton;
            StartCoroutine(Parry());
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
   
    IEnumerator AngleRepairRightArcher()
    {

        yield return new WaitForSeconds(0.2f);
        rbody.AddForce(new Vector2(170, 0));
        yield return new WaitForSeconds(0.3f);
        if (!slidingContinue)
        {
            StartCoroutine(NonSliContinueArcher());
        }

    }
    
    IEnumerator AngleRepairLeftArcher()
    {

        yield return new WaitForSeconds(0.2f);
        rbody.AddForce(new Vector2(-170, 0));
        yield return new WaitForSeconds(0.3f);
        if (!slidingContinue)
        {
            StartCoroutine(NonSliContinueArcher());
        }

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
                //Debug.Log("破棄");
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
        //Debug.Log("aaaaaaaaaaaaa");
        yield return new WaitForSeconds(0.2f);
        gilranim.SetBool("GirlSliding1", true);
        gilranim.SetBool("GirlSliding2", true);
        sliding_judge = true;
        head_sliding = false;
        

        StartCoroutine(Sliding2F());
        slidingContinue = false;
    }
    IEnumerator NonSliContinueArcher()
    {
        //Debug.Log("aaaaaaaaaaaaa");
        yield return new WaitForSeconds(0.2f);
        archeranim.SetBool("ArcherSliding1", true);
        archeranim.SetBool("ArcherSliding2", true);
        sliding_judge = true;
        head_sliding = false;
        StartCoroutine(Sliding2FArcher());
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
    IEnumerator Sliding2FArcher()
    {
        yield return new WaitForSeconds(1.2f);
        anim.SetBool("GirlSliding", false);
        anim.SetBool("GirlSlidingL", false);
        archeranim.SetBool("ArcherSliding", false);
        archeranim.SetBool("ArcherSliding1", false);
        archeranim.SetBool("ArcherSliding2", false);
    }
    IEnumerator JumpReset()
    {
        yield return new WaitForSeconds(0.1f);
        jumpreset = true;
    }
    IEnumerator ExitSliding()
    {
        yield return new WaitForSeconds(0.3f);
        if (GameManagement.Instance.PlayerCharacter == GameManagement.CharacterID.Girl)
        {
            gilranim.SetBool("GirlSliding2", true);
            sliding_judge = true;
            head_sliding = false;
            anim.SetBool("GirlSliding", false);
            slidingContinue = false;
            anim.SetBool("GirlSlidingL", false);
            gilranim.SetBool("GirlSliding", false);
            gilranim.SetBool("GirlSliding1", false);
            yield return new WaitForSeconds(0.3f);
            gilranim.SetBool("GirlSliding2", false);
        }
        if (GameManagement.Instance.PlayerCharacter == GameManagement.CharacterID.Bowman)
        {
            archeranim.SetBool("ArcherSliding2", true);
            sliding_judge = true;
            head_sliding = false;
            anim.SetBool("GirlSliding", false);
            slidingContinue = false;
            anim.SetBool("GirlSlidingL", false);
            archeranim.SetBool("ArcherSliding", false);
            archeranim.SetBool("ArcherSliding1", false);
            yield return new WaitForSeconds(0.3f);
            archeranim.SetBool("ArcherSliding2", false);
        }
    }
    IEnumerator Parry()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.tag = "Player";
        yield return new WaitForSeconds(1f);
        parryAble = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tunnel"))
        {
            //Debug.Log("Enter!");
            slidingContinue = true;
            rbody.AddForce(new Vector2(50, 0));
            if (GameManagement.Instance.PlayerCharacter == GameManagement.CharacterID.Girl)
            {
                gilranim.SetTrigger("GirlSliding1");
            }
            if (GameManagement.Instance.PlayerCharacter == GameManagement.CharacterID.Bowman)
            {
                archeranim.SetTrigger("ArcherSliding1");
            }
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Tunnel"))
        {
            //Debug.Log("Stay!");
            if (rbody.velocity.x > 0)
            {
                rbody.velocity = new Vector2(5, 0);
            }
            else if (rbody.velocity.x < 0)
            {
                rbody.velocity = new Vector2(-5, 0);
            }
            if (GameManagement.Instance.PlayerCharacter == GameManagement.CharacterID.Bowman)
            {
                archeranim.SetBool("ArcherSliding1", true);
            }
            if (GameManagement.Instance.PlayerCharacter == GameManagement.CharacterID.Girl)
            {
                gilranim.SetBool("GirlSliding1", true);
            }
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Tunnel"))
        {
            StartCoroutine(ExitSliding());
            //Debug.Log("Exit!");

            //if (GameManagement.Instance.PlayerCharacter == GameManagement.CharacterID.Girl)
            //{
            //    StartCoroutine(Sliding2F());
            //}
            //if (GameManagement.Instance.PlayerCharacter == GameManagement.CharacterID.Bowman)
            //{
            //    StartCoroutine(Sliding2FArcher());
            //}

        }

    }
    public void ReturnGirlKey()
    {



        switch (GameManagement.Instance.PlayerCharacter)
        {
            case GameManagement.CharacterID.Swordsman:
                GameManagement.Instance.Character = GameManagement.CharacterID.Swordsman;
               
                break;
            case GameManagement.CharacterID.Bowman:
                GameManagement.Instance.Character = GameManagement.CharacterID.Bowman;
              
                break;
          
        }
        GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Girl;
        changechara = 0;
        atack_judge_con = 0;
        anim.SetBool("changeWitch", false);
        anim.SetBool("changeSwordman", false);
        anim.SetBool("changeArcher", false);
        anim.SetBool("changeIncarnation", false);
    }
}
