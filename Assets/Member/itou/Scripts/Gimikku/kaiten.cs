using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaiten : MonoBehaviour
{

    [SerializeField]
    private Switchrigth _switchrigth;
    [SerializeField]
    private Switchleft _switchleft;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_switchrigth.kidourigth)
        {
            _switchrigth.kidourigth = false;
            StartCoroutine(rigth());
        }
        if (_switchleft.kidouleft)
        {
            _switchleft.kidouleft = false;
            StartCoroutine(left());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    IEnumerator rigth()
    {
        int time = 0;
        while (true)
        {
            if (time == 90)
            {
                
                break;
            }
            else
            {
                Transform myTransform = this.transform;
                myTransform.Rotate(new Vector3(0, 0, 1));
                time++;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator left()
    {
        int time = 0;
        while (true)
        {
            if (time == 90)
            {

                break;
            }
            else
            {
                Transform myTransform = this.transform;
                myTransform.Rotate(new Vector3(0, 0, -1));
                time++;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

}