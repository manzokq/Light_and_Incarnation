using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Slime : Enemy
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

    public IEnumerator Move()
    {
        yield return null;
    }
    public IEnumerator Charge()
    {
        //se���Ăяo��
        //
        yield return null;
    }
    public IEnumerator Poison()
    {
        //se���Ăяo��
        //
        //�Ő���
        yield return null;
    }
    public IEnumerator Explosion()
    {
        //se���Ăяo��
        //
        yield return null;
    }
    public IEnumerator Destroy()
    {
        this.Hp = 0;
        //se���Ăяo��
        //
        yield return null;
    }

    
}
