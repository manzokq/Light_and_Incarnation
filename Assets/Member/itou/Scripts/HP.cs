using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HP : MonoBehaviour
{
    public int currentHp;  //現在値
    public int maxHp;      //最大値
    static Vector3 S = new Vector3(0f,0f,0f);
    public Slider hpBar;
    public Text hptext;
    // Start is called before the first frame update
    void Start()
    {
        //最大HPを設定
        maxHp = 100;
        //現在値を最大に
        currentHp = maxHp;

        //スライダーの最大値を変更
        hpBar.maxValue = maxHp;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("T") == true){
            S = new Vector3(0f,3f,0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //スライダーの値をリアルタイムで変更
        hpBar.value = currentHp;

        //HPテキストを変更
        //現在値　/　最大値
        hptext.text = currentHp.ToString() + " / " + maxHp.ToString();　//ToSTring = 文字化

       if (currentHp == 0)
        {
           this.transform.position = S;
            currentHp = maxHp;
        }
    }

    //ダメージ
    public void Damage()
    {
        //currentHpからー10
        currentHp -= 10;
    }
}
