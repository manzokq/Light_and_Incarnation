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
}