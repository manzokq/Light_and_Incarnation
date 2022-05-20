using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiemove : Enemy
{
	[SerializeField]
	private GameObject Circle;
	private SpriteRenderer sr = null;
	public int a = 0;
	public bool w = false;

	protected override void Start()
	{
		base.Start();
		sr = GetComponent<SpriteRenderer>();
	}

	void FixedUpdate()
	{
			this.transform.Translate(new Vector3(Speed * a * Time.deltaTime, 0f, 0f));
		if (w)
		{
			if (transform.position.x < Circle.transform.position.x)
			{
				a = 1;
			}
			else if (transform.position.x > Circle.transform.position.x)
			{
				a = -1;
			}
		}
	}

	void OnBecameVisible()
    {
		if (transform.position.x < Circle.transform.position.x && a == 1 || transform.position.x > Circle.transform.position.x && a ==-1)
		{
			w = true;
		}
		
		Debug.Log("画面に見えている");
	}

	void OnBecameInvisible()
	{
		w = false;
	}

	void OnCollisionEnter2D(Collision2D col)
	{ //2Dの衝突判定
		if (col.gameObject.tag == "T")
		{   //Wallタグのついたオブジェクトと衝突時
			a *= -1;
		}
	}
}