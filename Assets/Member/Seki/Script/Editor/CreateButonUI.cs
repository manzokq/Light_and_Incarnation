using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[InitializeOnLoad]
public static class CreateButtonUi
{
    static Seisei seisei;
    static string directoryPath = "Assets/Member/Seki/imageee";
    static List<Texture2D> assetList = new List<Texture2D>();

    static public Texture2D asset, tex;
    static string[] filePathArray;
    static GameObject emp;

    static CreateButtonUi()
    {
        seisei = new Seisei();
        SceneView.duringSceneGui += OnGui;
    }

    private static void OnGui(SceneView sceneView)
    {
        Handles.BeginGUI();

        ShowButtons(sceneView.position.size);

        Handles.EndGUI();

        Event e = Event.current;
        if (e.type == EventType.MouseDown)
        {
            
            Vector2 mousePosition = Event.current.mousePosition;

            //シーン上の座標に変換
            mousePosition.y = SceneView.currentDrawingSceneView.camera.pixelHeight - mousePosition.y;
            mousePosition = SceneView.currentDrawingSceneView.camera.ScreenToWorldPoint(mousePosition);

            Debug.Log("座標 : " + mousePosition.x.ToString("F2") + ", " + mousePosition.y.ToString("F2"));
            //var empObj= (GameObject)PrefabUtility.InstantiatePrefab(emp);

            mousePosition.x = Mathf.Round(mousePosition.x);
            mousePosition.y = Mathf.Round(mousePosition.y);

            /*生成部分
            var go = seisei.Ins(emp,mousePosition);
            go.GetComponent<SpriteRenderer>().sprite =
            Sprite.Create(tex, new Rect(0, 0, 100, 100), new Vector2(0.5f, 0.5f));
            */
            Debug.Log("マウスクリック ");
        }

    }

    private static void ShowButtons(Vector2 sceneSize)
    {
        var count = 10;
        var buttonSize = 40;
        int i = 0;
        emp= AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Member/Seki/Emp.prefab");
        //Debug.Log(emp);

        filePathArray = Directory.GetFiles
        (directoryPath, "*", SearchOption.AllDirectories);

        //取得したパスの画像を
        foreach (string filePath in filePathArray)
        {

            // 画面下部、水平、中央寄せをコントロールする Rect
            var rect = new Rect(
              sceneSize.x / 2 - buttonSize * count / 2 + buttonSize * i,
              sceneSize.y - buttonSize * 1.6f,
              buttonSize,
              buttonSize);

            asset = AssetDatabase.LoadAssetAtPath<Texture2D>(filePath);
            if (asset != null)
            {
                assetList.Add(asset);

                if (GUI.Button(rect, asset))
                {
                    Debug.Log(asset);

                    tex = asset;


                }
            }
            i++;
        }
        var rec = new Rect(
            sceneSize.x / 2 - buttonSize * count / 2 + buttonSize * i,
            sceneSize.y - buttonSize * 1.6f,
            buttonSize,
            buttonSize);
        if (GUI.Button(rec,"生成"))
        {
            for (int k = 0; k < 50; k++)
            {

                for (int j = 0; j < 150; j++)
                {

                    seisei.Ins(emp, new Vector2(j - 8.5f, k - 4.5f));
                    //obj.GetComponent<SpriteRenderer>
                }


            }
        }

    }

    static void Inst()
    {
        GameObject go;
        go = (GameObject)PrefabUtility.InstantiatePrefab(emp);
        Selection.activeGameObject = go;
        Undo.RegisterCreatedObjectUndo(go, "Create Character");
        go.GetComponent<SpriteRenderer>().sprite =
            Sprite.Create(asset, new Rect(0, 0, 100, 100), new Vector2(0.5f, 0.5f));
    }
}

class Seisei : MonoBehaviour
{
    public GameObject Ins(GameObject gameObject,Vector2 Pos)
    {
        GameObject go;
        go = Instantiate(gameObject, Pos, Quaternion.identity);
        return go;
    }

}