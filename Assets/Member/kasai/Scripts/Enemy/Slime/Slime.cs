using System.Collections;
using UnityEngine;

public class Slime : Enemy
{
    private GameObject playerObject;//�v���C���[
    [SerializeField] private GameObject chargeObject;
    //���������
    [SerializeField] GameObject _poison;

    private float _playerRange;//�v���C���[�Ƃ̋���
    [SerializeField] private int _chargeRange = 0;
    [SerializeField] private int _poisonRangeMin = 0;
    [SerializeField] private int _poisonRangeMax = 0;
    [SerializeField] private int _moveSwitchRange = 0;

    

    //�e��ێ��i�v�[�����O�j�����̃I�u�W�F�N�g
    //Transform poisons;

    private GameObject poisonobj = null;    
    private GameObject chargeobj = null;    

    private bool inCamera;

    private bool process = false;
    [SerializeField] private float recastTime=3.0f;

    protected override void Start()
    {
        base.Start();
        playerObject = GameObject.FindWithTag("Player");
        poisonobj = _poison;//.GetComponent<GameObject>();
        chargeobj = chargeObject;//.GetComponent<GameObject>();
        //Debug.Log(chargeobj);
        //chargeobj.GetComponent<Charge>().atk = Atk1;
        chargeObject.SetActive(false);
        poisonobj = Instantiate(_poison);
        //poisonobj.GetComponent<Poison>().atk = Atk1;
        poisonobj.SetActive(false);


    }

    protected override void Update()
    {
        base.Update();
        //�v���C���[�܂ł̋������o��
        this._playerRange = Vector2.Distance(playerObject.transform.position, this.transform.position);
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
            if (_playerRange < _chargeRange)
            {
                StartCoroutine(Charge());                
            }
            else if (_playerRange > _poisonRangeMin && _playerRange < _poisonRangeMax)
            {
                StartCoroutine(Poison());
            }

            if (_playerRange < _moveSwitchRange)
            {
                MoveFragSwitch(false);
            }
            else if (_playerRange >= _moveSwitchRange)
            {
                MoveFragSwitch(true);
            }

        }
        else
        {
            MoveFragSwitch(false);
        }
    }

    
    public IEnumerator Charge()//�ːi�������̏���
    {
        if (!process)
        {
            process = true;
            
            MoveFragSwitch(false);//�ړ����ꎞ��~
            //�A�j���[�V�������Ăяo��
            Anim.SetTrigger("Attack");
            //�I�u�W�F�N�g��L����
            chargeobj.GetComponent<Charge>().atk = Atk1;
            chargeObject.SetActive(true);//�����蔻��̗L����
            //Debug.Log("Charge");
            //chargeObject.SetActive(false);//�����蔻��̖�����
            yield return new WaitForSeconds(recastTime);

            MoveFragSwitch(true);//�ړ����ĊJ
            process = false;
        }
    }
    public IEnumerator Poison()//�ōU���������̏���
    {
        if (!process)
        {
            
            process = true;
            //se���Ăяo��
            Anim.SetTrigger("Attack");
            //Debug.Log(poisonobj);
            yield return new WaitForSeconds(1.0f);//1�b�̃��O�����
            poisonobj.GetComponent<Poison>().atk = Atk1;
            poisonobj.transform.position=new Vector2(playerObject.transform.position.x, playerObject.transform.position.y);
            poisonobj.SetActive(true);
            //Instpoison(new Vector2(
            //    playerObject.transform.position.x,
            //    this.gameObject.transform.position.y),
            //    playerObject.transform.rotation);
            //�Ő���
            yield return new WaitForSeconds(recastTime);
            process = false;
        }
    }

    //void Instpoison(Vector2 pos, Quaternion rotation)
    //{
    //    //�A�N�e�B�u�łȂ��I�u�W�F�N�g��bullets�̒�����T��
    //    foreach (Transform t in poisons)
    //    {
    //        if (!t.gameObject.activeSelf)
    //        {
    //            //��A�N�e�B�u�ȃI�u�W�F�N�g�̈ʒu�Ɖ�]��ݒ�
    //            t.SetPositionAndRotation(pos, rotation);
    //            //�A�N�e�B�u�ɂ���
    //            t.gameObject.SetActive(true);
    //            return;
    //        }
    //    }
    //    //��A�N�e�B�u�ȃI�u�W�F�N�g���Ȃ��ꍇ�V�K����

    //    //��������bullets�̎q�I�u�W�F�N�g�ɂ���



    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("WallBreak")||collision.gameObject.CompareTag("Sword"))
        {
            Hp = GameManagement.Instance.PlayerAtk(Hp);
            //Debug.LogWarning("�F�ɐG�ꂽ");
        }
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