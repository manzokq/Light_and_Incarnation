using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    public EnemyDate enemyDate;//EnemyDate‚©‚ç‘Ì—Í‚È‚Ç‚Ìî•ñ‚ğŒÄ‚ñ‚Å‚­‚é
    private string Name = null;
    
    protected int Hp = 0;
    private int Atk = 0;
    public float Speed = 0;

   
    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Name = enemyDate.enemyName;
        Hp = enemyDate.hp;
        Atk = enemyDate.atk;
        Speed = enemyDate.speed;
    }

    // Update is called once per frame
    protected virtual void Update()
    {


        //Debug.Log(Hp);
        //‘Ì—Í‚Ì”»’è
        if (this.Hp <= 0)
        {
            //se‚ğŒÄ‚Ño‚·
            //
            this.gameObject.SetActive(false);
        }
        
        
    }
}
