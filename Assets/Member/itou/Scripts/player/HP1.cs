using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HP1 : MonoBehaviour
{
    public int currentHp;  //現在値
    public int maxHp;      //最大値
    static Vector3 S = new Vector3(0f,0f,0f);
    // Start is called before the first frame update
    void Start()
    {
        //最大HPを設定
        maxHp = 100;
        //現在値を最大に
        currentHp = maxHp;
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

       if (currentHp <= 0)
        {
           this.transform.position = S;
            currentHp = maxHp;
        }
    }

    //ダメージ
    public void Damage(int D)
    {
        currentHp -= D;
    }
}
