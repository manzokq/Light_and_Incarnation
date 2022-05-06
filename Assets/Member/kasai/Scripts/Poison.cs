using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    float timer;
    int count=0;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer<1.0f)
        {
            //dotˆ—
            count += 1;
            if(count>=5)
            {
                this.gameObject.SetActive(false);
            }
        }
        
    }
}
