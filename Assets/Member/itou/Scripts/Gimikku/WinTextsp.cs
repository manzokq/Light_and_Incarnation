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
    [SerializeField]
    public bool str = false;
    public float jyougen;
    private Vector3 Pos1;
    GameObject PLAYER;
    public static WinTextsp instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Pos1 = transform.localPosition;
        text1.text = ms1;
        PLAYER = GameObject.FindGameObjectWithTag("Player");
        text1.color = new Color(255, 255, 255, 0);
    }

    private void Update()
    {
        if (str)
        {
            st = false;
            if (transform.localPosition.y < Pos1.y + 250)
            {
                text1.color += new Color(0, 0, 0, 2 * Time.deltaTime);
                text1.transform.localPosition += new Vector3(0, -Pos1.y * Time.deltaTime, 0);
                text1.transform.localScale += new Vector3(jyougen * Time.deltaTime, jyougen * Time.deltaTime, jyougen * Time.deltaTime);
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            str = true;
        }
    }
    

    

    
}
