using UnityEngine;

public class Destroy : MonoBehaviour
{
	[SerializeField]
	float Ds = 0;
	/// <summary>
	/// �Փ˂�����
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter2D(Collision2D collision)
	{
		// �Փ˂��������Player�^�O���t���Ă���Ƃ�
		if (collision.gameObject.tag == "Player")
		{
			// 0.2�b��ɏ�����
			Destroy(gameObject, Ds);
		}
	}
}