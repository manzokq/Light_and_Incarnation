using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField, Header("テレポート先")]
    public GameObject Gate_1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Gate = Gate_1.transform.position;
        float x = Gate.x;
        float y = Gate.y;
        transform.position = new Vector2(x, y);
    }
}
