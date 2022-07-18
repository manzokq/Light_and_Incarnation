using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterSwitching : MonoBehaviour
{

    [SerializeField]
    private GameObject imege1;
    [SerializeField]
    private GameObject imege2;
    public List<Sprite> CharacterImage = new List<Sprite>();
    private void Update()
    {
        //if()//キャラクター切替が行われた場合
        //{
        switch (GameManagement.Instance.PlayerCharacter)
        {
            case GameManagement.CharacterID.Girl:
                switch (GameManagement.Instance.Character)
                {
                    case GameManagement.CharacterID.Swordsman:
                        imege1.GetComponent<Image>().sprite = CharacterImage[1];
                        imege2.GetComponent<Image>().sprite = CharacterImage[2];
                        break;
                    case GameManagement.CharacterID.Bowman:
                        imege1.GetComponent<Image>().sprite = CharacterImage[2];
                        imege2.GetComponent<Image>().sprite = CharacterImage[1];
                        break;
                  
                }
                break;
            case GameManagement.CharacterID.Swordsman:
                switch (GameManagement.Instance.Character)
                {
                    case GameManagement.CharacterID.Girl:
                        imege1.GetComponent<Image>().sprite = CharacterImage[0];
                        imege2.GetComponent<Image>().sprite = CharacterImage[2];
                        break;
                    case GameManagement.CharacterID.Bowman:
                        imege1.GetComponent<Image>().sprite = CharacterImage[2];
                        imege2.GetComponent<Image>().sprite = CharacterImage[0];
                        break;
                 
                }
                break;
            case GameManagement.CharacterID.Bowman:
                switch (GameManagement.Instance.Character)
                {
                    case GameManagement.CharacterID.Girl:
                        imege1.GetComponent<Image>().sprite = CharacterImage[0];
                        imege2.GetComponent<Image>().sprite = CharacterImage[1];
                        break;
                    case GameManagement.CharacterID.Swordsman:
                        imege1.GetComponent<Image>().sprite = CharacterImage[1];
                        imege2.GetComponent<Image>().sprite = CharacterImage[0];
                        break;
                    
                }
                break;
          
        }
    }

}
