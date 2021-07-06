using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ReplaceObjects))]
public class EditorReplaceObjects : Editor
{
    private void OnSceneGUI()
    {
        ReplaceObjects objParent = target as ReplaceObjects;

        if(objParent.replaceObjects)
        {
            for (int i = 0; i < objParent.transform.childCount; i++)
            {
                Vector3 pos = objParent.transform.GetChild(i).position;
                Quaternion rot = objParent.transform.GetChild(i).rotation;

                Selection.activeObject = PrefabUtility.InstantiatePrefab(objParent.replaceWith);
                GameObject g = Selection.activeObject as GameObject;

                g.transform.position = pos;
                g.transform.rotation = rot;

            }

            for (int i = 0; i < objParent.transform.childCount; i++)
            {
                DestroyImmediate(objParent.transform.GetChild(i).gameObject);
            }

            objParent.replaceObjects = false;
        }
        
    }

    
}
