using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class Calcutron : MonoBehaviour {
#if UNITY_EDITOR
    // Use this for initialization
    [HideInInspector]
    public List<string> bugs = new List<string>();

    [HideInInspector]
    public List<string> resolved = new List<string>();


    void Start () {
        EditorUtility.SetDirty(this);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void AddBug(string s)
    {
        EditorUtility.SetDirty(this);

        bugs.Add(s);
        Debug.Log("Added: " + s);
    }

    public void ClearList()
    {
        bugs.Clear();
        Debug.Log("Bugs cleared");
    }

    public void ClearResolvedList()
    {
        resolved.Clear();
        Debug.Log("Resolved bugs cleared");
    }

    public string GetRandomBug()
    {
        int i = Random.Range(0, bugs.Count);
        return bugs[i];
    }

    public void LogBugs()
    {
        if(bugs.Count > 0)
        {
            foreach (string s in bugs)
            {
                Debug.Log(s);
            }
        }
        else
        {
            Debug.Log("404 error, bugs not found");
        }

    }

    public void LogResolvedBugs()
    {
        if (resolved.Count > 0)
        {
            foreach (string s in resolved)
            {
                Debug.Log("Resolved: " + s);
            }
        }
        else
        {
            Debug.Log("404 error, bugs not found");
        }

    }

    public void ClearBug(string s)
    {
        if (bugs.Contains(s))
        {
            bugs.Remove(s);
            resolved.Add(s);
            Debug.Log("Resolved: " + s);
        }
        else
        {
            Debug.Log("404 error, bug not found");
        }
    }
#endif
}
