using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaSE : MonoBehaviour
{
    public void SlidingSE()
    {
        SEManager.Instance.Sound(SEManager.SoundState.Sound0);
    }
    public void JumpSE()
    {
        SEManager.Instance.Sound(SEManager.SoundState.Sound1);
    }
    public void DodgeSE()
    {
        SEManager.Instance.Sound(SEManager.SoundState.Sound2);
    }
    public void SwordAtackSE()
    {
        SEManager.Instance.Sound(SEManager.SoundState.Sound3);
    }
    public void ArrowAtackSE()
    {
        SEManager.Instance.Sound(SEManager.SoundState.Sound4);
    }/*
    public void BossSwordAtackSE()
    {
        SEManager.Instance.Sound(SEManager.SoundState.Sound3);
    }
    public void BossArrowAtackSE()
    {
        SEManager.Instance.Sound(SEManager.SoundState.Sound4);
    }*/
}
