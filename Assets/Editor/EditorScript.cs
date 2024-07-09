using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class EditorScript
{
    static EditorScript()
    {
        // This runs when the editor loads
        EditorApplication.update += OnEditorUpdate;
        EditorApplication.quitting += OnEditorQuit;

        Debug.Log("Editor started");
        FirestoreHelper.SetEnvironmentVariable();
        Debug.Log("EnvironmentVariableSetupDone");
        
    }

    private static void OnEditorUpdate()
    {
        // Put the logic you want to run while the editor is open here
        /*Debug.Log("Editor is running");*/
    }

    private static void OnEditorQuit()
    {
        // This runs when the editor is closing
        EditorApplication.update -= OnEditorUpdate;
        Debug.Log("Editor is quitting");
    }
}
