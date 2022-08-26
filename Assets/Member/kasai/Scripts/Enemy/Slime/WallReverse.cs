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
        {//•Ç‚É“–‚½‚Á‚½‚ç”½“]
            //Debug.Log("•Ç‚É“–‚½‚Á‚½");
            //slime.Reverse();
            enemy.Reverse();
        }
    }
}
