using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XboxPlayerContorol : MonoBehaviour
{
    private Rigidbody2D rbody;
    private BoxCollider2D boxcollider;
    private RectTransform rect;

    private bool isGround = false;

    private bool isWallright = false;
    private bool isWallleft = false;
    private bool coroutine_able = true;
    [SerializeField] private float num_climb, translate_climb,time_climb;
    [SerializeField] WallCheck wallright;
    [SerializeField] WallCheck wallleft;
    
    private Vector2 scale = new Vector2(100, 100);
    


    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float slidingForce;
    private float jumpCount;
    [SerializeField] private float climbPower;
    [SerializeField] GroundCheck ground;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(coroutine_able);
        Debug.Log(isWallleft);
        Debug.Log(isWallright);

        //Debug.Log(coroutine_able);

        isGround = ground.IsGround();
        isWallright = wallright.IsWall();
        isWallleft = wallleft.IsWall();
        //横移動
        if (coroutine_able)
        {
            rbody.velocity = new Vector2(Input.GetAxis("L_Stick_H")
                * moveSpeed, rbody.velocity.y);
        }
        if (!coroutine_able)
        {
            if (isWallright)
            {
                if (Input.GetAxis("L_Stick_H") > 0 && scale.x <0)
                {
                    rbody.isKinematic = false;
                    //rbody.velocity = new Vector2(Mathf.Abs(Input.GetAxis("L_Stick_H")) * moveSpeed, rbody.velocity.y);
                    rbody.AddForce(new Vector2(1, 0) * 100);
                
                }
                if (Input.GetAxis("L_Stick_H") < 0 && scale.x > 0)
                {
                    rbody.isKinematic = false;
                    //rbody.velocity = new Vector2(Mathf.Abs(Input.GetAxis("L_Stick_H")) * moveSpeed, rbody.velocity.y);
                    rbody.AddForce(new Vector2(-1, 0) * 100);
                }
            }
            if (isWallleft)
            {
                if (Input.GetAxis("L_Stick_H") < 0)
                {
                    rbody.isKinematic = false;
                    rbody.velocity = new Vector2(Mathf.Abs(Input.GetAxis("L_Stick_H")) * moveSpeed, rbody.velocity.y);
                Debug.Log(Input.GetAxis("L_Stick_H"));
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
        //--ジャンプ--
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
        //
        //スライディング
        if (Input.GetAxis("L_Stick_H") != 0 && Input.GetKeyDown("joystick button 5") && isGround && coroutine_able)
        {
            Debug.Log("スライディング");
            transform.localRotation = Quaternion.Euler(0, 0, 90);
            StartCoroutine("AngleRepair");
        }
        //Debug.Log(Input.GetAxis("L_Stick_V"));
        //Debug.Log(isWallright);
        //Debug.Log(isGround);
        //壁登り
        if (isGround && isWallright && coroutine_able && Input.GetAxis("L_Stick_V") != 0 && Input.GetKeyDown("joystick button 5"))
        {
            Debug.Log("壁登り");
            coroutine_able = false;
            StartCoroutine("Climb");
        }


    }
    void Jump()
    {
        //rbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
    }
    void JumpCountReset()
    {
        jumpCount = 0;
    }
    IEnumerator AngleRepair()
    {
        yield return new WaitForSeconds(0.5f);
        transform.localRotation = Quaternion.Euler(0, 0, 0);

    }
    IEnumerator Climb()
    {
        Debug.Log("コルーチン！");
        //rbody.constraints = RigidbodyConstraints2D.FreezePositionX;
        rbody.isKinematic = true;
        for (int i = 0; i < num_climb; i++)
        {
            if(!isWallleft && !isWallright)
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
