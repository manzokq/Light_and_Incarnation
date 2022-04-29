using UnityEngine;
using System;
 
public class enumS : MonoBehaviour
{
 
    public enum Example
    {
        ZERO,　// =0
        ONE,　// =1
        TWO // =2
    }
 
 Example exa;
    // Use this for initialization
    void Start()
    {
 
        //enum型でswitch
        Example ex = Example.ZERO;
 
        switch (ex)
        {
            case Example.ZERO:
                Debug.Log("0");
                break;
 
            case Example.ONE:
                Debug.Log("1");
                break;
 
            case Example.TWO:
                Debug.Log("2");
                break;
        }
 
 
        //int型でswitch
       /* int a = 1;
 
        switch (a)
        {
            case (int)Example.ZERO:
                Debug.Log("0");
                break;
 
            case (int)Example.ONE:
                Debug.Log("1");
                break;
 
            case (int)Example.TWO:
                Debug.Log("2");
                break;
        }
 */
    }
 
    // Update is called once per frame
    void Update()
    {
 if(Input.GetKeyDown(KeyCode.A))
 {
     exa = Example.ONE;
 }
 if(Input.GetKeyDown(KeyCode.B))
 {
     exa = Example.TWO;
 }
     if(Input.GetKeyDown(KeyCode.C))
 {
    switch (exa)
        {
            case Example.ZERO:
                Debug.Log("0");
                break;
 
            case Example.ONE:
                Debug.Log("1");
                break;
 
            case Example.TWO:
                Debug.Log("2");
                break;

            
        }
 }

    }
 
 
}