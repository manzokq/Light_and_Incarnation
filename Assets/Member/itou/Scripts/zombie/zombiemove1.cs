using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiemove1 : MonoBehaviour
{
	[SerializeField]
	public GameObject zombie;
	public bool y = false;
	

	void Start()
	{ 
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
		y = false;
    }
    void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "y")
		{   //yukaタグのついたオブジェクトと衝突時
			zombie.GetComponent<zombiemove>().a *= -1;
			if(zombie.GetComponent<zombiemove>().w == false)
            {
				y = true;
            }
		}
	}
}