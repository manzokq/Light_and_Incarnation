using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    private GameObject playerObject;//プレイヤー
    [SerializeField] private GameObject chargeObject;
    [SerializeField] private GameObject explosionObject;
    private float playerRange;//プレイヤーとの距離

    Vector2 force;

    //生成する毒
    [SerializeField] GameObject poison = null;

    //弾を保持（プーリング）する空のオブジェクト
    Transform poisons;
    //アニメーター
    public Animator Anim;

    private bool inCamera;

    EnemySearch enemySearch = new EnemySearch();

    private bool slimeSearch=false;

    //private Rigidbody2D rb;
    protected override void Start()
    {
        base.Start();
        playerObject = GameObject.FindWithTag("Player");
        //rb = GetComponent<Rigidbody2D>();
    }

    protected override void Update()
    {
        base.Update();
        //プレイヤーまでの距離を出す
        this.playerRange = Vector2.Distance(playerObject.transform.position, this.transform.position);
       

        slimeSearch = enemySearch.Search;
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
            else
            {
                StartCoroutine(Move());
            }
            //確率で爆発に派生

        }
    }

    public IEnumerator Move()//移動の処理
    {
        Vector2 scale = transform.localScale;
        if (playerRange<3)
        {
            //プレイヤー側に移動
            Vector3 pv = playerObject.transform.position;
            Vector3 ev = transform.position;

            float p_vX = pv.x - ev.x;
            float p_vY = pv.y - ev.y;

            float vx = 0f;
            float vy = 0f;

            float sp = enemyDate.speed;

            // 減算した結果がマイナスであればXは減算処理
            if (p_vX < 0)
            {
                vx = -sp;
            }
            else
            {
                vx = sp;
            }

            //// 減算した結果がマイナスであればYは減算処理
            //if (p_vY < 0)
            //{
            //    vy = -sp;
            //}
            //else
            //{
            //    vy = sp;
            //}

            transform.Translate(vx / 50, vy / 50, 0);

        }
        else if(playerRange>2)
        {
            this.transform.Translate(Vector2.left * Time.deltaTime * enemyDate.speed);
            if(!slimeSearch)
            {
                enemyDate.speed = enemyDate.speed * -1;
                scale.x = scale.x * -1;
             //進行方向の反転   
            }
        }
            yield return null;
    }
    public IEnumerator Charge()//突進した時の処理
    {
        //seを呼び出す
        //atk10
        yield return null;
    }
    public IEnumerator Poison()//毒攻撃した時の処理
    {
        //seを呼び出す
        Instpoison(playerObject.transform.position, playerObject.transform.rotation);
        //毒生成
        yield return null;
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
        //seを呼び出す
        yield return new WaitForSeconds(3.0f);
        //atk20
        //
    }

    //public IEnumerator Damaged()//被弾した時の処理
    //{
    //    yield return null;
    //}
    public IEnumerator Destroy()//踏まれた時の処理
    {
        this.Hp = 0;
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
        slimeSearch = false;
    }
}