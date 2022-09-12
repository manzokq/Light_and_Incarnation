using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverText : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textMeshProUGUI;
    #region 宣言
    [SerializeField]
    private Vector3 StartPoz;
    [SerializeField]
    private Vector3 EndPoz;
    private bool goNextScene = false;
    private bool GameSelection = true;
    private bool inputFrag = false;
    [SerializeField]
    private string GameScene;

    #endregion
    private void Awake()
    {
        GameScene = GameManagement.Instance.SetMapScenes();
    }
    private void Start()
    {
        transform.position = StartPoz;
        textMeshProUGUI.text = GameScene;
        goNextScene = false;
        inputFrag = true;
    }
    //Update
    private void Update()
    {
        //(Input.GetKeyDown(KeyCode.UpArrow) ||)
        //(Input.GetKeyDown(KeyCode.DownArrow) ||)
        //↑キーが押された時
        if (Input.GetAxis("L_Stick_V") < -0.5f)
        {
            Debug.Log("上");
            this.transform.position = StartPoz;
            GameSelection = true;
        }
        //↓キーが押された時
        if (Input.GetAxis("L_Stick_V") > 0.5f)
        {
            Debug.Log("下");
            this.transform.position = EndPoz;
            GameSelection = false;
        }
        //とりあえず仮置きの決定ボタン
        if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.Space) && inputFrag)
        {
            inputFrag = false;
            goNextScene = true;
        }
        //画面遷移
        if (goNextScene)
        {
            Debug.Log("呼ばれたよ");
            goNextScene = false;
            //-90ifの条件を追加予定
            //ゲームを続ける
            if (GameSelection)
            {

                //チュートリアル
                if (GameScene == "MapTutorial")
                {//ダンジョンの最初から用
                    SceneManager.LoadScene("MapTutorial");

                }
                //ステージ１
                else if (GameScene == "Map1")
                {//ステージ１から用
                    SceneManager.LoadScene("Map1");

                }
                else if (GameScene == "Map1RE")
                {
                    SceneManager.LoadScene("Map1RE");
                }
                //ステージ２
                else if (GameScene == "Map2")
                { //ステージ２から用
                    SceneManager.LoadScene("Map2");

                }
                else if (GameScene == "Map2RE")
                {
                    SceneManager.LoadScene("Map2RE");
                }
                //中間地点
                else if (GameScene == "MapBoss")
                {//ボス戦から用
                    SceneManager.LoadScene("MapBoss");

                }
                else
                {//タイトルに戻る
                    SceneManager.LoadScene("GameOP");

                }
            }
            else
            {//タイトルに戻る
                SceneManager.LoadScene("GameOP");

            }
        }

    }
}
