using UnityEngine;

public class PlayerSearch : MonoBehaviour
{

    Slime slime;

    private void Awake()
    {
        slime = transform.parent.gameObject.GetComponent<Slime>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("プレイヤーと接触");
            slime.Reverse();
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("プレイヤーと接触");
            slime.Reverse();
        }
    }
}
