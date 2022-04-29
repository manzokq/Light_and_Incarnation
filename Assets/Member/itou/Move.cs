using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //最初のアップデートの前に呼び出される（一度だけ）
    // Start is called before the first frame update
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
	//Aキーが押された時
	if(Input.GetKey(KeyCode.A))
	{
	   this.transform.Translate(new Vector3 (-5f * Time.deltaTime,0f,0f));
	}
	//Dキーが押された時
	if(Input.GetKey(KeyCode.D))
	{
	   this.transform.Translate(new Vector3 (5f * Time.deltaTime,0f,0f));
	}
	//Wキーが押された時
	if(Input.GetKey(KeyCode.W))
	{
	   this.transform.Translate(new Vector3 (0f,5f * Time.deltaTime,0f));
	}
	//Sキーが押された時
	if(Input.GetKey(KeyCode.S))
	{
	   this.transform.Translate(new Vector3 (0f,-5f * Time.deltaTime,0f));
	}
    }
    //1秒間に実行される関数が決まっているUpdate関数
    void FixedUpdate()
    {
	
    }
}
