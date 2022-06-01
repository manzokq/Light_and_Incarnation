using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{


    private Rigidbody2D rbody;
    private BoxCollider2D boxcollider;
    private RectTransform rect;
    private bool isGround = false;
    private bool climbcheck = true;
    private Vector2 scale = new Vector2(100, 100);
    private string wallTag = "Wall";


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
        isGround = ground.IsGround();
        //横移動
        rbody.velocity = new Vector2(Input.GetAxis("Horizontal")
            * moveSpeed, rbody.velocity.y);
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
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
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
        if (Input.GetKeyDown(KeyCode.LeftControl) && rbody.velocity.x != 0 && isGround)
        {
            Debug.Log("スライディング");
            transform.localRotation = Quaternion.Euler(0, 0, 90);
            StartCoroutine("AngleRepair");
        }
        if (isGround)
        {
            climbcheck = true;
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

    //壁登り　要修正(連打しないと飛ばない
    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log(climbcheck);
        if (other.gameObject.tag == wallTag && Input.GetKeyDown(KeyCode.Q) && climbcheck)
        {
            Debug.Log("climb!");
            rbody.velocity = new Vector2(rbody.velocity.x, climbPower);
            climbcheck = false;
        }
    }
}
