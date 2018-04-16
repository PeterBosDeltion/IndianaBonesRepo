using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR

[CustomEditor(typeof(Calcutron))]
public class AddBugEditorButton : Editor
{


    public string text;

    public override void OnInspectorGUI()
    {


        DrawDefaultInspector();
        EditorGUILayout.LabelField("Enter text and click Add Bug to add a new bug.");
        string s = EditorGUILayout.TextArea(text);
        text = s;
        Calcutron myScript = (Calcutron)target;
        if (GUILayout.Button("Select Random Bug"))
        {
            string st = myScript.GetRandomBug();
            text = st;
            Debug.Log(st);
        }
        if (GUILayout.Button("Add Bug"))
        {
            myScript.AddBug(s);
        }
        if (GUILayout.Button("Log Bugs"))
        {
            myScript.LogBugs();
        }

        if (GUILayout.Button("Resolve current selected bug"))
        {
            myScript.ClearBug(text);
        }
        if (GUILayout.Button("Log Resolved Bugs"))
        {
            myScript.LogResolvedBugs();
        }
        if (GUILayout.Button("Clear Bugs List"))
        {
            myScript.ClearList();
        }
        if (GUILayout.Button("Clear Resolved List"))
        {
            myScript.ClearResolvedList();
        }
    }
}
#endif
