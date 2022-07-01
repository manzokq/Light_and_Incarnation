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
}