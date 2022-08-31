using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Move1 : MonoBehaviour
{
    //最初のアップデートの前に呼び出される（一度だけ）
    // Start is called before the first frame update

    [SerializeField]
    int num = 1;
    bool inputFrag = true;
    void Start()
    {
        //自身の座標をx方向に+3移動させる
        this.transform.position = new Vector3(transform.position.x, -1.15f, 0f);
    }

    //毎フレーム呼び出される関数
    // Update is called once per frame
    void Update()
    {
        //自身の座標をx方向に-1移動させる
        //Time.deltaTimeは前回のフレームからの経過秒数
        //this.transform.Translate(new Vector3 (-5f * Time.deltaTime,0f,0f));
        //↑キーが押された時
        if (Input.GetKeyDown(KeyCode.UpArrow)||(Input.GetAxis("L_Stick_V") <-0.5f&&inputFrag))
        {
            inputFrag = false;
            this.transform.Translate(new Vector3(0f, 1.25f, 0f));
            num -= 1;
        }
        //↓キーが押された時
        if (Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetAxis("L_Stick_V")>0.5f&&inputFrag))
        {
            inputFrag = false;
            this.transform.Translate(new Vector3(0f, -1.25f, 0f));
            num += 1;
        }
        if (num! > 3)
        {
            this.transform.position = new Vector3(transform.position.x, -1.15f, 0f);
            num -= 3;
        }
        else if (num <= 0)
        {
            this.transform.position = new Vector3(transform.position.x, -3.65f, 0f);
            num += 3;
        }

        if(Input.GetAxis("L_Stick_V") <= 0.5f&& Input.GetAxis("L_Stick_V") >= -0.5f)
        {
            inputFrag = true;
        }
        /*if(Input.GetKeyDown(KeyCode.DownArrow)&&num!=3)
        {
           this.transform.Translate(new Vector3 (0f,-0.45f,0f));
           num+=1;
        }*/
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 1"))
        {
            switch (num)
            {
                case 1:
                    SceneManager.LoadScene("MapTutorial");
                    break;
                case 2:
                    SceneManager.LoadScene("Map1");
                    break;
                case 3:
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
                #else
                    Application.Quit();//ゲームプレイ終了
                #endif
                    break;
                default:
                    break;
            }

        }
    }
    //1秒間に実行される関数が決まっているUpdate関数k
    void FixedUpdate()
    {

    }
}
