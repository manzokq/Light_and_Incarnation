using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombiewall : MonoBehaviour
{
    Zombie zombie;
    // Start is called before the first frame update
    private void Awake()
    {
        zombie = transform.parent.gameObject.GetComponent<Zombie>();
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            zombie.Reverse();
        }
    }
}
