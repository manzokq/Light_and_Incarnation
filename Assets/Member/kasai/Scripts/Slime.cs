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
        //seを呼び出す
        //
        yield return null;
    }
    public IEnumerator Poison()
    {
        //seを呼び出す
        //
        //毒生成
        yield return null;
    }
    public IEnumerator Explosion()
    {
        //seを呼び出す
        //
        yield return null;
    }
    public IEnumerator Destroy()
    {
        this.Hp = 0;
        //seを呼び出す
        //
        yield return null;
    }

    
}
