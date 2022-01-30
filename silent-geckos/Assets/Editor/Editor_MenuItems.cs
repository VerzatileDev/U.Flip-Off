using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Editor_MenuItems : MonoBehaviour
{
    [MenuItem("Stuart Custom Debug/WipeCheckpointData")]
    static void WipeCheckpointData()
    {
        if (!Application.isPlaying) return;
        CheckpointData[] data = Resources.FindObjectsOfTypeAll<CheckpointData>();
        foreach (var d in data)
        {
	        d.Wipe();
        }
    }
    [MenuItem("Stuart Custom Debug/WipeCumulativeData")]
    static void WipeCumulativeData()
    {
        if (!Application.isPlaying) return;
        CumScoreData[] data = Resources.FindObjectsOfTypeAll<CumScoreData>();
        foreach (var d in data)
        {
            d.Wipe();
        }
    }
}
