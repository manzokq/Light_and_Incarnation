using UnityEngine;

public class GroundReverse : MonoBehaviour 
{

    //Slime slime;
    Enemy enemy;

    private void Awake()
    {
        //slime= transform.parent.gameObject.GetComponent<Slime>();
        enemy = transform.parent.GetComponent<Enemy>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Wall"))
        {
            //Debug.Log("è∞Ç©ÇÁî≤ÇØÇΩ");
            //slime.Reverse();
            enemy.Reverse();
        }
        
    }
}
