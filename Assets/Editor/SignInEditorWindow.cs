using UnityEditor;
using UnityEngine;

public class SignInEditorWindow : EditorWindow
{
    private string email = "";
    private string password = "";
    private const string AuthKey = "IsAuthenticated";

    [InitializeOnLoadMethod]
    private static void CheckAuthentication()
    {
        if (!EditorPrefs.GetBool(AuthKey, false))
        {
            ShowWindow();
        }
    }

    [MenuItem("Tools/Sign In")]
    public static void ShowWindow()
    {
        GetWindow<SignInEditorWindow>("Sign In");
    }

    private void OnGUI()
    {
        if (EditorPrefs.GetBool(AuthKey, false))
        {
            GUILayout.Label("You are signed in", EditorStyles.boldLabel);
            if (GUILayout.Button("Sign Out"))
            {
                SignOut();
            }
            return;
        }

        GUILayout.Label("Sign In", EditorStyles.boldLabel);

        email = EditorGUILayout.TextField("Email", email);
        password = EditorGUILayout.PasswordField("Password", password);

        if (GUILayout.Button("Sign In"))
        {
            SignIn(email, password);
        }
    }

    private void SignIn(string email, string password)
    {
        // This is where you would add your sign-in logic.
        // For this example, let's assume sign-in is always successful.

        // Set the authentication flag
        EditorPrefs.SetBool(AuthKey, true);
        Debug.Log("Sign-in successful");

        // Close the sign-in window
        this.Close();
    }

    private void SignOut()
    {
        // Clear the authentication flag
        EditorPrefs.SetBool(AuthKey, false);
        Debug.Log("Signed out");

        // Reopen the sign-in window
        ShowWindow();
    }
}
