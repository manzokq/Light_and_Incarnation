using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneChingPlayer : MonoBehaviour
{

    [SerializeField]
    Animator girl, swordman, archer;
    [SerializeField]
    Rigidbody2D player;
    enum Gatenum
    {
        None = 0,
        Gate1,
        Gate2,
        Gate3,
        Gate4,
    }

    Gatenum gate;

    //�������Q�[�g���L������
    [SerializeField]
    public static int Gate_Number = 0;

    public int number = 0;

    [SerializeField]
    string getOut,comeIn;
    GameObject door;
    GameObject[] doors;

    int enterGatenum;

    //�v���[���[�����B���Ȃ��悤��
    public static SceneChingPlayer instance = null;

    private void Awake()//Start�O�ɏ���
    {
        player.velocity = new Vector2(0, 0);
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    void Update()
    {
        if(Input.GetKeyDown("joystick button 3")||Input.GetKeyDown(KeyCode.I))
        {
            if(gate != Gatenum.None)
            {
                Change();
            }
            else
            {
                //Debug.Log("�h�A��0����");
            }
        }
    }

    //�V�[���؂�ւ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Gate")
        {
            door = collision.gameObject;
            GetExit();
            Change();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gate = Gatenum.None;
    }

    void Change()
    {
        if (SceneManager.GetActiveScene().name =="MapBoss")
        {
            this.gameObject.GetComponent<XboxPlayerContorol>().ClearReturnGirl();
        }
        if (SceneManager.GetActiveScene().name != getOut)
        {
            SceneManager.LoadScene(getOut);
        }
        else
        {
            SceneManager.LoadScene(comeIn);
        }
        //���̃V�[������Ȃ����ɔ��
    }
    void GetExit()
    {
        if(door.GetComponent<Gate>()!=null)
        { //�h�A��������o���A���̔ԍ����擾
            getOut = door.GetComponent<Gate>().ReturnExit1();
            comeIn = door.GetComponent<Gate>().ReturnExit2();
            gate = (Gatenum)Enum.ToObject(typeof(Gatenum), door.GetComponent<Gate>().ReturnGatenum());
        }
    }
    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        this.gameObject.GetComponent<XboxPlayerContorol>().HideAtack();
        Debug.Log("onSceneLoad");
        XboxPlayerContorol.deathCheck = true;
        player.velocity = new Vector2(0, 0);
        WallCheck.isWall = false;
        girl.SetBool("GirlDeath",false);
        girl.SetBool("GirlSliding", false);
        girl.SetBool("GirlSliding1", false);
        girl.SetBool("GirlSliding2", false);
        girl.SetBool("GirlClimb", false);
        girl.Play("Locomotion");
        archer.Play("Locomotion");
        swordman.Play("Locomotion");
        doors = GameObject.FindGameObjectsWithTag("Gate");
        foreach (var obj in doors)
        {
            if ((int)gate == obj.gameObject.GetComponent<Gate>().ReturnGatenum())
            {
                //�S�h�A������ԍ�����v��������擾
                GameObject child = obj.gameObject.transform.GetChild(0).gameObject;
                this.gameObject.transform.position = new Vector3(
                    child.transform.position.x,
                    child.transform.position.y,
                    child.transform.position.z);
                //�V�[���ړ���ɔ��̋߂��̎q�I�u�W�F�Ɉړ�
            }
        }
        if (gate == Gatenum.None && GameObject.FindWithTag("target") != null)
        {
            var target = GameObject.FindWithTag("target");
            this.gameObject.transform.position = target.gameObject.transform.position;
            //Debug.Log("�h�A���Ȃ������̂Ńf�t�H���g�̏ꏊ�ɑJ��");
        }
        gate = Gatenum.None;
        //���ԍ���none
    }
}
