using UnityEngine;

public class Block : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("WallBreak"))
        {
            this.gameObject.SetActive(false);//�ǂ�j�󂳂ꂽ�炱�̃I�u�W�F�N�g����

        }
    }
}
