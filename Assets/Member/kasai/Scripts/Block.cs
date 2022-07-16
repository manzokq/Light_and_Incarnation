using UnityEngine;

public class Block : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("WallBreak"))
        {
            SEManager.Instance.Sound(SEManager.SoundState.Sound6);
            this.gameObject.SetActive(false);//壁を破壊されたらこのオブジェクト消す

        }
    }
}
