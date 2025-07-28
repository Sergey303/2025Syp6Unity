using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PhotoURL), true)]
public class PhotoURL_Editor : Editor
{
    public PhotoURL URL
    {
        get
        {
            return (PhotoURL)URL;
        }
    }
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("START", GUILayout.Height(40), GUILayout.Width(100)))
        {
            URL.Start_Script();
        }
        DrawDefaultInspector();
    }
}
