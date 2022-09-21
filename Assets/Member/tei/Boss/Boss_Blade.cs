using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Blade : MonoBehaviour
{
    private bool cooltime = true;
    [SerializeField]
    private Animator anim;
    //攻撃
    public int Boss_Blade_Atk1;
    public int Boss_Blade_Atk2;

    private int Atk_;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Boss_Blade_Atk1 = Boss_.instance.Boss_Atk1;
        Boss_Blade_Atk2 = Boss_.instance.Boss_Atk2;
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        Debug.Log(collider2D.gameObject);
        if (collider2D.gameObject.CompareTag("Player"))
        {
            Atk_ = Boss_Sword.Blade.Atk_Sword;
            if (Atk_ == 1)
            {
                Debug.Log("剣攻撃-1");
                GameManagement.Instance.PlayerDamage(Boss_Blade_Atk1);
            }

            if (Atk_ == 2)
            {
                Debug.Log("剣攻撃-2");
                GameManagement.Instance.PlayerDamage(Boss_Blade_Atk2);
            }

            Debug.Log("プレイヤーにダメージ");
            cooltime = false;
            StartCoroutine(CoolTime());
            ResetAtk_Sword();
        }
    }
    public void ResetAtk_Sword()
    {
        Boss_Sword.Blade.Atc_();
    }
    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(1.0f);
        cooltime = true;

    }
}
