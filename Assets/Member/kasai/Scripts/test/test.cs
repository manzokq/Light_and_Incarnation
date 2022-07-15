using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class test : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            
            SEManager.Instance.Sound(SEManager.SoundState.Sound0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            
            SEManager.Instance.Sound(SEManager.SoundState.Sound1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            
            SEManager.Instance.Sound(SEManager.SoundState.Sound2);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            SEManager.Instance.Sound(SEManager.SoundState.Sound3);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            
            SEManager.Instance.Sound(SEManager.SoundState.Sound4);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            
            SEManager.Instance.Sound(SEManager.SoundState.Sound5);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            
            SEManager.Instance.Sound(SEManager.SoundState.Sound6);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            
            SEManager.Instance.Sound(SEManager.SoundState.Sound7);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            
            SEManager.Instance.Sound(SEManager.SoundState.Sound8);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            
            SEManager.Instance.Sound(SEManager.SoundState.Sound9);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            
            SEManager.Instance.Sound(SEManager.SoundState.Sound10);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {

            BGMManager.Instance.Sound(BGMManager.SoundState.Sound0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {

            BGMManager.Instance.Sound(BGMManager.SoundState.Sound1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            BGMManager.Instance.Sound(BGMManager.SoundState.Sound2);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {

            BGMManager.Instance.Sound(BGMManager.SoundState.Sound3);
        }
    }
}