using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour
{
    [SerializeField]
    private GameObject Orb;
    //public GameManagement OrbScripts;
    public Renderer rend;
    public int ret = 500;

    [SerializeField]private int _orbRecover=0;
    [SerializeField]private int _hpRecover=0;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true)
        {
            GameManagement.Instance.PlayerOrb += _orbRecover;
            GameManagement.Instance.PlayerHeal(_hpRecover);
            //OrbScripts.PlayerOrb++;
            StartCoroutine(orbsreset());
            Orb.GetComponent<CircleCollider2D>().enabled = false;
            rend.enabled = false;
        }
    }
    IEnumerator orbsreset()
    {
        //Debug.Log("a");
        yield return new WaitForSecondsRealtime(ret);
        Orb.GetComponent<CircleCollider2D>().enabled = true;
        rend.enabled = true;
    }
}
