using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Arrow : MonoBehaviour
{
    private bool cooltime = true;
    [SerializeField]
    private Animator anim;
    //攻撃
    public int Boss_Archer_Atk1;
    public int Boss_Archer_Atk2;

    private int Atk_;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Boss_Archer_Atk1 = Boss_.instance.Boss_Atk1;
        Boss_Archer_Atk2 = Boss_.instance.Boss_Atk2;

    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("Player"))
        {
            Atk_ = Boss_Bowman.Arrow.Atk_Bowman;
            if (Atk_ == 1)
            {
                Debug.Log("攻撃一をした");
                GameManagement.Instance.PlayerDamage(Boss_Archer_Atk1);
            }

            if (Atk_ == 2)
            {
                Debug.Log("攻撃2をした");
                GameManagement.Instance.PlayerDamage(Boss_Archer_Atk2);
            }

            Debug.Log("プレイヤーにダメージ");
            cooltime = false;
            StartCoroutine(CoolTime());
            ResetAtk_Bowman();

        }
    }

    public void ResetAtk_Bowman()
    {
        Boss_Bowman.Arrow.Atc_();
    }
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(1.0f);
        cooltime = true;

    }
}


