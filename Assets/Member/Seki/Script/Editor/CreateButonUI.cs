using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[InitializeOnLoad]
public static class CreateButtonUi
{
    
    static string directoryPath = "Assets/Member/Seki/imageee";
    static List<Texture2D> assetList = new List<Texture2D>();

    static public Texture2D asset, buttonTex;
    static string[] filePathArray;
    static GameObject emp;

    static CreateButtonUi()
    {
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
            Debug.Log("マウスクリック ");
        }
        if(e.type == EventType.MouseUp)
        {
            Debug.Log("マウス離し");
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

                    buttonTex = asset;

                    GameObject go;
                    go= (GameObject)PrefabUtility.InstantiatePrefab(emp);
                    Selection.activeGameObject = go;
                    Undo.RegisterCreatedObjectUndo(go, "Create Character");
                    go.GetComponent<SpriteRenderer>().sprite = 
                        Sprite.Create(asset, new Rect(0, 0, 100, 100), new Vector2(0.5f, 0.5f));
                    
                }
            }
            i++;
        }

    }
}

class Seisei : MonoBehaviour
{
    void Ins(GameObject gameObject,Vector2 mousePosition)
    {
        Instantiate(gameObject, mousePosition, Quaternion.identity);

    }
}