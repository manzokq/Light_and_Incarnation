using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{


}


////スコアを付ける
//[SerializeField, Header("スコア")]
//public float score_ = 0;
//// Start is called before the first frame update
//void Start()
//{

//}

//// Update is called once per frame
//void Update()
//{

//}
//// 2Dの場合のトリガー判定
//private void OnTriggerEnter2D(Collider2D collision)
//{
//    // 物体がトリガーに接触しとき、１度だけ呼ばれる
//    Debug.Log("b");
//    //接触したオブジェクトのタグが"Orb"のとき
//    if (collision.gameObject.tag == ("Player"))
//    {
//        Destroy(this.gameObject);
//    }
//}