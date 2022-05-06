using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;//�v���C���[
    private float playerRange;//�v���C���[�Ƃ̋���

    public EnemyDate enemyDate;//EnemyDate����̗͂Ȃǂ̏����Ă�ł���
    private string Name = null;
    [HideInInspector] public int Hp = 0;
    private int Atk = 0;
    private float Speed = 0;

    //�A�j���[�^�[
    public Animator Anim;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Name = enemyDate.enemyName;
        Hp = enemyDate.hp;
        Atk = enemyDate.atk;
        Speed = enemyDate.speed;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //�̗͂̔���
        if (this.Hp <= 0)
        {
            //se���Ăяo��
            //
            this.gameObject.SetActive(false);
        }
        //�v���C���[�܂ł̋������o��
        this.playerRange = Vector2.Distance(playerObject.transform.position, transform.position);
        
    }
}
