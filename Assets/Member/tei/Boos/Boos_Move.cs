using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boos_Move : MonoBehaviour
{
    //ボスとプレイヤーの距離管理
    public GameObject Range_Player;
    public GameObject Range_Boos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos_Player = Range_Player.transform.position;
        Vector2 pos_Boos = Range_Boos.transform.position;
        float range_boos_player = Vector2.Distance(pos_Player, pos_Boos);
        Debug.Log("距離は" + range_boos_player);

    }
}
