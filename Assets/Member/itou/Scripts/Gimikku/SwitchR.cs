using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchR : MonoBehaviour
{
    public bool kidourigth = false;
    public bool star = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && star)
        {
            // �ڐG���Ă����̂��v���C���[�������ꍇ�A�e�Ɏ������g�̃}�C�i���o�[��ʒm����
            kidourigth = true;
            Debug.Log("on");
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            star = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            star = false;
        }
    }
}
