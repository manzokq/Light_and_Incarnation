using System.Collections;
using UnityEngine;
 
public class torcha : MonoBehaviour
{
 
    // フロア内スイッチ数カウント保持
    protected uint _switchCount = 0;
    public bool flag = false;
    public uint SwitchCount
    {
        get { return _switchCount; }
        protected set { _switchCount = value; }
    }
    // プレイヤーステータス確保用変数
    protected CircleCollider2D _State;
 
    // 踏む順番の番号照らし合わせ用変数
    protected int _flowSwitchNo = 0;
    public int FlowSwitchNo
    {
        get { return _flowSwitchNo; }
    }
 
    // Start is called before the first frame update
    protected virtual void Start()
    {
        _checkAreaSwitches();
        // プレイヤーステータスを取得
        _State = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<CircleCollider2D>();
 
    }
 
    // Update is called once per frame
    protected virtual void Update()
    {
    }
 
    // フロア内スイッチをカウント
    private uint _checkAreaSwitches()
    {
        foreach (Transform child in transform)
        {
            SwitchCount += 1;
        }
 
        return SwitchCount;
    }
 
 // 子からマイナンバーを送ってもらうための関数
    public void sendMyNumber(uint myNumber)
    {
        // 次に踏むナンバーとマイナンバーが同じであれば
        if (myNumber == _flowSwitchNo)
        {
            // 次に踏むナンバーをインクリメントする
            _flowSwitchNo++;
        }
        else
        {
            // 間違っていた場合はリセットする
            _flowSwitchNo = 0;
        }
 
        // 正解チェック
        _checkSuccess();
    }
 
    // 正解チェック
    private void _checkSuccess()
    {
        if (_flowSwitchNo == SwitchCount)
        {
            flag = true;
           Debug.Log("Player entered!");
        }
    }
}