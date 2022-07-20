using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManagement.Instance.PlayerHP = 100;
        GameManagement.Instance.PlayerMP = 100;
        GameManagement.Instance.PlayerOrb = 100;
    }
}
