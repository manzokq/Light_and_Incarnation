using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    [SerializeField] private GameObject playerObject;//�v���C���[
    private float playerRange;//�v���C���[�Ƃ̋���
    //���������
    [SerializeField] GameObject poison = null;

    //�e��ێ��i�v�[�����O�j�����̃I�u�W�F�N�g
    Transform poisons;
    //�A�j���[�^�[
    public Animator Anim;

    private bool inCamera;

    //public enum SlimeState
    //{
    //    Move,
    //    Charge,
    //    Poison,
    //    Explosion,
    //    Damaged,
    //    Null
    //}
    //public SlimeState slimestate = SlimeState.Null;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        //�v���C���[�܂ł̋������o��
        this.playerRange = Vector2.Distance(playerObject.transform.position, this.transform.position);
        ////�e�����֐����Ăяo��
        //InstPoison(transform.position, transform.rotation);

        if(playerRange<2)
        {
            StartCoroutine(Charge());
        }
        else 
        {
            StartCoroutine(Move());
        }
        
    }

    public IEnumerator Move()//�ړ��̏���
    {
        if(inCamera)
        {
            
        }
        if(playerRange<2)
        {

        }
        if(true)//��Q��or���̐�ɏ����Ȃ��Ȃ甽�]
            yield return null;
    }
    public IEnumerator Charge()//�ːi�������̏���
    {
        //se���Ăяo��
        //
        yield return null;
    }
    public IEnumerator Poison()//�ōU���������̏���
    {
        //se���Ăяo��
        //
        //�Ő���
        yield return null;
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
        Instantiate(poison, pos, rotation, poisons);
    }
    public IEnumerator Explosion()//�����������̏���
    {
        //se���Ăяo��
        //
        yield return null;
    }

    public IEnumerator Damaged()//��e�������̏���
    {
        yield return null;
    }
    public IEnumerator Destroy()//���܂ꂽ���̏���
    {
        this.Hp = 0;
        //se���Ăяo��
        //
        yield return null;
    }

    //�J�������ɂ��邩�ǂ����̏���(�����_���[�R���|�[�l���g���K�v)
    private void OnBecameInvisible()
    {
        inCamera = false;
    }
    private void OnBecameVisible()
    {
        inCamera = true;
    }

}
