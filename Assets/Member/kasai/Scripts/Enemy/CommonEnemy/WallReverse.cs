using UnityEngine;

public class WallReverse : MonoBehaviour
{

    //Slime slime;
    Enemy enemy;

    private void Awake()
    {
        //slime = transform.parent.gameObject.GetComponent<Slime>();
        enemy=transform.parent.GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {//壁に当たったら反転
            //Debug.Log("壁に当たった");
            //slime.Reverse();
            enemy.Reverse();
        }
    }
}
