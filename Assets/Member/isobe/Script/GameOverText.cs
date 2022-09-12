using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverText : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textMeshProUGUI;
    #region �錾
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
        //���L�[�������ꂽ��
        if (Input.GetAxis("L_Stick_V") < -0.5f)
        {
            Debug.Log("��");
            this.transform.position = StartPoz;
            GameSelection = true;
        }
        //���L�[�������ꂽ��
        if (Input.GetAxis("L_Stick_V") > 0.5f)
        {
            Debug.Log("��");
            this.transform.position = EndPoz;
            GameSelection = false;
        }
        //�Ƃ肠�������u���̌���{�^��
        if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown(KeyCode.Space) && inputFrag)
        {
            inputFrag = false;
            goNextScene = true;
        }
        //��ʑJ��
        if (goNextScene)
        {
            Debug.Log("�Ă΂ꂽ��");
            goNextScene = false;
            //-90if�̏�����ǉ��\��
            //�Q�[���𑱂���
            if (GameSelection)
            {

                //�`���[�g���A��
                if (GameScene == "MapTutorial")
                {//�_���W�����̍ŏ�����p
                    SceneManager.LoadScene("MapTutorial");

                }
                //�X�e�[�W�P
                else if (GameScene == "Map1")
                {//�X�e�[�W�P����p
                    SceneManager.LoadScene("Map1");

                }
                else if (GameScene == "Map1RE")
                {
                    SceneManager.LoadScene("Map1RE");
                }
                //�X�e�[�W�Q
                else if (GameScene == "Map2")
                { //�X�e�[�W�Q����p
                    SceneManager.LoadScene("Map2");

                }
                else if (GameScene == "Map2RE")
                {
                    SceneManager.LoadScene("Map2RE");
                }
                //���Ԓn�_
                else if (GameScene == "MapBoss")
                {//�{�X�킩��p
                    SceneManager.LoadScene("MapBoss");

                }
                else
                {//�^�C�g���ɖ߂�
                    SceneManager.LoadScene("GameOP");

                }
            }
            else
            {//�^�C�g���ɖ߂�
                SceneManager.LoadScene("GameOP");

            }
        }

    }
}
