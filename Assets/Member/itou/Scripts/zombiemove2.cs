using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiemove2 : MonoBehaviour
{
	[SerializeField]
	public GameObject Square;

	

	void Start()
	{ 
		
	}

		void OnTriggerEnter2D(Collider2D b)
	{
		if (b.gameObject.tag == "Player")
		{   //Wallタグのついたオブジェクトと衝突時
			Debug.Log("gg");
			Square.GetComponent<zombiemove>().w = true;
		}
	}
}