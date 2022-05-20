using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    private GameObject playerObject;//�v���C���[
    [SerializeField] private GameObject chargeObject;
    [SerializeField] private GameObject explosionObject;
    private float playerRange;//�v���C���[�Ƃ̋���

    Vector2 force;

    //���������
    [SerializeField] GameObject poison = null;

    //�e��ێ��i�v�[�����O�j�����̃I�u�W�F�N�g
    Transform poisons;
    //�A�j���[�^�[
    public Animator Anim;

    private bool inCamera;

    EnemySearch enemySearch = new EnemySearch();

    private bool slimeSearch=false;

    //private Rigidbody2D rb;
    protected override void Start()
    {
        base.Start();
        playerObject = GameObject.FindWithTag("Player");
        //rb = GetComponent<Rigidbody2D>();
    }

    protected override void Update()
    {
        base.Update();
        //�v���C���[�܂ł̋������o��
        this.playerRange = Vector2.Distance(playerObject.transform.position, this.transform.position);
       

        slimeSearch = enemySearch.Search;
        if (inCamera)
        {
            if (playerRange < 2)
            {
                StartCoroutine(Charge());
            }
            else if(playerRange>4&&playerRange<7)
            {
                StartCoroutine(Poison());
            }
            else
            {
                StartCoroutine(Move());
            }
            //�m���Ŕ����ɔh��

        }
    }

    public IEnumerator Move()//�ړ��̏���
    {
        Vector2 scale = transform.localScale;
        if (playerRange<3)
        {
            //�v���C���[���Ɉړ�
            Vector3 pv = playerObject.transform.position;
            Vector3 ev = transform.position;

            float p_vX = pv.x - ev.x;
            float p_vY = pv.y - ev.y;

            float vx = 0f;
            float vy = 0f;

            float sp = enemyDate.speed;

            // ���Z�������ʂ��}�C�i�X�ł����X�͌��Z����
            if (p_vX < 0)
            {
                vx = -sp;
            }
            else
            {
                vx = sp;
            }

            //// ���Z�������ʂ��}�C�i�X�ł����Y�͌��Z����
            //if (p_vY < 0)
            //{
            //    vy = -sp;
            //}
            //else
            //{
            //    vy = sp;
            //}

            transform.Translate(vx / 50, vy / 50, 0);

        }
        else if(playerRange>2)
        {
            this.transform.Translate(Vector2.left * Time.deltaTime * enemyDate.speed);
            if(!slimeSearch)
            {
                enemyDate.speed = enemyDate.speed * -1;
                scale.x = scale.x * -1;
             //�i�s�����̔��]   
            }
        }
            yield return null;
    }
    public IEnumerator Charge()//�ːi�������̏���
    {
        //se���Ăяo��
        //atk10
        yield return null;
    }
    public IEnumerator Poison()//�ōU���������̏���
    {
        //se���Ăяo��
        Instpoison(playerObject.transform.position, playerObject.transform.rotation);
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
        yield return new WaitForSeconds(3.0f);
        //atk20
        //
    }

    //public IEnumerator Damaged()//��e�������̏���
    //{
    //    yield return null;
    //}
    public IEnumerator Destroy()//���܂ꂽ���̏���
    {
        this.Hp = 0;
        //se���Ăяo��
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        slimeSearch = false;
    }
}