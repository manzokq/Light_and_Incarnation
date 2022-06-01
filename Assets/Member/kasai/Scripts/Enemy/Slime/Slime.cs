using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    //private Rigidbody2D rb;
    private GameObject playerObject;//プレイヤー
    [SerializeField] private GameObject chargeObject;
    [SerializeField] private GameObject explosionObject;
    private float playerRange;//プレイヤーとの距離

    //生成する毒
    [SerializeField] GameObject poison = null;

    //弾を保持（プーリング）する空のオブジェクト
    Transform poisons;
    //アニメーター
    public Animator Anim;

    private bool inCamera;

    FloorSearch floorSearch = new();

    private bool slimeSearch=false;
    private bool process = false;
    protected override void Start()
    {
        base.Start();
        //rb = GetComponent<Rigidbody2D>();
        playerObject = GameObject.FindWithTag("Player");
    }

    protected override void Update()
    {
        base.Update();
        //プレイヤーまでの距離を出す
        this.playerRange = Vector2.Distance(playerObject.transform.position, this.transform.position);
       

        slimeSearch = floorSearch.Search;
        if (inCamera)
        {
            if (playerRange < 2)
            {
                StartCoroutine(Charge());
            }
            else if(playerRange>4&&playerRange<7)
            {
                StartCoroutine(Poison());
            }
            //else if(true)
            //{
            //    StartCoroutine(Explosion());
            //}
            if(playerRange>3)
            {
                StartCoroutine(Move());
            }
            //確率で爆発に派生

        }
    }

    public IEnumerator Move()//移動の処理
    {
        Vector2 scale = transform.localScale;
        if (inCamera)
        {
            rb.velocity = new Vector2(enemyDate.speed, rb.velocity.y);

            //if (!slimeSearch)
            //{
            //    enemyDate.speed = enemyDate.speed * -1;
            //    scale.x = scale.x * -1;
            //    //進行方向の反転   
            //}一時的に無効化
        }
        yield return null;
    }
    public IEnumerator Charge()//突進した時の処理
    {
        if (!process)
        {
            process = true;

            //seを呼び出す
            yield return new WaitForSeconds(1.0f);
            //atk10
            //
            process = false;
        }
    }
    public IEnumerator Poison()//毒攻撃した時の処理
    {
        if (!process)
        {
            process = true;
            //seを呼び出す
            Instpoison(playerObject.transform.position, playerObject.transform.rotation);
            //毒生成
            yield return new WaitForSeconds(1.0f);
            process = false;
        }
    }

    void Instpoison(Vector2 pos, Quaternion rotation)
    {
        //アクティブでないオブジェクトをbulletsの中から探索
        foreach (Transform t in poisons)
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
        Instantiate(poison, pos, rotation, poisons);
    }
    public IEnumerator Explosion()//自爆した時の処理
    {
        
        if (!process)
        {
            process = true;

            //seを呼び出す
            yield return new WaitForSeconds(1.0f);
            //atk20
            //
            process = false;
        }
        
    }
    public IEnumerator Destroy()//踏まれた時の処理
    {
        this.enemyDate.hp = 0;
        //seを呼び出す
        yield return null;
    }

    //カメラ内にいるかどうかの処理(レンダラーコンポーネントが必要)
    private void OnBecameInvisible()
    {
        inCamera = false;
    }
    private void OnBecameVisible()
    {
        inCamera = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            slimeSearch = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}