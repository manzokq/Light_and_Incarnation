using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject Circle;
    [SerializeField]
    private GameObject zombie;
    [SerializeField]
    private GameObject Square;
    private void Start()
    {

    }
    bool G = false;
    bool wait = true;
    bool zea = false;
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        G = true;
        if (wait)
        {
                StartCoroutine(als(col));

        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        G = false;
        wait = true;
        if (zea)
        {
            StartCoroutine(asa());
        }
    }
    private IEnumerator als(Collider2D col)
    {
        if (col.CompareTag("Player") == true)
        {
            zombie.GetComponent<zombiemove>().z = false;
            wait = false;
            int a = Random.Range(0, 2);
            Debug.Log(a);
            if (a == 0)
            {
                Debug.Log("a");
                yield return new WaitForSecondsRealtime(1);
                if (G)
                {
                    col.GetComponent<HP1>().Damage(8);
                }
            }
            else if (a == 1)
            {
                yield return new WaitForSecondsRealtime(3);
                if (G)
                {
                    col.GetComponent<HP1>().Damage(20);
                }
            }
            yield return new WaitForSecondsRealtime(2);
            wait = true;
            zea = true;

            if (true)
            {
                
            }
        }
    }
    private IEnumerator asa()
    {
        zea = false;
        zombie.GetComponent<zombiemove>().a *= -1;
        zombie.GetComponent<zombiemove>().z = true;
        yield return new WaitForSecondsRealtime(0.01f);
        zea = true;
    }
}
