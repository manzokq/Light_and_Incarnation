using System.Collections;
using UnityEngine;

public class MoveTest : Enemy
{
    private Rigidbody2D rb;
    FloorSearch floorSearch = new();
    public bool slimeSearch = true;
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        slimeSearch = floorSearch.Search;
        StartCoroutine(Move());
        rb = GetComponent<Rigidbody2D>();
    }
    public IEnumerator Move()//移動の処理
    {
        Vector2 scale = transform.localScale;
        rb.velocity = new Vector2(enemyDate.speed, rb.velocity.y);
        if (!slimeSearch)
        {
            Debug.Log("a");
            enemyDate.speed = enemyDate.speed * -1;
            scale.x = scale.x * -1;
            //付属したオブジェクトの座標反転したら治るのでは？
            //進行方向の反転   
        }//ここはあってる
        yield return null;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag != "Player")
        //{
        //    slimeSearch = false;//ここは確かめてないけど多分大丈夫
        //}
    }
}