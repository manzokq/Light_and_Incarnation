using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateChingScene : MonoBehaviour
{
    //�Q�[�g�ԍ����i�[����
    public static int Player_Gate = 0;

    // Start is called before the first frame update
    void Start()
    {
        //�v���[���[����̕ϐ����i�[����
        Player_Gate = SceneChingPlayer.Player_gate();
        Debug.Log("a"+Player_Gate);
    }

    // Update is called once per frame
    void Update()
    {
        //�Q�[�g�ԍ��ŏo��ʒu���w��
        switch (Player_Gate)
        {
            case 1:
                {
                    Vector3 tmp = GameObject.Find("Gate2").transform.position;
                    GameObject.Find("Player").transform.position = new Vector3(tmp.x, tmp.y - 3, tmp.z);
                    Player_Gate = 0;
                    break;
                }
            case 2:
                {
                    Vector3 tmp = GameObject.Find("Gate1").transform.position;
                    GameObject.Find("Player").transform.position = new Vector3(tmp.x+3, tmp.y, tmp.z);
                    Player_Gate = 0;
                    break;
                }            
            //case 3:
            //    {
            //        Vector3 tmp = GameObject.Find("Gate1").transform.position;
            //        GameObject.Find("Player").transform.position = new Vector3(tmp.x+3, tmp.y, tmp.z);
            //        tpss = 0;
            //        break;
            //    }         
            case 4:
                {
                    Vector3 tmp = GameObject.Find("Gate5").transform.position;
                    GameObject.Find("Player").transform.position = new Vector3(tmp.x+3, tmp.y, tmp.z);
                    Player_Gate = 0;
                    break;
                }         
            case 5:
                {
                    Vector3 tmp = GameObject.Find("Gate4").transform.position;
                    GameObject.Find("Player").transform.position = new Vector3(tmp.x+3, tmp.y, tmp.z);
                    Player_Gate = 0;
                    break;
                }
        }
    }
    //public static int gate_Player()
    //{
    //    //�v���[���[�̕ϐ���ύX
    //    return tpss;
    //}

}

