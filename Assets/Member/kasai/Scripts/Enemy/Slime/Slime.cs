using System.Collections;
using UnityEngine;

public class Slime : Enemy
{
    private GameObject playerObject;//�v���C���[
    [SerializeField] private GameObject chargeObject;
    //���������
    [SerializeField] GameObject _poison;

    private float _playerRange;//�v���C���[�Ƃ̋���
    //�e�U���̎��s����͈�
    [SerializeField] private int _chargeRange = 0;
    [SerializeField] private int _poisonRangeMin = 0;
    [SerializeField] private int _poisonRangeMax = 0;

    //�ړ������̐؂�ւ�
    [SerializeField] private int _moveSwitchRange = 0;

    private GameObject poisonobj = null;    
    private GameObject chargeobj = null;    

    private bool inCamera;

    private bool process = false;//���ꂪtrue�̊Ԃ͕ʂ̏��������s���Ȃ�
    [SerializeField] private float _recastTime=3.0f;//�U���̎���
    [SerializeField] private float _poisonDelay=2.0f;//�U���̎���


    protected override void Start()
    {
        base.Start();
        playerObject = GameObject.FindWithTag("Player");
        poisonobj = _poison;
        chargeobj = chargeObject;

        chargeObject.SetActive(false);//�U���̓����蔻��
        poisonobj = Instantiate(_poison);//�U���̓����蔻��
        //poisonobj.GetComponent<Poison>().atk = Atk1;
        poisonobj.SetActive(false);


    }

    protected override void Update()
    {
        base.Update();
       
        //�f�o�b�O�p
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    MoveFragSwitch(false);
        //    Debug.Log("������");
        //}
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    MoveFragSwitch(true);
        //    Debug.Log("������");
        //}
        if (inCamera)
        {
            StartCoroutine(AtkChoices());

        }
        else
        {
            MoveFragSwitch(false);
        }
    }

    public IEnumerator AtkChoices() 
    {
        if (!process)
        {
            process = true;
            //�v���C���[�܂ł̋������o��
            this._playerRange = Vector2.Distance(playerObject.transform.position, this.transform.position);
            if (_playerRange < _chargeRange)
            {
                MoveFragSwitch(false);//�ړ����ꎞ��~
                StartCoroutine(Charge());
                
            }
            else if (_playerRange > _poisonRangeMin && _playerRange < _poisonRangeMax)
            {
                MoveFragSwitch(false);//�ړ����ꎞ��~
                StartCoroutine(Poison());

            }

            if (_playerRange < _moveSwitchRange)
            {
                //MoveFragSwitch(false);
            }
            //else if (_playerRange >= _moveSwitchRange)
            //{
            //    MoveFragSwitch(true);
            //}

            yield return new WaitForSeconds(_recastTime);
            MoveFragSwitch(true);//�ړ����ĊJ
            process = false;
        }
    }
    
    public IEnumerator Charge()//�ːi�������̏���
    {
        //if (!process)
        //{
        //process = true;
            
            //�A�j���[�V�������Ăяo��
            Anim.SetTrigger("Attack");
        //SE���Ăяo��
        SEManager.Instance.Sound(SEManager.SoundState.Sound5);
        //�I�u�W�F�N�g��L����
        chargeobj.GetComponent<Charge>().atk = Atk1;
            chargeObject.SetActive(true);//�����蔻��̗L����
            //Debug.Log("Charge");
            //chargeObject.SetActive(false);//�����蔻��̖�����
            yield return null;

            //MoveFragSwitch(true);//�ړ����ĊJ
            //process = false;
        //}
    }
    public IEnumerator Poison()//�ōU���������̏���
    {
        //if (!process)
        //{
            
        //process = true;
        //se���Ăяo��
        Anim.SetTrigger("Attack");
        //Debug.Log(poisonobj);
        yield return new WaitForSeconds(_poisonDelay);//�ł𐶐�����܂ł̃��O�����
        poisonobj.GetComponent<Poison>().atk = Atk1;
        poisonobj.transform.position=new Vector2(playerObject.transform.position.x, playerObject.transform.position.y);
        poisonobj.SetActive(true);
        //SE���Ăяo��
        SEManager.Instance.Sound(SEManager.SoundState.Sound5);
        //Instpoison(new Vector2(
        //    playerObject.transform.position.x,
        //    this.gameObject.transform.position.y),
        //    playerObject.transform.rotation);
        //�Ő���

        //process = false;
        //}
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