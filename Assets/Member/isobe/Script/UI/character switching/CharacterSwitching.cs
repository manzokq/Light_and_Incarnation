using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterSwitching : MonoBehaviour
{

    [SerializeField]
    private GameObject imege1;

    public List<Sprite> CharacterImage = new List<Sprite>();
    private void Update()
    {
        //if()//�L�����N�^�[�ؑւ��s��ꂽ�ꍇ
        //{
        switch (GameManagement.Instance.PlayerCharacter)
        {
            case GameManagement.CharacterID.Girl:

                imege1.GetComponent<Image>().sprite = CharacterImage[0];



                break;
            case GameManagement.CharacterID.Swordsman:

                imege1.GetComponent<Image>().sprite = CharacterImage[1];



                break;
            case GameManagement.CharacterID.Bowman:

                imege1.GetComponent<Image>().sprite = CharacterImage[2];


                break;

        }
    }

}
