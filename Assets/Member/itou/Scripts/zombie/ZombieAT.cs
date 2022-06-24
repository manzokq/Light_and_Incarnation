using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAT : MonoBehaviour
{
    [SerializeField]
    private GameObject Circle;
    [SerializeField]
    private GameObject zombie;
    [SerializeField]
    private GameObject Square;
    public float span = 3f;
    private float currentTime = 0f;
    private void Start()
    {
        
    }
    bool G = false;
    bool wait = false;
    bool ATK = false;
    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > span)
        {
            Debug.Log("3•b");
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
        G = false;
        wait = false;
        if (ATK)
        {
            StartCoroutine(asa());
        }
    }
    private IEnumerator als()
    {
            if (wait)
            {
                wait = false;
                int dm = Random.Range(0, 2);
                Debug.Log(dm);
                if (dm == 0)
                {
                    //Debug.Log("a");
                    
                      Debug.Log(8);
                    
                }
                else if (dm == 1)
                {
                yield return new WaitForSecondsRealtime(3);
                      Debug.Log(20);
                    
                }
                GetComponent<CapsuleCollider2D>().enabled = false;
                yield return new WaitForSecondsRealtime(2);
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
