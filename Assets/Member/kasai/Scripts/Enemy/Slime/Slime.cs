using System.Collections;
using UnityEngine;

public class Slime : Enemy
{
    private GameObject playerObject;//�v���C���[
    //�ːi�̓����蔻��
    [SerializeField] private GameObject chargeObject;
    //���������
    [SerializeField] GameObject _poison;
    //�v���C���[�Ƃ̋���
    private float _playerRange;
    //�e�U���̎��s����͈�
    [SerializeField] private int _chargeRange = 0;
    [SerializeField] private int _poisonRangeMin = 0;
    //������Ray�̒��������˂Ă�
    [SerializeField] private int _poisonRangeMax = 0;
    //ray�̓����蔻��
    private bool _rayhit = false;

    //�ړ������̐؂�ւ�
    //[SerializeField] private int _moveSwitchRange = 0;

    private GameObject poisonobj = null;
    private GameObject chargeobj = null;

    //private bool inCamera;

    private bool _processSlime = false;//���ꂪtrue�̊Ԃ͕ʂ̏��������s���Ȃ�
    [SerializeField] private float _recastTime = 3.0f;//�U���̎���
    [SerializeField] private float _poisonDelay = 2.0f;//�ōU���̎���


    protected override void Start()
    {
        base.Start();
        playerObject = GameObject.FindWithTag("Player");
        poisonobj = _poison;
        chargeobj = chargeObject;

        chargeObject.SetActive(false);//�U���̓����蔻��
        poisonobj = Instantiate(_poison);//�U���̓����蔻��
        poisonobj.SetActive(false);


    }

    protected override void Update()
    {
        base.Update();

        //Ray�̐���
        Ray2D ray = new Ray2D(transform.position, transform.right);

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, _poisonRangeMax);


        if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
        {
            Debug.DrawRay(ray.origin, ray.direction * _poisonRangeMax, Color.red);
            _rayhit = true;
            Debug.Log("��������");
        }
        else
        {
            //Debug.Log("�������ĂȂ�");
            _rayhit = false;
        }

        StartCoroutine(AtkChoices());
    }

    public IEnumerator AtkChoices()
    {
        if (!_processSlime)
        {
            _processSlime = true;
            //�v���C���[�܂ł̋������o��
            this._playerRange = Vector2.Distance(playerObject.transform.position, this.transform.position);
            if (_playerRange < _chargeRange)
            {
                MoveFragSwitch(false);//�ړ����ꎞ��~
                StartCoroutine(Charge());

            }
            else if (_playerRange > _poisonRangeMin && _playerRange < _poisonRangeMax && _rayhit)
            {
                MoveFragSwitch(false);//�ړ����ꎞ��~
                StartCoroutine(Poison());

            }

            yield return new WaitForSeconds(_recastTime);
            MoveFragSwitch(true);//�ړ����ĊJ
            _processSlime = false;
        }
    }

    public IEnumerator Charge()//�ːi�������̏���
    {
        //�A�j���[�V�������Ăяo��
        Anim.SetTrigger("Attack");

        //�I�u�W�F�N�g��L����
        chargeobj.GetComponent<Charge>().atk = Atk1;
        chargeObject.SetActive(true);//�����蔻��̗L����
        yield return null;
    }
    public IEnumerator Poison()//�ōU���������̏���
    {
        Anim.SetTrigger("Attack");
        //Debug.Log(poisonobj);
        yield return new WaitForSeconds(_poisonDelay);//�ł𐶐�����܂ł̃��O�����
        poisonobj.GetComponent<Poison>().atk = Atk1;
        poisonobj.transform.position = new Vector2(playerObject.transform.position.x, playerObject.transform.position.y);
        poisonobj.SetActive(true);
    }

}