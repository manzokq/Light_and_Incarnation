using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move1 : MonoBehaviour
{
    //最初のアップデートの前に呼び出される（一度だけ）
    // Start is called before the first frame update


	int num=1;
    void Start()
    {
        //自身の座標をx方向に+3移動させる
	this.transform.Translate(new Vector3 (0f,0f,0f));
    }

    //毎フレーム呼び出される関数
    // Update is called once per frame
    void Update()
    {
	//自身の座標をx方向に-1移動させる
	//Time.deltaTimeは前回のフレームからの経過秒数
        //this.transform.Translate(new Vector3 (-5f * Time.deltaTime,0f,0f));
	//Wキーが押された時
	if(Input.GetKeyDown(KeyCode.UpArrow)&&num!=1)
	{
	   this.transform.Translate(new Vector3 (0f,0.5f,0f));
	   num-=1;
	}
	//Sキーが押された時
	if(Input.GetKeyDown(KeyCode.DownArrow)&&num!=3)
	{
	   this.transform.Translate(new Vector3 (0f,-0.5f,0f));
	   num+=1;
	}

	if(Input.GetKeyDown(KeyCode.Return))
	{
		switch(num)
		{
			case 1:
			SceneManager.LoadScene("SampleScene");   
			break;
			case 2:
			SceneManager.LoadScene("Next");  
			break;
			case 3:

			break;

			default:
			break;
		}

	}
    }
    //1秒間に実行される関数が決まっているUpdate関数
    void FixedUpdate()
    {
	
    }
}
