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
		{   //Wall�^�O�̂����I�u�W�F�N�g�ƏՓˎ�
			Debug.Log("gg");
			Square.GetComponent<zombiemove>().w = true;
		}
	}
}