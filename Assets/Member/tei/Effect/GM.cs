using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GM : MonoBehaviour
{
    public float deleteTime = 3.0f;
    public bool etimrs = false; 
    //表示コンポネット
    public RawImage img;
    //表示画像リスト
    public List<Texture> textures_list = new List<Texture>();

    // Start is called before the first frame update
    void Start()
    {
        //画像ファイル読み込む
        img = GameObject.Find("DisplayImage").GetComponent<RawImage>();
        read_img(10);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            img.texture = textures_list[1];
            Invoke("co", 3);
            {
                Destroy(gameObject, deleteTime);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            img.texture = textures_list[2];
        }
    }

    //ファイルチェックし指定した画像を読み込むして代入
    public void read_img(int n)
    {
        Texture tmp;
        for (int i = 1; i < n + 1; i++)
        {
            tmp = Resources.Load("img/" + i) as Texture;
            textures_list.Add(tmp);
        }
    }
    //透明度
    private void co()
    {
        etimrs = true;

    }

}
