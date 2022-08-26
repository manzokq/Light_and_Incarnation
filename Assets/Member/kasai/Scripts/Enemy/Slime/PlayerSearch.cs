using UnityEngine;

public class PlayerSearch : MonoBehaviour
{

    //Slime slime;
    Enemy enemy;

    private void Awake()
    {
        //slime = transform.parent.gameObject.GetComponent<Slime>();
        enemy = transform.parent.gameObject.GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("プレイヤーと接触");
            //lime.Reverse();
            enemy.Reverse();
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("プレイヤーと接触");
            //slime.Reverse();
            enemy.Reverse();
        }
    }
}
