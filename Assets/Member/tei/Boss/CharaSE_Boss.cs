using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaSE_Boss : MonoBehaviour
{
    public void Boss_SwordAtackSE()
    {
        SEManager.Instance.Sound(SEManager.SoundState.Sound3);
    }
    public void Boss_ArrowAtackSE()
    {
        SEManager.Instance.Sound(SEManager.SoundState.Sound4);
    }
}
