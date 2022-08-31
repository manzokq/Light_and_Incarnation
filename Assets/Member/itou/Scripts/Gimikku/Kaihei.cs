using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaihei : MonoBehaviour
{
    [SerializeField]
    private GameObject doa;
    public bool kaihei = false;
    float koudo;

    // Start is called before the first frame update
    void Start()
    {
        koudo = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            kaihei = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (kaihei)
        {
            while (koudo < 1.5)
            {
                doa.transform.Translate(new Vector3(0, 1f * Time.deltaTime, 0));
                koudo += Time.deltaTime;
            }
            //if (koudo >= 50)
            //{
            //    koudo = 0;
            //    kaihei = false;
            //}
        }
    }
}
