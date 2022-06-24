using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/*
 * P:�U��1
 * L:�U��2
 * O:�U��3
 * X:����U��
 * AD:�ړ�
 * Space:�W�����v
 * LShift:�X���C�f�B���O(�z�[���h��)
 * RShift:�Ǔo��
 * B:�I�[�u���[�h
 * N:���g�ω�
 * M:���g�I��
 */
public class PlayerControl : MonoBehaviour
{
    private SpriteRenderer spren;
    private Rigidbody2D rbody;
    private Animator anim;
    private bool sliding_judge = true;
    public bool atacking = false;
    public byte changechara = 0;

    public int atack_judge = 0;
    private bool incarnation_able = false;

    private bool isGround = false;
    private bool isWallright = false;
    private bool coroutine_able = true;
    [SerializeField] private float num_climb, translate_climb, time_climb;
    [SerializeField] GameObject chara;
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
        spren = GetComponent<SpriteRenderer>();
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(atacking);
        //�L�����`�F���W
        if (Input.GetKeyDown(KeyCode.B))
        {
            anim.SetBool("changeIncarnation", true);
        }
        if (Input.GetKeyDown(KeyCode.N))
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
            if(GameManagement.Instance.PlayerCharacter == (GameManagement.CharacterID)Enum.ToObject(typeof(GameManagement.CharacterID),
                changechara)|| 
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
        //�ڒn����Ɛڕǔ���
        isGround = ground.IsGround();
        isWallright = wallright.IsWall();

        //���ړ�
        if (coroutine_able)
        {
            rbody.velocity = new Vector2(Input.GetAxis("Horizontal")
                * moveSpeed, rbody.velocity.y);
        }
        //�Ǔo���Ă�Œ��̓r���ŕǂ��痣��邽��
        if (!coroutine_able)
        {
            if (isWallright)
            {
                if (Input.GetAxis("Horizontal") > 0 && scale.x < 0)
                {
                    rbody.isKinematic = false;
                    rbody.AddForce(new Vector2(1, 0) * 1);

                }
                if (Input.GetAxis("Horizontal") < 0 && scale.x > 0)
                {
                    rbody.isKinematic = false;
                    rbody.AddForce(new Vector2(-1, 0) * 1);
                }
            }
        }

        //���E���]
        if (rbody.velocity.x < 0 && !atacking)
        {
            scale.x = -100;
            transform.localScale = scale;
        }
        if (rbody.velocity.x > 0 && !atacking)
        {

            scale.x = 100;
            transform.localScale = scale;
        }

        //�W�����v
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

        //�X���C�f�B���O
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGround && coroutine_able && rbody.velocity.x != 0 && sliding_judge)
        {
            sliding_judge = false;
            //sliding_anim.SetTrigger("Sliding");
            Debug.Log("�X���C�f�B���O");
            //�E����
            if (rbody.velocity.x > 0)
            {
                anim.SetBool("Sliding", true);
                StartCoroutine("AngleRepairRight");
                StartCoroutine("DodgeTag");
            }
            //������
            if (rbody.velocity.x < 0)
            {
                anim.SetBool("SlidingLeft", true);
                StartCoroutine("AngleRepairLeft");
                StartCoroutine("DodgeTag");
            }
        }


        //�Ǔo��
        if (isWallright && coroutine_able && Input.GetKeyDown(KeyCode.RightShift))
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
    //�E�����Ă鎞
    IEnumerator AngleRepairRight()
    {
        float j = Input.GetAxis("Horizontal");
        for (int i = 0; i < 150; i++)
        {
            if (Input.GetAxis("Horizontal") < j)
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
    //�������Ă鎞
    IEnumerator AngleRepairLeft()
    {
        float j = Input.GetAxis("Horizontal");
        for (int i = 0; i < 150; i++)
        {
            if (Input.GetAxis("Horizontal") > j)
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
            if (!isWallright)
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
}
