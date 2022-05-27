using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GM : MonoBehaviour
{
    public float deleteTime = 3.0f;
    public bool etimrs = false; 
    //�\���R���|�l�b�g
    public RawImage img;
    //�\���摜���X�g
    public List<Texture> textures_list = new List<Texture>();

    // Start is called before the first frame update
    void Start()
    {
        //�摜�t�@�C���ǂݍ���
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

    //�t�@�C���`�F�b�N���w�肵���摜��ǂݍ��ނ��đ��
    public void read_img(int n)
    {
        Texture tmp;
        for (int i = 1; i < n + 1; i++)
        {
            tmp = Resources.Load("img/" + i) as Texture;
            textures_list.Add(tmp);
        }
    }
    //�����x
    private void co()
    {
        etimrs = true;

    }

}
