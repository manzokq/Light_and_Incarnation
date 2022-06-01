using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPGauge : MonoBehaviour
{
    [SerializeField]
    GameObject img;
    public void Update()
    {
        img.GetComponent<Image>().fillAmount = GameManagement.Instance.PlayerHP *0.01f;
    }
}
