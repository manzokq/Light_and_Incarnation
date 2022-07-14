using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public void ATKAnim1()
    {
        Anim.SetTrigger("Attack");
    }
    public void ATKAnim2()
    {
        Anim.SetTrigger("Attack2");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WallBreak") || collision.gameObject.CompareTag("Sword"))
        {
            Hp = GameManagement.Instance.PlayerAtk(Hp);
            //Debug.LogWarning("‰FÇ…êGÇÍÇΩ");
        }
    }
}