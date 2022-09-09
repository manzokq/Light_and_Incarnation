using System.Collections;
using UnityEngine;

public class Slime : Enemy
{
    private GameObject playerObject;//プレイヤー
    //突進の当たり判定
    [SerializeField] private GameObject chargeObject;
    //生成する毒
    [SerializeField] GameObject _poison;
    //プレイヤーとの距離
    private float _playerRange;
    //各攻撃の実行する範囲
    [SerializeField] private int _chargeRange = 0;
    [SerializeField] private int _poisonRangeMin = 0;
    //ここはRayの長さも兼ねてる
    [SerializeField] private int _poisonRangeMax = 0;
    //rayの当たり判定
    private bool _rayhit = false;

    //移動処理の切り替え
    //[SerializeField] private int _moveSwitchRange = 0;

    private GameObject poisonobj = null;
    private GameObject chargeobj = null;

    //private bool inCamera;

    private bool _processSlime = false;//これがtrueの間は別の処理を実行しない
    [SerializeField] private float _recastTime = 3.0f;//攻撃の周期
    [SerializeField] private float _poisonDelay = 2.0f;//毒攻撃の周期


    protected override void Start()
    {
        base.Start();
        playerObject = GameObject.FindWithTag("Player");
        poisonobj = _poison;
        chargeobj = chargeObject;

        chargeObject.SetActive(false);//攻撃の当たり判定
        poisonobj = Instantiate(_poison);//攻撃の当たり判定
        poisonobj.SetActive(false);


    }

    protected override void Update()
    {
        base.Update();

        //Rayの生成
        Ray2D ray = new Ray2D(transform.position, transform.right);

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, _poisonRangeMax);


        if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
        {
            Debug.DrawRay(ray.origin, ray.direction * _poisonRangeMax, Color.red);
            _rayhit = true;
            Debug.Log("あたった");
        }
        else
        {
            //Debug.Log("あたってない");
            _rayhit = false;
        }

        StartCoroutine(AtkChoices());
    }

    public IEnumerator AtkChoices()
    {
        if (!_processSlime)
        {
            _processSlime = true;
            //プレイヤーまでの距離を出す
            this._playerRange = Vector2.Distance(playerObject.transform.position, this.transform.position);
            if (_playerRange < _chargeRange)
            {
                MoveFragSwitch(false);//移動を一時停止
                StartCoroutine(Charge());

            }
            else if (_playerRange > _poisonRangeMin && _playerRange < _poisonRangeMax && _rayhit)
            {
                MoveFragSwitch(false);//移動を一時停止
                StartCoroutine(Poison());

            }

            yield return new WaitForSeconds(_recastTime);
            MoveFragSwitch(true);//移動を再開
            _processSlime = false;
        }
    }

    public IEnumerator Charge()//突進した時の処理
    {
        //アニメーションを呼び出す
        Anim.SetTrigger("Attack");

        //オブジェクトを有効化
        chargeobj.GetComponent<Charge>().atk = Atk1;
        chargeObject.SetActive(true);//当たり判定の有効化
        yield return null;
    }
    public IEnumerator Poison()//毒攻撃した時の処理
    {
        Anim.SetTrigger("Attack");
        //Debug.Log(poisonobj);
        yield return new WaitForSeconds(_poisonDelay);//毒を生成するまでのラグを作る
        poisonobj.GetComponent<Poison>().atk = Atk1;
        poisonobj.transform.position = new Vector2(playerObject.transform.position.x, playerObject.transform.position.y);
        poisonobj.SetActive(true);
    }

}