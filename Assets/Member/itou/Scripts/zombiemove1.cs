using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiemove1 : MonoBehaviour
{
	[SerializeField]
	public GameObject Square;

	

	void Start()
	{ 
		
	}

		void OnTriggerExit2D(Collider2D col)
	{
		Debug.Log("q");
		if (col.gameObject.tag == "y")
		{   //Wallタグのついたオブジェクトと衝突時
			Square.GetComponent<zombiemove>().a *= -1;
		}
	}
}