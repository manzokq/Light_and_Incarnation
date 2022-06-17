using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAtack : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    Animator animArcher;
    [SerializeField]
    GameObject arrow;

    private bool arrowAble = true;
    private bool firearrowAble = true;
    private bool doublearrowAble = true;
    private bool longbowAble = true;
    private float arrowTime = 0;
    private float firearrowTime = 0;
    private float doublearrowTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerControl pcon = GetComponent<PlayerControl>();
        anim = GetComponent<Animator>();
        //swordCollider = GameObject.Find("swordnonamae").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        #region �N�[���^�C������(������)
        if (arrowAble == false)
        {
            arrowTime += Time.deltaTime;
            if (arrowTime >= 2)
            {
                arrowAble = true;
                arrowTime = 0;
            }
        }
        if (firearrowAble == false)
        {
            firearrowTime += Time.deltaTime;
            if (firearrowTime >= 5)
            {
                firearrowAble = true;
                firearrowTime = 0;
            }
        }
        if (doublearrowAble == false)
        {
            doublearrowTime += Time.deltaTime;
            if (doublearrowTime >= 10)
            {
                doublearrowAble = true;
                doublearrowTime = 0;
            }
        }
        #endregion
        GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
        //P�������ƒʏ�|�U��
        if (Input.GetKeyDown(KeyCode.P) && arrowAble)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var archer_judge = playerControl.atack_judge;
            if (archer_judge == 2)
            {
                anim.SetTrigger("Arrow");
                animArcher.SetTrigger("Arrow2");
                //GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Bowman;
                //.Instance.Atk = GameManagement.AtkID.Atk1;
            }
        }

        //L�������ƉΖ�
        if (Input.GetKeyDown(KeyCode.L) && firearrowAble)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var archer_judge = playerControl.atack_judge;
            if (archer_judge == 2)
            {
                anim.SetTrigger("FireArrow");
                animArcher.SetTrigger("FireArrow2");
                //GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Bowman;
                //.Instance.Atk = GameManagement.AtkID.Atk1;
            }
        }

        //O�������Ɠ��
        if (Input.GetKeyDown(KeyCode.O) && doublearrowAble)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var archer_judge = playerControl.atack_judge;
            if (archer_judge == 2)
            {
                anim.SetTrigger("DoubleArrow");
                animArcher.SetTrigger("DoubleArrow2");
            }
        }

        //X��������(����U��)
        if (Input.GetKeyDown(KeyCode.J) && longbowAble)
        {
            PlayerControl playerContorol = GetComponent<PlayerControl>();
            var archer_judge = playerContorol.atack_judge;
            if (archer_judge == 2)
            {
                arrow.tag = "LongBow";
                anim.SetTrigger("LongBow");
                animArcher.SetTrigger("LongBow2");
                StartCoroutine("TagReset");
            }
        }

        //----�R���g���[���[����----
        //�ʏ�|�U��
        if (Input.GetKeyDown("joystick button 1") && arrowAble && GameManagement.Instance.Atk == GameManagement.AtkID.Atk1)
        {
            XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
            var archer_judge = xboxPlayerContorol.atack_judge_con;
            if (archer_judge == 2)
            {
                anim.SetBool("Arrow", true);
                animArcher.SetTrigger("Arrow2");
                GameManagement.Instance.PlayerCharacter = GameManagement.CharacterID.Swordsman;
                GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
            }

            //slashable = false;
        }

        //�Ζ�
        if (Input.GetKeyDown("joystick button 1") && firearrowAble && GameManagement.Instance.Atk == GameManagement.AtkID.Atk2)
        {
            XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
            var archer_judge = xboxPlayerContorol.atack_judge_con;
            if (archer_judge == 2)
            {
                anim.SetTrigger("FireArrow");
                animArcher.SetTrigger("FireArrow2");
            }
        }

        //���
        if (Input.GetKeyDown("joystick button 1") && doublearrowAble && GameManagement.Instance.Atk == GameManagement.AtkID.Atk3)
        {
            XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
            var archer_judge = xboxPlayerContorol.atack_judge_con;
            if (archer_judge == 2)
            {
                anim.SetTrigger("DoubleArrow");
                animArcher.SetTrigger("DoubleArrow2");
            }
        }

        //(����U��)
        if (Input.GetKeyDown("joystick button 2") && longbowAble)
        {
            XboxPlayerContorol xboxPlayerContorol = GetComponent<XboxPlayerContorol>();
            var archer_judge = xboxPlayerContorol.atack_judge_con;
            if (archer_judge == 2)
            {
                Debug.Log("����U��");
                arrow.tag = "LongBow";
                anim.SetTrigger("LongBow");
                animArcher.SetTrigger("LongBow2");
                StartCoroutine("TagReset");
            }
        }
    }
    private IEnumerator TagReset()
    {
        yield return new WaitForSeconds(1f);
        arrow.tag = "Arrow";
    }
}
//�ʏ�U���A�Ζ�A���
