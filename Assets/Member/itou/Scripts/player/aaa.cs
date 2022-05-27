using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaa : MonoBehaviour
{
    Transform player;
    WaitForSeconds attackWait;
    WaitForSeconds attackIntervalWait;
    [SerializeField]
    float attackTime = 0.5f;
    [SerializeField]
    float attackInterval = 2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        attackWait = new WaitForSeconds(attackTime);
        attackIntervalWait = new WaitForSeconds(attackInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
