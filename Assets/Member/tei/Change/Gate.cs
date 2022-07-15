using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField]
    string exit1, exit2;
    [SerializeField]
    int gateNum;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string ReturnExit1()
    {
        return exit1;
    }

    public string ReturnExit2()
    {
        return exit2;
    }
    public int ReturnGatenum()
    {
        return gateNum;
    }
}
