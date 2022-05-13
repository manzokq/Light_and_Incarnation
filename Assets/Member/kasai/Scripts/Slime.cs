using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    [SerializeField] private GameObject playerObject;//プレイヤー
    private float playerRange;//プレイヤーとの距離
    //生成する毒
    [SerializeField] GameObject poison = null;

    //弾を保持（プーリング）する空のオブジェクト
    Transform poisons;
    //アニメーター
    public Animator Anim;

    private bool inCamera;

    //public enum SlimeState
    //{
    //    Move,
    //    Charge,
    //    Poison,
    //    Explosion,
    //    Damaged,
    //    Null
    //}
    //public SlimeState slimestate = SlimeState.Null;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        //プレイヤーまでの距離を出す
        this.playerRange = Vector2.Distance(playerObject.transform.position, this.transform.position);
        ////弾生成関数を呼び出し
        //InstPoison(transform.position, transform.rotation);

        if(playerRange<2)
        {
            StartCoroutine(Charge());
        }
        else 
        {
            StartCoroutine(Move());
        }
        
    }

    public IEnumerator Move()//移動の処理
    {
        if(inCamera)
        {
            
        }
        if(playerRange<2)
        {

        }
        if(true)//障害物orその先に床がないなら反転
            yield return null;
    }
    public IEnumerator Charge()//突進した時の処理
    {
        //seを呼び出す
        //
        yield return null;
    }
    public IEnumerator Poison()//毒攻撃した時の処理
    {
        //seを呼び出す
        //
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
        //
        yield return null;
    }

    public IEnumerator Damaged()//被弾した時の処理
    {
        yield return null;
    }
    public IEnumerator Destroy()//踏まれた時の処理
    {
        this.Hp = 0;
        //seを呼び出す
        //
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

}
