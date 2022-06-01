using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public EnemyDate enemyDate;//EnemyDate‚©‚ç‘Ì—Í‚È‚Ç‚Ìî•ñ‚ğŒÄ‚ñ‚Å‚­‚é
    float timer;
    int count=0;
    [SerializeField] private float randMin = 1.0f;//”{—¦‚ÌÅ¬’l
    [SerializeField] private float randMax = 1.0f;//”{—¦‚ÌÅ‘å’l
    private float magnification = 0;//ÀÛ‚É‚©‚©‚é”{—¦
    private int poisonAtk; //magnification*atk
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer<1.0f)
        {
            //dotˆ—
            count += 1;
            magnification = Random.Range(randMin, randMax);
            poisonAtk = (int)magnification * enemyDate.atk;
            //‘Ì—Í‚ğŒ¸‚ç‚·
            if (count>=5)
            {
                this.gameObject.SetActive(false);
            }
        }
        
    }
}
