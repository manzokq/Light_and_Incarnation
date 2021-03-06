using UnityEngine;

public class Destroy : MonoBehaviour
{
	[SerializeField]
	float Ds = 0;
	/// <summary>
	/// 衝突した時
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter2D(Collision2D collision)
	{
		// 衝突した相手にPlayerタグが付いているとき
		if (collision.gameObject.tag == "Player")
		{
			// 0.2秒後に消える
			Destroy(gameObject, Ds);
		}
	}
}