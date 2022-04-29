using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class MyWindow : EditorWindow
{

    /// <summary>
    /// 参照するフォルダ
    /// Assets直下のimageeeフォルダ
    /// </summary>
    static string directoryPath = "Assets/Member/Seki/imageee";
    const int weight = 2;
    const int sq = 50;
    int Masu,dicNum = 0;
    Vector2 scrollPosition = new Vector2(0, 0);
    List<Texture2D> assetList = new List<Texture2D>();
    //List<GameObject> gameObjects = new List<GameObject>();



    Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

    //GameObject gameObject;

    //取得したパスが入る配列
    Texture2D asset,buttonTex;
    string[] filePathArray; 

    [MenuItem("test/MyWindow")]


    static void Open()
    {
        MyWindow window = GetWindow<MyWindow>();
        window.titleContent = new GUIContent("ウィンドウ");
    }

    private void OnGUI()
    {

       

       
        Add();

        GUILayout.Box(buttonTex, GUILayout.Width(100), GUILayout.Height(100));

        /*
        if (GUILayout.Button("更新", GUILayout.Width(60)))
        {
            Add();
           
        }
        */

        Masu = EditorGUILayout.IntField(Masu);




        /*
        var splitterRect = EditorGUILayout.GetControlRect(false, GUILayout.Height(2));
        splitterRect.x = 5;
        splitterRect.width = position.width;*/

        //GUILayout.BeginArea(new Rect(50, 50, 100+(sq * Masu), 100 +(sq * Masu)));

        EditorGUILayout.BeginHorizontal(GUI.skin.box);
        scrollPosition = EditorGUILayout.BeginScrollView(new Vector2(Masu,Masu),GUI.skin.box);
        for (int i = 0; i < Masu; i++)
        {
           // EditorGUI.DrawRect(new Rect(new Vector2(10, 10+(sq*i)), new Vector2(sq * Masu, weight)), Color.Lerp(Color.white, Color.white, 0.7f));
            //GUILayout.Space(sq*i/2);
        }


        dicNum = EditorGUILayout.IntField(dicNum);

        int k=0;
        for(int j=0;j<Masu;j++)
        {
            for (int i = 0; i < Masu; i++)
            {
                Draw(i * sq, j*sq);
                Debug.Log(k);
                dic[k]= new List<int> { i * sq, j * sq, 0, 0 };
                k++;
                
            }
        }

        //EditorGUILayout.LabelField(ToStr));
        //dic[]
  
       
        //横線

        //EditorGUILayout.BeginHorizontal();
        for (int i = 0; i < Masu; i++)
        {
            //EditorGUI.DrawRect(new Rect(new Vector2(10 + (sq * i),10), new Vector2(weight, sq * Masu)), Color.Lerp(Color.white, Color.white, 0.7f));
            //EditorGUI.DrawRect(new Rect(new Vector2(10 + (sq * i),10), new Vector2(weight, sq * Masu)), Color.Lerp(Color.white, Color.white, 0.7f));
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.EndScrollView();
        /*
        if (GUILayout.Button("hoge"))
        {
            Debug.Log("huga");
        }*/

        //GUILayout.EndArea();


       
        for (int j = 0; j < 20; j++) 
        {
            EditorGUILayout.BeginHorizontal();
            for (int i = 0; i < 20; i++)
            {
                /*
                if (GUILayout.Button("hoge"))
                {
                    Debug.Log("huga");
                }*/
            }
            EditorGUILayout.EndHorizontal();
        }

        /*
        

        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);


        GUILayout.Button("Button");
        GUILayout.Button("Button");
        GUILayout.Button("Button");
        GUILayout.TextField("text");
        GUILayout.Button("Button");
        GUILayout.Button("Button");
        GUILayout.Button("Button");
        GUILayout.TextField("text");

        EditorGUILayout.EndScrollView();

        


        */



       


        Event e = Event.current;
        if (e.type == EventType.MouseDown)
        {
           // Debug.Log(Event.current.mousePosition);
        }

        

    }


    void Draw(int x,int y)
    {
        EditorGUI.DrawRect(new Rect(new Vector2(x, y), new Vector2(sq, weight)), Color.Lerp(Color.white, Color.white, 0.7f));
        EditorGUI.DrawRect(new Rect(new Vector2(x, y), new Vector2(weight, sq)), Color.Lerp(Color.white, Color.white, 0.7f));
        EditorGUI.DrawRect(new Rect(new Vector2(x, y + 50), new Vector2(sq, weight)), Color.Lerp(Color.white, Color.white, 0.7f));
        EditorGUI.DrawRect(new Rect(new Vector2(x + 50, y), new Vector2(weight, sq)), Color.Lerp(Color.white, Color.white, 0.7f));


    }
    void Add()
    {
        //指定したディレクトリに入っている全ファイルを取得(子ディレクトリも含む)
        filePathArray = Directory.GetFiles
        (directoryPath, "*", SearchOption.AllDirectories);

        //取得したパスの画像を
        foreach (string filePath in filePathArray)
        {
            asset = AssetDatabase.LoadAssetAtPath<Texture2D>(filePath);
            if (asset != null)
            {
                assetList.Add(asset);

                if (GUILayout.Button(asset, GUILayout.Width(60), GUILayout.Height(60)))
                {
                    Debug.Log(asset);

                    buttonTex = asset;
                    //EditorGUILayout.LabelField(new GUIContent(asset));
                    //GUI.DrawTexture(new Rect(new Vector2(100,100),new Vector2(100,100)), asset);
                    /*
                    Sprite sprite = Sprite.Create(asset, new Rect(0, 0, 1, 1), Vector2.zero);
                    gameObject.AddComponent<SpriteRenderer>().sprite = sprite;

                    PrefabUtility.SaveAsPrefabAsset(gameObject, "Assets");*/
                    // Debug.Log(texture);
                }
            }
        }
    }




    void Button()
    {/*
        foreach (Texture2D texture in assetList)
        {
           
        }*/
        for(int i=0;i<assetList.Count;i++)
        {
            Debug.Log(i);

            if (GUILayout.Button(assetList[i], GUILayout.Width(60), GUILayout.Height(60)))
            {
                Debug.Log(assetList[i]);
            }
        }


    }
}

public class Sample : EditorWindow
{
   
    [MenuItem("test/Sample")]



    static void Open()
    {
        Sample sample = GetWindow<Sample>();
        sample.titleContent = new GUIContent("サンプル");
    }


    void OnGUI()
    {


    }


}