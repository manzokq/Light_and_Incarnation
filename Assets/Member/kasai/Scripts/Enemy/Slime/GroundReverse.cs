using UnityEngine;

public class GroundReverse : MonoBehaviour 
{

    Slime slime;

    private void Awake()
    {
        slime= transform.parent.gameObject.GetComponent<Slime>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("è∞Ç©ÇÁî≤ÇØÇΩ");
            slime.Reverse();
        }
        
    }
}
