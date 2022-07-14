using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public enum ItemID
    {
        Diary=0,
        Lamp,
        Key,


    }

    public static ItemManager Instance { get => _instance; }
    static ItemManager _instance;
    private ItemID ItemName;
    [HideInInspector]public  bool _diary = false;
    [HideInInspector] public bool _lamp = false;
    [HideInInspector] public bool _key = false;
    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }


    }

    public void Item(ItemID item,bool possession)
    //ItemManager.Instance.Item(ItemManager.ItemID.アイテム名, true or false );で切り替え
    //アイテムの所持状況を切り替える
    {
        ItemName = item;
        switch(item)
        {
            case ItemID.Diary:
                _diary = possession;
                break;
            case ItemID.Lamp:
                _lamp = possession;
                break;
            case ItemID.Key:
                _key = possession;
                break;
        }
    }
}
