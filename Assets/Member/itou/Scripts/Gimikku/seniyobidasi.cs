using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seniyobidasi : MonoBehaviour
{
    GameObject ManageObject;
    Sceneseni fadeManager;
    // Start is called before the first frame update
    void Start()
    {
        //SceneFadeManager���A�^�b�`����Ă���I�u�W�F�N�g���擾
        ManageObject = GameObject.Find("ManageObject");
        //�I�u�W�F�N�g�̒���SceneFadeManager���擾
        fadeManager = ManageObject.GetComponent<Sceneseni>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            //SceneFadeManager�̒��̃t�F�[�h�A�E�g�J�n�֐����Ăяo��
            fadeManager.fadeOutStart(0, 0, 0, 0, "MapTutorial");
        }
    }
}