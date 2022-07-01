using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En : MonoBehaviour
{

    public int a = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Time.deltaTime*1*a, 0));
    }

    public void G()
    {
        a *= -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
