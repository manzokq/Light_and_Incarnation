using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Kasai : Enemy
{
    private GameObject playerObject;//�v���C���[

    //�v���C���[�Ƃ̋���
    private float _playerRange;
    //�ːi�̓����蔻��
    [SerializeField] private GameObject chargeObject;
    //�U���͈̔�
    [SerializeField] private int _chargeRange = 0;

    private GameObject chargeobj = null;
    //�U���̑I��
    private int _rnd = 0;
    private int _rndMin = 1;
    [SerializeField]private int _rndMax = 3;//��{�I�ɂ��������͂Ȃ�
    private bool _processZombie = false;//���ꂪtrue�̊Ԃ͕ʂ̏��������s���Ȃ�
    [SerializeField] private float _recastTime = 3.0f;//�U���̎���
    private float _saveRecastTime = 0;//_recastTime�̕ۑ��p

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        playerObject = GameObject.FindWithTag("Player");
        chargeobj = chargeObject;
        chargeObject.SetActive(false);//�U���̓����蔻��
        _saveRecastTime = _recastTime;

    }

    protected override void Update()
    {
        base.Update();
        StartCoroutine(ZombieAtkChoice());
    }
    public IEnumerator ZombieAtkChoice()
    {

        if (!_processZombie)
        {
            _processZombie = true;
            _recastTime = _saveRecastTime;
            //�v���C���[�܂ł̋������o��
            this._playerRange = Vector2.Distance(playerObject.transform.position, this.transform.position);
            //���̋��������Ȃ畡���̑I�������烉���_���ōU�������s����
            if (_playerRange < _chargeRange)
            {
                _rnd = Random.Range(_rndMin, _rndMax);
            }
            else
            {
                _recastTime = 0;//�v���C���[���߂��ɋ��Ȃ��Ƃ��͍U���̃��L���X�g���񂳂Ȃ��悤�ɂ���
            }

            if (_rnd == 1)
            {
                MoveFragSwitch(false);//�ړ����ꎞ��~
                StartCoroutine(Charge());
                _rnd = 0;
            }
            else if (_rnd == 2)
            {
                MoveFragSwitch(false);//�ړ����ꎞ��~
                StartCoroutine(Charge2());
                _rnd = 0;
            }
            else
            {
                //Debug.LogError("�����_�������ł��ĂȂ�");
            }
           

            yield return new WaitForSeconds(_recastTime);
            MoveFragSwitch(true);//�ړ����ĊJ
            _processZombie = false;
        }
        yield return null;
    }
    public IEnumerator Charge()
    {
        //�A�j���[�V�������Ăяo��
        Anim.SetTrigger("Attack");

        //�I�u�W�F�N�g��L����
        chargeobj.GetComponent<Charge>().atk = Atk1;//�����̓X���C���̍U������g���܂킵
        chargeObject.SetActive(true);//�����蔻��̗L����
        yield return null;
    }
    public IEnumerator Charge2()
    {
        //�A�j���[�V�������Ăяo��
        Anim.SetTrigger("Attack2");

        //�I�u�W�F�N�g��L����
        chargeobj.GetComponent<Charge>().atk = Atk2;//�����̓X���C���̍U������g���܂킵
        chargeObject.SetActive(true);//�����蔻��̗L����
        yield return null;
    }
}
