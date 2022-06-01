using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] int timeLimit;
    
    [SerializeField] Text timerText;
    float time;
    int remaining;
    
        void _Reset()
    {
        time = 0;
        timeLimit = 10;
    }
    void Update()
    {
        //フレーム毎の経過時間をtime変数に追加
        time += Time.deltaTime;
        //time変数をint型にし制限時間から引いた数をint型のlimit変数に代入
        remaining = timeLimit - (int)time;
        //timerTextを更新していく
        timerText.text = $"のこり：{remaining.ToString("D3")}";

        if(Input.GetKeyDown("space")) {
            timeLimit = 100;
	}
        if(remaining == 000){
        _Reset();
        }
    }
}