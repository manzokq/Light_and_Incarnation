using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Kasai : Enemy
{
    private GameObject playerObject;//プレイヤー

    //プレイヤーとの距離
    private float _playerRange;
    //突進の当たり判定
    [SerializeField] private GameObject chargeObject;
    //攻撃の範囲
    [SerializeField] private int _chargeRange = 0;

    private GameObject chargeobj = null;
    //攻撃の選択
    private int _rnd = 0;
    private int _rndMin = 1;
    [SerializeField]private int _rndMax = 3;//基本的にいじるつもりはない
    private bool _processZombie = false;//これがtrueの間は別の処理を実行しない
    [SerializeField] private float _recastTime = 3.0f;//攻撃の周期
    private float _saveRecastTime = 0;//_recastTimeの保存用

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        playerObject = GameObject.FindWithTag("Player");
        chargeobj = chargeObject;
        chargeObject.SetActive(false);//攻撃の当たり判定
        _saveRecastTime = _recastTime;

    }

    protected override void Update()
    {
        base.Update();
        StartCoroutine(ZombieAtkChoice());
    }
    public IEnumerator ZombieAtkChoice()
    {

        if (!_processZombie)
        {
            _processZombie = true;
            _recastTime = _saveRecastTime;
            //プレイヤーまでの距離を出す
            this._playerRange = Vector2.Distance(playerObject.transform.position, this.transform.position);
            //一定の距離未満なら複数の選択肢からランダムで攻撃を実行する
            if (_playerRange < _chargeRange)
            {
                _rnd = Random.Range(_rndMin, _rndMax);
            }
            else
            {
                _recastTime = 0;//プレイヤーが近くに居ないときは攻撃のリキャストを回さないようにする
            }

            if (_rnd == 1)
            {
                MoveFragSwitch(false);//移動を一時停止
                StartCoroutine(Charge());
                _rnd = 0;
            }
            else if (_rnd == 2)
            {
                MoveFragSwitch(false);//移動を一時停止
                StartCoroutine(Charge2());
                _rnd = 0;
            }
            else
            {
                //Debug.LogError("ランダム生成できてない");
            }
           

            yield return new WaitForSeconds(_recastTime);
            MoveFragSwitch(true);//移動を再開
            _processZombie = false;
        }
        yield return null;
    }
    public IEnumerator Charge()
    {
        //アニメーションを呼び出す
        Anim.SetTrigger("Attack");

        //オブジェクトを有効化
        chargeobj.GetComponent<Charge>().atk = Atk1;//ここはスライムの攻撃から使いまわし
        chargeObject.SetActive(true);//当たり判定の有効化
        yield return null;
    }
    public IEnumerator Charge2()
    {
        //アニメーションを呼び出す
        Anim.SetTrigger("Attack2");

        //オブジェクトを有効化
        chargeobj.GetComponent<Charge>().atk = Atk2;//ここはスライムの攻撃から使いまわし
        chargeObject.SetActive(true);//当たり判定の有効化
        yield return null;
    }
}
