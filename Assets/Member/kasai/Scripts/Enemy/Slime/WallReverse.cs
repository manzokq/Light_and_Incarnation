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
        {//�ǂɓ��������甽�]
            //Debug.Log("�ǂɓ�������");
            slime.Reverse();
        }
    }
}
