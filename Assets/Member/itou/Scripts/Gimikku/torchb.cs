using System.Collections;
using UnityEngine;
 
public class torchb : MonoBehaviour
{
 
    // 自身の保持ナンバー
    [SerializeField]
    private uint myNumber = 0;
    bool on = false;
 
    // 親に通知のため
    private torcha _SwitchManager;
 
 
    // Start is called before the first frame update
    private void Start()
    {
        // 親オブジェクトのスクリプトを取得
        _SwitchManager = transform.parent.gameObject.GetComponent<torcha>();
    }
 
    // 衝突判定
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            on = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            on = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) && on)
        {
            // 接触してきたのがプレイヤーだった場合、親に自分自身のマイナンバーを通知する
            _SwitchManager.sendMyNumber(myNumber);
            Debug.Log("on");
        }
    }
}
 
 