using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MPGauge : MonoBehaviour
{
    [SerializeField]
    GameObject img;
    public void Update()
    {
        img.GetComponent<Image>().fillAmount = GameManagement.Instance.PlayerMP * 0.01f;
    }
}
