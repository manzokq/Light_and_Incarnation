using UnityEngine;

public class Destroy : MonoBehaviour
{
	[SerializeField]
	float Ds = 0;
	/// <summary>
	/// Õ“Ë‚µ‚½
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter2D(Collision2D collision)
	{
		// Õ“Ë‚µ‚½‘Šè‚ÉPlayerƒ^ƒO‚ª•t‚¢‚Ä‚¢‚é‚Æ‚«
		if (collision.gameObject.tag == "Player")
		{
			// 0.2•bŒã‚ÉÁ‚¦‚é
			Destroy(gameObject, Ds);
		}
	}
}