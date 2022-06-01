using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OrbGauge : MonoBehaviour
{
    [SerializeField]
    GameObject img;
    public void Update()
    {
        img.GetComponent<Image>().fillAmount = GameManagement.Instance.PlayerOrb * 0.01f;
    }
}
