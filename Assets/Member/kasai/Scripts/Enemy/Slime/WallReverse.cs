using UnityEngine;

public class WallReverse : MonoBehaviour
{

    Slime slime;

    private void Awake()
    {
        slime = transform.parent.gameObject.GetComponent<Slime>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {//•Ç‚É“–‚½‚Á‚½‚ç”½“]
            //Debug.Log("•Ç‚É“–‚½‚Á‚½");
            slime.Reverse();
        }
    }
}
