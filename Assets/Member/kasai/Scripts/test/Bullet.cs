using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        //右方向に移動
        transform.position += transform.right * 10 * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        //画面外に行ったら非アクティブにする
        gameObject.SetActive(false);
    }
}