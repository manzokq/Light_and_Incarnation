using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //生成する弾
    [SerializeField] GameObject bullet = null;

    //弾を保持（プーリング）する空のオブジェクト
    Transform bullets;
    void Start()
    {
        //弾を保持する空のオブジェクトを生成
        bullets = new GameObject("PlayerBullets").transform;
    }

    void Update()
    {
        //まわれまーわれメリーゴーランド
        transform.Rotate(0, 0, 0.5f);

        //弾生成関数を呼び出し
        InstBullet(transform.position, transform.rotation);
    }

    /// <summary>
    /// 弾生成関数
    /// </summary>
    /// <param name="pos">生成位置</param>
    /// <param name="rotation">生成時の回転</param>
    void InstBullet(Vector3 pos, Quaternion rotation)
    {
        //アクティブでないオブジェクトをbulletsの中から探索
        foreach (Transform t in bullets)
        {
            if (!t.gameObject.activeSelf)
            {
                //非アクティブなオブジェクトの位置と回転を設定
                t.SetPositionAndRotation(pos, rotation);
                //アクティブにする
                t.gameObject.SetActive(true);
                return;
            }
        }
        //非アクティブなオブジェクトがない場合新規生成

        //生成時にbulletsの子オブジェクトにする
        Instantiate(bullet, pos, rotation, bullets);
    }
}