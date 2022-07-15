using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGet : MonoBehaviour
{
    private GameObject _itemObject;
    private string _itemname;
    // Start is called before the first frame update
    void Start()
    {
        _itemObject = this.gameObject;
        this._itemname=_itemObject.name;
        
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch(_itemname)
            {
                case "Diary":
                    ItemManager.Instance.Item(ItemManager.ItemID.Diary,true);
                    break;

                case "Lamp":
                    ItemManager.Instance.Item(ItemManager.ItemID.Lamp, true);
                    break;

                case "Key":
                    ItemManager.Instance.Item(ItemManager.ItemID.Key, true);
                    break;
                default:
                    Debug.LogWarning("その名前は存在しません");
                    break;
            }
            Debug.Log(_itemname);
            this.gameObject.SetActive(false);//所持状況をマネージャーで切り替えた後にこのオブジェクトを消す
        }
    }
}
