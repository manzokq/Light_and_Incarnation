using System.Collections;
using UnityEngine;

public class Slime : Enemy
{
    private GameObject playerObject;//プレイヤー
    [SerializeField] private GameObject chargeObject;
    //生成する毒
    [SerializeField] GameObject _poison;

    private float _playerRange;//プレイヤーとの距離
    //各攻撃の実行する範囲
    [SerializeField] private int _chargeRange = 0;
    [SerializeField] private int _poisonRangeMin = 0;
    [SerializeField] private int _poisonRangeMax = 0;

    //移動処理の切り替え
    [SerializeField] private int _moveSwitchRange = 0;

    private GameObject poisonobj = null;    
    private GameObject chargeobj = null;    

    private bool inCamera;

    private bool process = false;//これがtrueの間は別の処理を実行しない
    [SerializeField] private float _recastTime=3.0f;//攻撃の周期
    [SerializeField] private float _poisonDelay=2.0f;//攻撃の周期


    protected override void Start()
    {
        base.Start();
        playerObject = GameObject.FindWithTag("Player");
        poisonobj = _poison;
        chargeobj = chargeObject;

        chargeObject.SetActive(false);//攻撃の当たり判定
        poisonobj = Instantiate(_poison);//攻撃の当たり判定
        //poisonobj.GetComponent<Poison>().atk = Atk1;
        poisonobj.SetActive(false);


    }

    protected override void Update()
    {
        base.Update();
       
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
            StartCoroutine(AtkChoices());

        }
        else
        {
            MoveFragSwitch(false);
        }
    }

    public IEnumerator AtkChoices() 
    {
        if (!process)
        {
            process = true;
            //プレイヤーまでの距離を出す
            this._playerRange = Vector2.Distance(playerObject.transform.position, this.transform.position);
            if (_playerRange < _chargeRange)
            {
                MoveFragSwitch(false);//移動を一時停止
                StartCoroutine(Charge());
                
            }
            else if (_playerRange > _poisonRangeMin && _playerRange < _poisonRangeMax)
            {
                MoveFragSwitch(false);//移動を一時停止
                StartCoroutine(Poison());

            }

            if (_playerRange < _moveSwitchRange)
            {
                //MoveFragSwitch(false);
            }
            //else if (_playerRange >= _moveSwitchRange)
            //{
            //    MoveFragSwitch(true);
            //}

            yield return new WaitForSeconds(_recastTime);
            MoveFragSwitch(true);//移動を再開
            process = false;
        }
    }
    
    public IEnumerator Charge()//突進した時の処理
    {
        //if (!process)
        //{
        //process = true;
            
            //アニメーションを呼び出す
            Anim.SetTrigger("Attack");
        //SEを呼び出す
        SEManager.Instance.Sound(SEManager.SoundState.Sound5);
        //オブジェクトを有効化
        chargeobj.GetComponent<Charge>().atk = Atk1;
            chargeObject.SetActive(true);//当たり判定の有効化
            //Debug.Log("Charge");
            //chargeObject.SetActive(false);//当たり判定の無効化
            yield return null;

            //MoveFragSwitch(true);//移動を再開
            //process = false;
        //}
    }
    public IEnumerator Poison()//毒攻撃した時の処理
    {
        //if (!process)
        //{
            
        //process = true;
        //seを呼び出す
        Anim.SetTrigger("Attack");
        //Debug.Log(poisonobj);
        yield return new WaitForSeconds(_poisonDelay);//毒を生成するまでのラグを作る
        poisonobj.GetComponent<Poison>().atk = Atk1;
        poisonobj.transform.position=new Vector2(playerObject.transform.position.x, playerObject.transform.position.y);
        poisonobj.SetActive(true);
        //SEを呼び出す
        SEManager.Instance.Sound(SEManager.SoundState.Sound5);
        //Instpoison(new Vector2(
        //    playerObject.transform.position.x,
        //    this.gameObject.transform.position.y),
        //    playerObject.transform.rotation);
        //毒生成

        //process = false;
        //}
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