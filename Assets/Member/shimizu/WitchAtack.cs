using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchAtack : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    Animator animWitch;

    private bool magicballAble = true;
    private bool iceballAble = true;
    private bool blackholeAble = true;
    private float magicballTime = 0;
    private float iceballTime = 0;
    private float blackholeTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        #region クールタイム処理(未実装)
        if (magicballAble == false)
        {
            magicballTime += Time.deltaTime;
            if (magicballTime >= 2)
            {
                magicballAble = true;
                magicballTime = 0;
            }
        }
        if (iceballAble == false)
        {
            iceballTime += Time.deltaTime;
            if (iceballTime >= 5)
            {
                iceballAble = true;
                iceballTime = 0;
            }
        }
        if (blackholeAble == false)
        {
            blackholeTime += Time.deltaTime;
            if (blackholeTime >= 10)
            {
                blackholeAble = true;
                blackholeTime = 0;
            }
        }
        #endregion
        //Pを押すと魔弾
        if (Input.GetKeyDown(KeyCode.P) && magicballAble)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var witch_judge = playerControl.changechara;
            if (witch_judge == 1)
            {
                anim.SetTrigger("MagicBall");
                animWitch.SetTrigger("MagicBall2");
                //ここ分かんなかったからコメントアウト
                //GameManagement.Instance.PlayerCharacter = GameManagement.Character.Wizard;
                //GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
            }
            //magicballAble = false;
            
        }
        //Lを押すと氷弾
        if (Input.GetKeyDown(KeyCode.L) && iceballAble)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var witch_judge = GetComponent<PlayerControl>().changechara;
            if (witch_judge == 1)
            {
                anim.SetTrigger("IceBall");
                animWitch.SetTrigger("IceBall2");
                //ここ分かんなかったからコメントアウト
                //GameManagement.Instance.PlayerCharacter = GameManagement.Character.Wizard;
                //GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
            }
            //iceballAble = false;
        }
        //Oを押すとブラックホール
        if (Input.GetKeyDown(KeyCode.O) && blackholeAble)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var witch_judge = GetComponent<PlayerControl>().changechara;
            if (witch_judge == 1)
            {
                anim.SetTrigger("BlackHole");
                animWitch.SetTrigger("BlackHole2");
                //ここ分かんなかったからコメントアウト
                //GameManagement.Instance.PlayerCharacter = GameManagement.Character.Wizard;
                //GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
            }
            //blackholeAble = false;
        }

        //----コントローラー----
        //魔弾
        if (Input.GetKeyDown("joystick button 1") && magicballAble)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var witch_judge = playerControl.changechara;
            if (witch_judge == 1)
            {
                anim.SetTrigger("MagicBall");
                animWitch.SetTrigger("MagicBall2");
                //ここ分かんなかったからコメントアウト
                //GameManagement.Instance.PlayerCharacter = GameManagement.Character.Wizard;
                //GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
            }
            //magicballAble = false;

        }
        //氷弾
        if (Input.GetKeyDown("joystick button 1") && iceballAble)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var witch_judge = GetComponent<PlayerControl>().changechara;
            if (witch_judge == 1)
            {
                anim.SetTrigger("IceBall");
                animWitch.SetTrigger("IceBall2");
                //ここ分かんなかったからコメントアウト
                //GameManagement.Instance.PlayerCharacter = GameManagement.Character.Wizard;
                //GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
            }
            //iceballAble = false;
        }
        //ブラックホール
        if (Input.GetKeyDown("joystick button 1") && blackholeAble)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
            var witch_judge = GetComponent<PlayerControl>().changechara;
            if (witch_judge == 1)
            {
                anim.SetTrigger("BlackHole");
                animWitch.SetTrigger("BlackHole2");
                //ここ分かんなかったからコメントアウト
                //GameManagement.Instance.PlayerCharacter = GameManagement.Character.Wizard;
                //GameManagement.Instance.Atk = GameManagement.AtkID.Atk1;
            }
            //blackholeAble = false;
        }
    }
}
