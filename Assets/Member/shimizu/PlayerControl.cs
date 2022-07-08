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
    private bool head_sliding = false;
    public byte changechara = 0;

    private float jumpanim = 0;
    public int atack_judge = 0;
    private bool incarnation_able = false;

    private bool isGround = false;
    private bool isWallright = false;
    private bool coroutine_able = true;
    private bool jumpreset = true;
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
        //�ҋ@���[�V����
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
                Debug.Log("ArcherRun");
                archeranim.SetBool("ArcherMove", true);
            }
        }
        //�L�����`�F���W
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameManagement.Instance.PlayerOrb += 10;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            GameManagement.Instance.PlayerOrb -= 10;
        }
        ////�L�����`�F���W���ۂ�
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

        if (Input.GetKeyDown(KeyCode.N))
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
        //�ڒn����Ɛڕǔ���
        isGround = ground.IsGround();
        isWallright = wallright.IsWall();

        //���ړ�
        if (coroutine_able && !head_sliding)
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
        //Debug.Log(sliding_judge);
        //���E���]
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

        //�W�����v
        if (jumpCount > 0 && isGround && jumpreset)
        {
            jumpreset = false;
            //Debug.Log("Reset");
            jumpCount = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount == 0 && coroutine_able)
        {
            //Debug.Log("������");
            jumpCount++;
            //Debug.Log("jump!");
            Jump();
            StartCoroutine(JumpReset());
        }
        else if (Input.GetKeyDown(KeyCode.Space) && jumpCount == 1 && coroutine_able)
        {
            //Debug.Log("2��ړ�����");
            jumpCount++;
            //Debug.Log("jump!");
            Jump2();
        }


        //�X���C�f�B���O
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGround && coroutine_able && rbody.velocity.x != 0 && sliding_judge)
        {
            if (GameManagement.Instance.PlayerCharacter == GameManagement.CharacterID.Bowman)
            {
                Debug.Log("�A�[�`���[���炢");
                sliding_judge = false;
                head_sliding = true;
                //sliding_anim.SetTrigger("Sliding");
                Debug.Log("�X���C�f�B���O");
                //�E����
                if (rbody.velocity.x > 0)
                {
                    anim.SetTrigger("Sliding");
                    archeranim.SetTrigger("ArcherSliding");
                    StartCoroutine("AngleRepairRight");
                    StartCoroutine("DodgeTag");
                }
                //������
                if (rbody.velocity.x < 0)
                {
                    anim.SetTrigger("SlidingLeft");
                    archeranim.SetTrigger("ArcherSliding");
                    StartCoroutine("AngleRepairLeft");
                    StartCoroutine("DodgeTag");
                }
            }
            //�����̃w�b�h�X���C�f�B���O
            if (GameManagement.Instance.PlayerCharacter == GameManagement.CharacterID.Girl)
            {
                sliding_judge = false;
                head_sliding = true;
                gilranim.SetBool("GirlSliding", true);
                StartCoroutine("DodgeTag");
                if (rbody.velocity.x > 0)
                {
                    anim.SetTrigger("GirlSliding");
                    StartCoroutine("AngleRepairRight");
                    StartCoroutine("DodgeTag");
                }
                if (rbody.velocity.x < 0)
                {
                    anim.SetTrigger("GirlSlidingLeft");
                    StartCoroutine("AngleRepairLeft");
                    StartCoroutine("DodgeTag");
                }
            }
        }


        //�Ǔo��
        if (isWallright && coroutine_able && Input.GetKeyDown(KeyCode.RightShift))
        {
            Debug.Log("�Ǔo��");
            coroutine_able = false;
            if (atack_judge == 0)
            {
                gilranim.SetBool("GirlClimb", true);
            }
            else if (atack_judge == 1)
            {
                swordmananim.SetBool("SwordClimb", true);
            }
            else if (atack_judge == 2)
            {
                archeranim.SetBool("ArcherClimb", true);
            }
            StartCoroutine("Climb");
        }

    }
    //�W�����v�̋���
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
        //Debug.Log("�W�����v�Q���");
        rbody.velocity = new Vector2(rbody.velocity.x, jumpForce);
    }
    //�X���C�f�B���O�ł̉�]�𒼂�
    //�E�����Ă鎞
    IEnumerator AngleRepairRight()
    {
        //float j = Input.GetAxis("Horizontal");
        //for (int i = 0; i < 150; i++)
        //{
        //    if (Input.GetAxis("Horizontal") < j)
        //    {

        //        anim.SetBool("Sliding", false);
        //        transform.localRotation = Quaternion.Euler(0, 0, 0);    //�����R���C�_�[�ύX�ɕς���
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
    //�������Ă鎞
    IEnumerator AngleRepairLeft()
    {
        //float j = Input.GetAxis("Horizontal");
        //for (int i = 0; i < 150; i++)
        //{
        //    if (Input.GetAxis("Horizontal") > j)
        //    {

        //        anim.SetBool("SlidingLeft", false);
        //        transform.localRotation = Quaternion.Euler(0, 0, 0);  //�����R���C�_�[�̕ύX�ɕς���
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
                rbody.isKinematic = false;
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
}