using UnityEngine;

public class WallReverse : MonoBehaviour
{
    Enemy enemy;
    //Slime slime;

    private void Awake()
    {
        //slime = transform.parent.gameObject.GetComponent<Slime>();
        enemy = transform.parent.gameObject.GetComponent<Enemy>();
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
