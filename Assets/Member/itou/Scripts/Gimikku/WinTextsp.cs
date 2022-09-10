using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WinTextsp : MonoBehaviour
{
    public TextMeshProUGUI text1;

    public string ms1;
    bool st = false;
    bool str = false;
    public int jyougen;

    GameObject PLAYER;
    // Start is called before the first frame update
    void Start()
    {
        text1.text = ms1;
        PLAYER = GameObject.FindGameObjectWithTag("Player");
        text1.color = new Color(255, 255, 255, 0);
    }

    private void Update()
    {
        if (str)
        {
            st = false;
            if (text1.transform.localPosition.y < 100)
            {
                text1.color += new Color(0, 0, 0, 2 * Time.deltaTime);
                text1.transform.localPosition += new Vector3(0, 270 * Time.deltaTime, 0);
                text1.transform.localScale += new Vector3(jyougen * Time.deltaTime, jyougen * Time.deltaTime, jyougen * Time.deltaTime);
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            str = true;
        }
    }
}
