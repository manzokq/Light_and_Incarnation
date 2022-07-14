using System.Collections;
using UnityEngine;

public class Slime : Enemy
{
    private GameObject playerObject;//プレイヤー
    [SerializeField] private GameObject chargeObject;
    //生成する毒
    [SerializeField] GameObject _poison;

    private float _playerRange;//プレイヤーとの距離
    [SerializeField] private int _chargeRange = 0;
    [SerializeField] private int _poisonRangeMin = 0;
    [SerializeField] private int _poisonRangeMax = 0;
    [SerializeField] private int _moveSwitchRange = 0;

    

    //弾を保持（プーリング）する空のオブジェクト
    //Transform poisons;

    private GameObject poisonobj = null;    
    private GameObject chargeobj = null;    

    private bool inCamera;

    private bool process = false;
    [SerializeField] private float recastTime=3.0f;

    protected override void Start()
    {
        base.Start();
        playerObject = GameObject.FindWithTag("Player");
        poisonobj = _poison;//.GetComponent<GameObject>();
        chargeobj = chargeObject;//.GetComponent<GameObject>();
        //Debug.Log(chargeobj);
        //chargeobj.GetComponent<Charge>().atk = Atk1;
        chargeObject.SetActive(false);
        poisonobj = Instantiate(_poison);
        //poisonobj.GetComponent<Poison>().atk = Atk1;
        poisonobj.SetActive(false);


    }

    protected override void Update()
    {
        base.Update();
        //プレイヤーまでの距離を出す
        this._playerRange = Vector2.Distance(playerObject.transform.position, this.transform.position);
        //デバッグ用
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    MoveFragSwitch(false);
        //    Debug.Log("おした");
        //}
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    MoveFragSwitch(true);
        //    Debug.Log("おした");
        //}
        if (inCamera)
        {
            if (_playerRange < _chargeRange)
            {
                StartCoroutine(Charge());                
            }
            else if (_playerRange > _poisonRangeMin && _playerRange < _poisonRangeMax)
            {
                StartCoroutine(Poison());
            }

            if (_playerRange < _moveSwitchRange)
            {
                MoveFragSwitch(false);
            }
            else if (_playerRange >= _moveSwitchRange)
            {
                MoveFragSwitch(true);
            }

        }
        else
        {
            MoveFragSwitch(false);
        }
    }

    
    public IEnumerator Charge()//突進した時の処理
    {
        if (!process)
        {
            process = true;
            
            MoveFragSwitch(false);//移動を一時停止
            //アニメーションを呼び出す
            Anim.SetTrigger("Attack");
            //オブジェクトを有効化
            chargeobj.GetComponent<Charge>().atk = Atk1;
            chargeObject.SetActive(true);//当たり判定の有効化
            //Debug.Log("Charge");
            //chargeObject.SetActive(false);//当たり判定の無効化
            yield return new WaitForSeconds(recastTime);

            MoveFragSwitch(true);//移動を再開
            process = false;
        }
    }
    public IEnumerator Poison()//毒攻撃した時の処理
    {
        if (!process)
        {
            
            process = true;
            //seを呼び出す
            Anim.SetTrigger("Attack");
            //Debug.Log(poisonobj);
            yield return new WaitForSeconds(1.0f);//1秒のラグを作る
            poisonobj.GetComponent<Poison>().atk = Atk1;
            poisonobj.transform.position=new Vector2(playerObject.transform.position.x, playerObject.transform.position.y);
            poisonobj.SetActive(true);
            //Instpoison(new Vector2(
            //    playerObject.transform.position.x,
            //    this.gameObject.transform.position.y),
            //    playerObject.transform.rotation);
            //毒生成
            yield return new WaitForSeconds(recastTime);
            process = false;
        }
    }

    //void Instpoison(Vector2 pos, Quaternion rotation)
    //{
    //    //アクティブでないオブジェクトをbulletsの中から探索
    //    foreach (Transform t in poisons)
    //    {
    //        if (!t.gameObject.activeSelf)
    //        {
    //            //非アクティブなオブジェクトの位置と回転を設定
    //            t.SetPositionAndRotation(pos, rotation);
    //            //アクティブにする
    //            t.gameObject.SetActive(true);
    //            return;
    //        }
    //    }
    //    //非アクティブなオブジェクトがない場合新規生成

    //    //生成時にbulletsの子オブジェクトにする



    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("WallBreak")||collision.gameObject.CompareTag("Sword"))
        {
            Hp = GameManagement.Instance.PlayerAtk(Hp);
            //Debug.LogWarning("腱に触れた");
        }
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