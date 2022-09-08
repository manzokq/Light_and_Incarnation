using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cleartext : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cleartx());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator cleartx()
    {
        yield return new WaitForSeconds(0.5f);
        text.color = new Color(255, 255, 255, 0);
        yield return new WaitForSeconds(0.5f);
        text.color = new Color(255, 255, 255, 255);
        StartCoroutine(cleartx());
    }
}
