using UnityEngine;

public class WallReverse : MonoBehaviour
{

    //Slime slime;
    Enemy enemy;

    private void Awake()
    {
        //slime = transform.parent.gameObject.GetComponent<Slime>();
        enemy=transform.parent.GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {//�ǂɓ��������甽�]
            //Debug.Log("�ǂɓ�������");
            //slime.Reverse();
            enemy.Reverse();
        }
    }
}
