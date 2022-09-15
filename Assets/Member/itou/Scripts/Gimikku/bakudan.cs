using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bakudan : MonoBehaviour
{
    [SerializeField] int timeLimit;
    
    [SerializeField] Text timerText;
    float time;
    int remaining;
    
    private bool btime = false;
        void _Reset()
    {
        time = 0;
        Debug.Log("Player entered!");
        btime = false;
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") == true){
            btime = true;
        }
    }
       void Update()
    {
        if(btime){
        //フレーム毎の経過時間をtime変数に追加
        time += Time.deltaTime;
        //time変数をint型にし制限時間から引いた数をint型のlimit変数に代入
        remaining = timeLimit - (int)time;
        //timerTextを更新していく
        timerText.text = $"爆発まで：{remaining.ToString("D3")}";

        if(remaining == 000){
        _Reset();
        }
        }
    }
}
