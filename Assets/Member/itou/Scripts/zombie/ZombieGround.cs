using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGround : MonoBehaviour
{
    Zombie zombie;
    // Start is called before the first frame update
    private void Awake()
    {
        zombie = transform.parent.gameObject.GetComponent<Zombie>();
    }

    // Update is called once per frame
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            zombie.Reverse();
        }
    }
}
