using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        //�E�����Ɉړ�
        transform.position += transform.right * 10 * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        //��ʊO�ɍs�������A�N�e�B�u�ɂ���
        gameObject.SetActive(false);
    }
}