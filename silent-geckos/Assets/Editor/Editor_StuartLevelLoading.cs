using System.Collections;
using System.Collections.Generic;
using log4net.Core;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(LevelController))]
public class Editor_StuartLevelLoading : Editor
{
    public override void  OnInspectorGUI () {
        LevelController levelController = (LevelController)target;
        if(GUILayout.Button("End Level")) {
            levelController.LevelEnd(true); 
        }
       
        DrawDefaultInspector();
    }}
