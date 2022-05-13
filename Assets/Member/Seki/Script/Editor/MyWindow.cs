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
    int x,y = 0;
    Vector2 scrollPosition = new Vector2(0, 0);
    List<Texture2D> assetList = new List<Texture2D>();
    //List<GameObject> gameObjects = new List<GameObject>();



    Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

    GameObject gameObject;

    bool dragF;
 



    [SerializeField]
    GameObject Emp;
    //取得したパスが入る配列
    public Texture2D asset,buttonTex;
    string[] filePathArray; 

    [MenuItem("test/MyWindow")]


    static void Open()
    {
        MyWindow window = GetWindow<MyWindow>();
        window.titleContent = new GUIContent("ウィンドウ");
    }

    private void OnOccurredEventOnSceneView(SceneView scene)
    {
        //発生したイベントの種類をログで表示
        Debug.Log(Event.current.type);
    }

    private void OnGUI()
    {

        x = EditorGUILayout.IntField("X",x);

        y = EditorGUILayout.IntField("Y",y);
        Emp = EditorGUILayout.ObjectField("Emp",Emp,typeof(GameObject),true) as GameObject;


        EditorGUILayout.BeginHorizontal();
        GUILayout.Box(buttonTex, GUILayout.Width(100), GUILayout.Height(100));
        EditorGUILayout.EndHorizontal();

        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);


        Add();


        EditorGUILayout.EndScrollView();


        //オブジェクトの画像変更

        Selection.selectionChanged += () => 
        {
            if (true) 
            { 
                Debug.Log(Selection.activeGameObject); 
            } 
        };


 

        SceneView.duringSceneGui += (SceneView sceneView) =>
         {
            Event e = Event.current;
            if (e.type == EventType.MouseDrag)
            {
                //Debug.Log("a");
               
       
            }
             //Debug.Log("modifierKeysChanged");

             Vector3 mousePosition = Event.current.mousePosition;

             //シーン上の座標に変換
             mousePosition.y = SceneView.currentDrawingSceneView.camera.pixelHeight - mousePosition.y;
             mousePosition = SceneView.currentDrawingSceneView.camera.ScreenToWorldPoint(mousePosition);


             //Debug.Log("座標 : " + mousePosition.x.ToString("F2") + ", " + mousePosition.y.ToString("F2"));
         };
        

   
        if (GUILayout.Button("生成", GUILayout.Width(60)))
        {
            for(int i=0;i<y;i++)
            {

                for(int j=0;j<x; j++)
                {
                    
                   var obj= Instantiate(Emp, new Vector2(j-8.5f, i-4.5f), Quaternion.identity);
                    //obj.GetComponent<SpriteRenderer>
                }

                
            }
            Debug.Log(Emp);
            //PrefabUtility.InstantiatePrefab(Emp);
           
        }
        

        /*
        Masu = EditorGUILayout.IntField(Masu);




        /*
        var splitterRect = EditorGUILayout.GetControlRect(false, GUILayout.Height(2));
        splitterRect.x = 5;
        splitterRect.width = position.width;*/

        //GUILayout.BeginArea(new Rect(50, 50, 100+(sq * Masu), 100 +(sq * Masu)));
        /*
        EditorGUILayout.BeginHorizontal(GUI.skin.box);
        scrollPosition = EditorGUILayout.BeginScrollView(new Vector2(Masu,Masu),GUI.skin.box);
        for (int i = 0; i < Masu; i++)
        {
           // EditorGUI.DrawRect(new Rect(new Vector2(10, 10+(sq*i)), new Vector2(sq * Masu, weight)), Color.Lerp(Color.white, Color.white, 0.7f));
            //GUILayout.Space(sq*i/2);
        }
        */
        /*
        dicNum = EditorGUILayout.IntField(dicNum);
        */

        /*ボタンでプレハブ生成の名残
        
        gameObject = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Member/Seki/imageee/Emp.prefab");

        if (GUILayout.Button("PPPP"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create(buttonTex,new Rect(0,0,1,1),Vector2.zero);
            gameObject.name =buttonTex.ToString();
            Debug.Log(gameObject);
            PrefabUtility.SaveAsPrefabAsset(gameObject, directoryPath);
        }
        */


        //四角
        /*
        int k =0;
        for(int j=0;j<Masu;j++)
        {
            for (int i = 0; i < Masu; i++)
            {
                //Draw(i * sq, j*sq);
                GUILayout.Box(AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/Member/Seki/imageee/White.png"), GUILayout.Width(50), GUILayout.Height(50));
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

        EditorGUILayout.EndScrollView();*/
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



       

        /*
        Event e = Event.current;
        if (e.type == EventType.MouseDown)
        {
           Debug.Log(Event.current.mousePosition);

            EditorGUILayout.LabelField(new GUIContent(buttonTex));

            GUILayout.Box(buttonTex);
        }

        */

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



                    var Object = Selection.activeGameObject;
                    Debug.Log(Object);
                    if (Object != null && asset != null)
                        Object.GetComponent<SpriteRenderer>().sprite = Sprite.Create(asset, new Rect(0,0,100,100), new Vector2(0.5f,0.5f));
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

public class Sample
{

    MyWindow myWindow;

   
    public Texture2D Hoge()
    {
        myWindow = new MyWindow();
        Texture2D tex=null;

        tex = myWindow.buttonTex;

        return tex;
    }



}