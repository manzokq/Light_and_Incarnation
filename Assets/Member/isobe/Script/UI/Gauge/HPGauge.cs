using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPGauge : MonoBehaviour
{
    [SerializeField]
    Image img;
    public void Update()
    {
        //img.fillAmount = GameManagement.Instance.PlayerHP *0.01f;
    }
}
