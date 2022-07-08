using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAT : MonoBehaviour
{
    public EnemyDate enemyDate;
    [SerializeField]
    private GameObject Circle;
    Zombie zombie;
    [SerializeField]
    private GameObject Square;
    public float span = 3f;
    private float currentTime = 0f;
    protected int Atk1 = 0;
    protected int Atk2 = 0;
    private void Start()
    {
        
    }

    private void Awake()
    {
        zombie = transform.parent.gameObject.GetComponent<Zombie>();
    }
    //bool G = false;
    bool wait = false;
    bool ATK = false;
    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > span)
        {
            Debug.Log("3ïb");
            Debug.Log(wait);
            StartCoroutine(als());
            currentTime = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //G = true;
        if (col.CompareTag("Player") == true)
        {
            wait = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        //G = false;
        wait = false;
        if (ATK)
        {
            StartCoroutine(asa());
        }
    }
    private IEnumerator als()
    {
        //çUåÇ
            if (wait)
            {
                wait = false;
                int dm = Random.Range(0, 2);
                Debug.Log(dm);
                zombie.MoveFragSwitch(false);
                if (dm == 0)
                {
                //Debug.Log("a");
                zombie.ATKAnim1();
                 Debug.Log(8);
                GameManagement.Instance.PlayerDamage(Atk1);//ëÃóÕÇå∏ÇÁÇ∑

            }
                else if (dm == 1)
                {


                yield return new WaitForSecondsRealtime(3);
                zombie.ATKAnim2();
                Debug.Log(20);
                GameManagement.Instance.PlayerDamage(Atk2);//ëÃóÕÇå∏ÇÁÇ∑
            }
                GetComponent<CapsuleCollider2D>().enabled = false;
                yield return new WaitForSecondsRealtime(2);
                zombie.MoveFragSwitch(true);
                ATK = true;
                GetComponent<CapsuleCollider2D>().enabled = true;

            wait = true;
            }

    }
    private IEnumerator asa()
    {
        ATK = false;
        yield return new WaitForSecondsRealtime(0.01f);
        ATK = true;
    }
}
