using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AtkSwiching : MonoBehaviour
{
    [SerializeField]
    private GameObject imege1;
    [SerializeField]
    private GameObject imege2;
    public List<Sprite> CharacterAtk1Image = new List<Sprite>();
    public List<Sprite> CharacterAtk2Image = new List<Sprite>();
    public List<Sprite> CharacterAtk3Image = new List<Sprite>();
    public List<Sprite> CharacterAtk4Image = new List<Sprite>();
    private void Update()
    {
        switch (GameManagement.Instance.PlayerCharacter)
        {
            case GameManagement.Character.Girl:
                switch (GameManagement.Instance.Atk)
                {
                    case GameManagement.AtkID.Atk1:
                        imege1.GetComponent<Image>().sprite = CharacterAtk1Image[0];
                        imege2.GetComponent<Image>().sprite = CharacterAtk1Image[1];
                        break;
                    case GameManagement.AtkID.Atk2:
                        imege1.GetComponent<Image>().sprite = CharacterAtk1Image[1];
                        imege2.GetComponent<Image>().sprite = CharacterAtk1Image[2];
                        break;
                    case GameManagement.AtkID.Atk3:
                        imege1.GetComponent<Image>().sprite = CharacterAtk1Image[2];
                        imege2.GetComponent<Image>().sprite = CharacterAtk1Image[0];
                        break;
                }
                break;
            case GameManagement.Character.Bowman:
                switch (GameManagement.Instance.Atk)
                {
                    case GameManagement.AtkID.Atk1:
                        imege1.GetComponent<Image>().sprite = CharacterAtk2Image[0];
                        imege2.GetComponent<Image>().sprite = CharacterAtk2Image[1];
                        break;
                    case GameManagement.AtkID.Atk2:
                        imege1.GetComponent<Image>().sprite = CharacterAtk2Image[1];
                        imege2.GetComponent<Image>().sprite = CharacterAtk2Image[2];
                        break;
                    case GameManagement.AtkID.Atk3:
                        imege1.GetComponent<Image>().sprite = CharacterAtk2Image[2];
                        imege2.GetComponent<Image>().sprite = CharacterAtk2Image[0];
                        break;
                }
                break;
            case GameManagement.Character.Swordsman:
                switch (GameManagement.Instance.Atk)
                {
                    case GameManagement.AtkID.Atk1:
                        imege1.GetComponent<Image>().sprite = CharacterAtk3Image[0];
                        imege2.GetComponent<Image>().sprite = CharacterAtk3Image[1];
                        break;
                    case GameManagement.AtkID.Atk2:
                        imege1.GetComponent<Image>().sprite = CharacterAtk3Image[1];
                        imege2.GetComponent<Image>().sprite = CharacterAtk3Image[2];
                        break;
                    case GameManagement.AtkID.Atk3:
                        imege1.GetComponent<Image>().sprite = CharacterAtk3Image[2];
                        imege2.GetComponent<Image>().sprite = CharacterAtk3Image[0];
                        break;
                }
                break;
            case GameManagement.Character.Wizard:
                switch (GameManagement.Instance.Atk)
                {
                    case GameManagement.AtkID.Atk1:
                        imege1.GetComponent<Image>().sprite = CharacterAtk4Image[0];
                        imege2.GetComponent<Image>().sprite = CharacterAtk4Image[1];
                        break;
                    case GameManagement.AtkID.Atk2:
                        imege1.GetComponent<Image>().sprite = CharacterAtk4Image[1];
                        imege2.GetComponent<Image>().sprite = CharacterAtk4Image[2];
                        break;
                    case GameManagement.AtkID.Atk3:
                        imege1.GetComponent<Image>().sprite = CharacterAtk4Image[2];
                        imege2.GetComponent<Image>().sprite = CharacterAtk4Image[0];
                        break;
                }
                break;
        }


    }
}
