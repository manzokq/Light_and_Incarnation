using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/*
 * P:攻撃1
 * L:攻撃2
 * O:攻撃3
 * X:特殊攻撃
 * AD:移動
 * Space:ジャンプ
 * LShift:スライディング(ホールド式)
 * RShift:壁登り
 * B:オーブモード
 * N:化身変化
 * M:化身選択
 */
public class PlayerControl : MonoBehaviour
{
    private SpriteRenderer spren;
    private Rigidbody2D rbody;
    private Animator anim;
    private bool sliding_judge = true;
    public bool atacking = false;
    private bool head_sliding = false;
    public byte changechara = 0;

    private float jumpanim = 0;
    public int atack_judge = 0;
    private bool incarnation_able = false;

    private bool isGround = false;
    private bool isWallright = false;
    private bool isHeading = false;
    private bool coroutine_able = true;
    private bool jumpreset = true;
    private bool slidingContinue = false;
    
    [SerializeField] private float num_climb, translate_climb, time_climb;
    [SerializeField] GameObject chara;
    
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
        
        //Debug.Log(atack_judge);
        //待機モーション
        if (rbody.velocity.x < 0.1f && rbody.velocity.x > -0.1f)
        {
            if (atack_judge == 0)
            {
                gilranim.SetBool("Moving", false);
            }
            else if (atack_judge == 1)
            {
                swordmananim.SetBool("SwordRun", false);
            }
            else if (atack_judge == 2)
            {
                archeranim.SetBool("ArcherMove", false);
            }
        }
        else
        {

            if (atack_judge == 0)
            {
                gilranim.SetBool("Moving", true);
            }
            else if (atack_judge == 1)
            {
                swordmananim.SetBool("SwordRun", true);
            }
            else if (atack_judge == 2)
            {
                //Debug.Log("ArcherRun");
                archeranim.SetBool("ArcherMove", true);
            }
        }
        //キャラチェンジ
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameManagement.Instance.PlayerOrb += 10;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            GameManagement.Instance.PlayerOrb -= 10;
        }
        ////キャラチェンジ実際の
        //if(GameManagement.Instance.PlayerOrb >= 15)
        //{
        //    GameManagement.Instance.PlayerOrb -= 15;
        //}
        //
        if (GameManagement.Instance.PlayerOrb >= 15)
        {
            anim.SetBool("changeIncarnation", true);
        }
        //else
        //{
        //    anim.SetBool("changeIncarnation", false);
        //}

        if (Input.GetKeyDown(KeyCode.N) && GameManagement.Instance.PlayerOrb >15)
        {
            
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
                    atack_judge = 0;
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
                    atack_judge = 1;
                    GameManagement.Instance.PlayerOrb -= 15;
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
                    atack_judge = 2;
                    GameManagement.Instance.PlayerOrb -= 15;
                    anim.SetBool("changeWitch", false);
                    anim.SetBool("changeSwordman", false);
                    anim.SetBool("changeArcher", true);
                    break;

            }

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
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
        //sliding_anim.SetBool("Sliding", false);
        //Debug.Log(coroutine_able);
        //Debug.Log(isWallright);

        //Debug.Log(coroutine_able);
        //接地判定と接壁判定
        isGround = ground.IsGround();
        isWallright = wallright.IsWall();

        //横移動
        
        
        if (coroutine_able && !head_sliding)
        {
            rbody.velocity = new Vector2(Input.GetAxis("Horizontal")
                * moveSpeed, rbody.velocity.y);
        }
        

        //Debug.Log(isHeading);
        isHeading = HeadCheck.heading;
        //壁登ってる最中の途中で壁から離れるため
        if (!coroutine_able || isHeading)
        {
            Debug.Log("aaaa");
            if (isWallright)
            {

                if (Input.GetAxis("Horizontal") > 0 && scale.x < 0)
                {
                    rbody.isKinematic = false;
                    swordmananim.SetBool("SwordClimb", false);
                    gilranim.SetBool("GirlClimb", false);
                    //anim.SetBool("GirlSliding", false);
                    //anim.SetBool("GirlSlidingL", false);
                    rbody.AddForce(new Vector2(1, 0) * 1);

                }
                if (Input.GetAxis("Horizontal") < 0 && scale.x > 0)
                {
                    rbody.isKinematic = false;
                    swordmananim.SetBool("SwordClimb", false);
                    gilranim.SetBool("GirlClimb", false);
                    //anim.SetBool("GirlSliding", false);
                    //anim.SetBool("GirlSlidingL", false);
                    rbody.AddForce(new Vector2(-1, 0) * 1);
                }
                if (isHeading)
                {
                    //Debug.Log("bbb");
                    HeadCheck.heading = false;
                    rbody.isKinematic = false;
                    swordmananim.SetBool("SwordClimb", false);
                    gilranim.SetBool("GirlClimb", false);
                    //anim.SetBool("GirlSliding", false);
                    //anim.SetBool("GirlSlidingL", false);

                }
            }
        }
        //Debug.Log(sliding_judge);
        //左右反転
        if (rbody.velocity.x < 0 && !atacking && sliding_judge)
        {
            scale.x = -100;
            transform.localScale = scale;
        }
        if (rbody.velocity.x > 0 && !atacking && sliding_judge)
        {

            scale.x = 100;
            transform.localScale = scale;
        }

        //Debug.Log(jumpCount);
        //Debug.Log(isGround);

        //ジャンプ
        if (jumpCount > 0 && isGround && jumpreset)
        {
            jumpreset = false;
            //Debug.Log("Reset");
            jumpCount = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount == 0 && coroutine_able)
        {
            //Debug.Log("入った");
            jumpCount++;
            //Debug.Log("jump!");
            Jump();
            StartCoroutine(JumpReset());
        }
        else if (Input.GetKeyDown(KeyCode.Space) && jumpCount == 1 && coroutine_able)
        {
            //Debug.Log("2回目入った");
            jumpCount++;
            //Debug.Log("jump!");
            Jump2();
        }


        //スライディング
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGround && coroutine_able && rbody.velocity.x != 0 && sliding_judge)
        {
            if (GameManagement.Instance.PlayerCharacter == GameManagement.CharacterID.Bowman)
            {
                Debug.Log("Archerのスライディング");
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
                    anim.SetBool("GirlSlidingL", true);
                    StartCoroutine(AngleRepairLeftArcher());

                }
            }
            //少女のヘッドスライディング
            if (GameManagement.Instance.PlayerCharacter == GameManagement.CharacterID.Girl)
            {
                
                sliding_judge = false;
                head_sliding = true;
                gilranim.SetBool("GirlSliding",true);
                StartCoroutine("DodgeTag");
                if (rbody.velocity.x > 0)
                {
                    anim.SetBool("GirlSliding",true);
                    StartCoroutine(AngleRepairRight());
                  
                }
                if (rbody.velocity.x < 0)
                {
                    anim.SetBool("GirlSlidingL",true);
                    StartCoroutine(AngleRepairLeft());
               
                }
                
            }
        }

        //Debug.Log(isWallright);
        //壁登り
        if (GameManagement.Instance.PlayerCharacter == GameManagement.CharacterID.Girl || GameManagement.Instance.PlayerCharacter == GameManagement.CharacterID.Swordsman)
        {
            if (isWallright && coroutine_able && Input.GetKeyDown(KeyCode.RightShift))
            {
                //Debug.Log("壁登り");
                coroutine_able = false;
                if (atack_judge == 0)
                {
                    gilranim.SetBool("GirlClimb", true);
                    StartCoroutine("Climb");
                }
                else if (atack_judge == 1)
                {
                    swordmananim.SetBool("SwordClimb", true);
                    StartCoroutine("Climb");
                }

            }
        }

    }
    //ジャンプの挙動
    void Jump()
    {
        //Debug.Log(jumpanim);
        //rbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);

        if (atack_judge == 0)
        {
            gilranim.SetTrigger("GirlJumping");
        }
        else if (atack_judge == 1)
        {
            swordmananim.SetTrigger("SwordJump");
        }
        else if (atack_judge == 2)
        {
            archeranim.SetTrigger("ArcherJump");
        }
    }
    void Jump2()
    {
        //Debug.Log("ジャンプ２回目");
        rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
    }
    //スライディングでの回転を直す
    //右向いてる時
    IEnumerator AngleRepairRight()
    {
        
        yield return new WaitForSeconds(0.2f);
        rbody.AddForce(new Vector2(170, 0));
        yield return new WaitForSeconds(0.3f);
        if (!slidingContinue)
        {
            StartCoroutine(NonSliContinue());
        }
        
    }
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
    //左向いてる時
    IEnumerator AngleRepairLeft()
    {

        yield return new WaitForSeconds(0.2f);
        rbody.AddForce(new Vector2(-170, 0));
        yield return new WaitForSeconds(0.3f);
        if (!slidingContinue)
        {
            StartCoroutine(NonSliContinue());
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
            if (!isWallright)
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
    IEnumerator DodgeTag()
    {
        chara.tag = "Dodge";
        yield return new WaitForSeconds(1f);
        chara.tag = "Player";
    }

    public void DamageColor()
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
        yield return new WaitForSeconds(0.1f);
        //rbody.velocity = new Vector2(4, rbody.velocity.y);
        rbody.AddForce(new Vector2(170, 0));
        yield return new WaitForSeconds(2.4f);
        sliding_judge = true;
        head_sliding = false;
    }
    IEnumerator HeadSlidingRepairL()
    {
        yield return new WaitForSeconds(0.1f);
        //rbody.velocity = new Vector2(4, rbody.velocity.y);
        rbody.AddForce(new Vector2(-170, 0));
        yield return new WaitForSeconds(2.4f);
        sliding_judge = true;
        head_sliding = false;
    }
    IEnumerator JumpReset()
    {
        yield return new WaitForSeconds(0.1f);
        jumpreset = true;
    }
    IEnumerator NonSliContinue()
    {
        //Debug.Log("aaaaaaaaaaaaa");
        yield return new WaitForSeconds(0.2f);
        gilranim.SetBool("GirlSliding1",true);
        gilranim.SetBool("GirlSliding2",true);
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
        anim.SetBool("changeWitch", false);
        anim.SetBool("changeSwordman", false);
        anim.SetBool("changeArcher", false);
        anim.SetBool("changeIncarnation", false);
    }
}