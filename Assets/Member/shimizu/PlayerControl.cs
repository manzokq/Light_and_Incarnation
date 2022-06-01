using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rbody;
    private Animator sliding_anim;
    private bool sliding_judge = true;
    private float changechara = 2;

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
        sliding_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //キャラチェンジ
        if(Input.GetKeyDown(KeyCode.B))
        {
            sliding_anim.SetBool("changeIncarnation", true);
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            changechara--;
            Debug.Log(changechara);
            if(changechara<1)
            {
                changechara = 3;
            }
            if(changechara == 1)
            {
                sliding_anim.SetBool("changeSwordman", false);
                sliding_anim.SetBool("changeArcher", false);
                sliding_anim.SetBool("changeWitch", true);

            }
            else if (changechara == 2)
            {
                sliding_anim.SetBool("changeArcher", false);
                sliding_anim.SetBool("changeWitch", false);
                sliding_anim.SetBool("changeSwordman", true);

            }
            else if (changechara == 3)
            {
                sliding_anim.SetBool("changeSwordman", false);
                sliding_anim.SetBool("changeWitch", false);
                sliding_anim.SetBool("changeArcher", true);

            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            changechara++;
            if(changechara> 3)
            {
                changechara = 1;
            }
            if (changechara == 1)
            {
                sliding_anim.SetBool("changeSwordman", false);
                sliding_anim.SetBool("changeArcher", false);
                sliding_anim.SetBool("changeWitch", true);

            }
            else if (changechara == 2)
            {
                sliding_anim.SetBool("changeArcher", false);
                sliding_anim.SetBool("changeWitch", false);
                sliding_anim.SetBool("changeSwordman", true);

            }
            else if (changechara == 3)
            {
                sliding_anim.SetBool("changeSwordman", false);
                sliding_anim.SetBool("changeWitch", false);
                sliding_anim.SetBool("changeArcher", true);

            }
        }
        //sliding_anim.SetBool("Sliding", false);
        //Debug.Log(coroutine_able);
        Debug.Log(isWallright);

        //Debug.Log(coroutine_able);
        //接地判定と接壁判定
        isGround = ground.IsGround();
        isWallright = wallright.IsWall();

        //横移動
        if (coroutine_able)
        {
            rbody.velocity = new Vector2(Input.GetAxis("Horizontal")
                * moveSpeed, rbody.velocity.y);
        }
        //壁登ってる最中の途中で壁から離れるため
        if (!coroutine_able)
        {
            if (isWallright)
            {
                if (Input.GetAxis("Horizontal") > 0 && scale.x <0)
                {
                    rbody.isKinematic = false;
                    rbody.AddForce(new Vector2(1, 0) * 100);
                
                }
                if (Input.GetAxis("Horizontal") < 0 && scale.x > 0)
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
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2 && coroutine_able)
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
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGround && coroutine_able && rbody.velocity.x != 0 && sliding_judge)
        {
            sliding_judge = false;
            //sliding_anim.SetTrigger("Sliding");
            Debug.Log("スライディング");
            //右向き
            if (rbody.velocity.x > 0)
            {
                sliding_anim.SetBool("Sliding",true);
                StartCoroutine("AngleRepairRight");
            }
            //左向き
            if (rbody.velocity.x < 0)
            {
                sliding_anim.SetBool("SlidingLeft", true);
                StartCoroutine("AngleRepairLeft");
            }
        }
        

        //壁登り
        if (isGround && isWallright && coroutine_able && Input.GetKeyDown(KeyCode.RightShift))
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
    //右向いてる時
    IEnumerator AngleRepairRight()
    {
        float j = Input.GetAxis("Horizontal");
        for(int i = 0;i < 150; i++)
        {
            if(Input.GetAxis("Horizontal") < j)
            {
                
                sliding_anim.SetBool("Sliding", false);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                sliding_judge = true;
                yield break;
            }
            yield return new WaitForSeconds(0.01f);
        }
        sliding_judge = true;
        sliding_anim.SetBool("Sliding", false);
    }
    //左向いてる時
    IEnumerator AngleRepairLeft()
    {
        float j = Input.GetAxis("Horizontal");
        for (int i = 0; i < 150; i++)
        {
            if (Input.GetAxis("Horizontal") > j)
            {
                
                sliding_anim.SetBool("SlidingLeft", false);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                sliding_judge = true;
                yield break;
            }
            yield return new WaitForSeconds(0.01f);
        }
        sliding_judge = true;
        sliding_anim.SetBool("SlidingLeft", false);
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
