using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shots : MonoBehaviour
{
    // Rigidbody2D コンポーネントを格納する変数
    private Rigidbody2D rb;
    // 自機の移動速度を格納する変数（初期値 5）
    public float speed = 5;
    // PlayerBullet プレハブ
    public GameObject bullet;

    // ゲームのスタート時の処理
    void Start()
    {
        // Rigidbody2D コンポーネントを取得して変数 rb に格納
        rb = GetComponent<Rigidbody2D>();
        // 弾の発射処理（コルーチン Shot ）を実行
        StartCoroutine("Shot");
    }

    // ゲーム実行中の繰り返し処理
    void Update()
    {
        // 右・左のデジタル入力値を x に渡す
        float x = Input.GetAxisRaw("Horizontal");
        // 上・下のデジタル入力値 y に渡す
        float y = Input.GetAxisRaw("Vertical");
        // 移動する向きを求める
        // x と y の入力値を正規化して direction に渡す
        Vector2 direction = new Vector2(x, y).normalized;
        // 移動する向きとスピードを代入する
        // Rigidbody2D コンポーネントの velocity に方向と移動速度を掛けた値を渡す
        rb.velocity = direction * speed;
    }

    // 弾の発射処理（コルーチン）
    IEnumerator Shot()
    {
        while (true)
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            Instantiate(bullet, transform.position, transform.rotation);
            // 0.05秒待つ
            yield return new WaitForSeconds(0.05f);
        }
    }
}