using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Textsp : MonoBehaviour
{
    public Text text;

    public string ms;
    bool st = false;

    GameObject PLAYER;
    // Start is called before the first frame update
    void Start()
    {
        PLAYER = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (st)
        {
            if (text.transform.localPosition.y > 0)
            {
                text.color -= new Color(0, 0, 0, 2 * Time.deltaTime);
                text.transform.localPosition -= new Vector3(0, 145 * Time.deltaTime, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == PLAYER)
        {
            text.color = new Color(255, 255, 255, 0);
            st = false;
            text.text = ms;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == PLAYER)
        {
            if (text.transform.localPosition.y < 100)
            {
                text.color += new Color(0, 0, 0, 2 * Time.deltaTime);
                text.transform.localPosition += new Vector3(0, 180 * Time.deltaTime, 0);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == PLAYER)
        {
            st = true;
        }
    }
}
