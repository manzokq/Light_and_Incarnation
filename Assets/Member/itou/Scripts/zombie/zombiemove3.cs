using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiemove3 : MonoBehaviour
{
    [SerializeField]
    private GameObject Circle;
    [SerializeField]
    public GameObject zombie;
    [SerializeField]
    public GameObject yukahanntei;
    bool a = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D col)
    { //2Dの衝突判定
        Debug.Log("a");
        if (col.gameObject.tag == "T")
        {   //Wallタグのついたオブジェクトと衝突時
            zombie.GetComponent<zombiemove>().a *= -1;
        }
    }

    void OnBecameVisible()
    {
        if (yukahanntei.GetComponent<zombiemove1>().y == true)
        {
            if (transform.position.x < Circle.transform.position.x && zombie.GetComponent<zombiemove>().a == 1 || transform.position.x > Circle.transform.position.x && zombie.GetComponent<zombiemove>().a == -1)
            {
                zombie.GetComponent<zombiemove>().w = true;
            }

            Debug.Log("画面に見えている");
        }
    }

    void OnBecameInvisible()
    {
        zombie.GetComponent<zombiemove>().w = false;
    }

    
}
