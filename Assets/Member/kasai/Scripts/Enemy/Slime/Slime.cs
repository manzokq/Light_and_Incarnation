using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    private GameObject playerObject;//�v���C���[
    //[SerializeField] private GameObject chargeObject;

    private float playerRange;//�v���C���[�Ƃ̋���

    //���������
    //[SerializeField] GameObject poison = null;

    //�e��ێ��i�v�[�����O�j�����̃I�u�W�F�N�g
    Transform poisons;
    //�A�j���[�^�[
    public Animator Anim;

    //private bool inCamera;

    //private bool process = false;
    protected override void Start()
    {
        base.Start();
        //rb = GetComponent<Rigidbody2D>();
        playerObject = GameObject.FindWithTag("Player");
    }

    protected override void Update()
    {
        base.Update();
        //�v���C���[�܂ł̋������o��
        this.playerRange = Vector2.Distance(playerObject.transform.position, this.transform.position);
       
        //if (inCamera)
        //{
        //    if (playerRange < 2)
        //    {
        //        StartCoroutine(Charge());
        //    }
        //    else if(playerRange>4&&playerRange<7)
        //    {
        //        StartCoroutine(Poison());
        //    }
        //    //else if(true)
        //    //{
        //    //    StartCoroutine(Explosion());
        //    //}
        //    if(playerRange>3)
        //    {
        //        StartCoroutine(Move());
        //    }
        //    //�m���Ŕ����ɔh��

        //}
    }

    
    public IEnumerator Charge()//�ːi�������̏���
    {
        //if (!process)
        //{
        //    process = true;

        //    //se���Ăяo��
        //    GameManagement.Instance.PlayerDamage(enemyDate.atk1);
            
        //    //
            yield return new WaitForSeconds(1.0f);
        //    process = false;
        //}
    }
    public IEnumerator Poison()//�ōU���������̏���
    {
        //if (!process)
        //{
        //    process = true;
        //    //se���Ăяo��
        //    Instpoison(new Vector2(
        //        playerObject.transform.position.x,
        //        this.gameObject.transform.position.y) ,
        //        playerObject.transform.rotation);
        //    //�Ő���
            yield return new WaitForSeconds(1.0f);
        //    process = false;
        //}
    }

    void Instpoison(Vector2 pos, Quaternion rotation)
    {
        //�A�N�e�B�u�łȂ��I�u�W�F�N�g��bullets�̒�����T��
        foreach (Transform t in poisons)
        {
            if (!t.gameObject.activeSelf)
            {
                //��A�N�e�B�u�ȃI�u�W�F�N�g�̈ʒu�Ɖ�]��ݒ�
                t.SetPositionAndRotation(pos, rotation);
                //�A�N�e�B�u�ɂ���
                t.gameObject.SetActive(true);
                return;
            }
        }
        //��A�N�e�B�u�ȃI�u�W�F�N�g���Ȃ��ꍇ�V�K����

        //��������bullets�̎q�I�u�W�F�N�g�ɂ���
        //Instantiate(poison, pos, rotation, poisons);
    }
    
    //�J�������ɂ��邩�ǂ����̏���(�����_���[�R���|�[�l���g���K�v)
    //private void OnBecameInvisible()
    //{
    //    inCamera = false;
    //}
    //private void OnBecameVisible()
    //{
    //    inCamera = true;
    //}


}