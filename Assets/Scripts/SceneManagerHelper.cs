using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerHelper : MonoBehaviour
{
    private static string previousScene = "";  // To store the name of the previous scene

    // Singleton pattern to ensure only one instance of this object exists
    private static SceneManagerHelper instance;

    private void Awake()
    {
        // If an instance of this object already exists, destroy this one
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // Otherwise, set this instance as the singleton
            instance = this;

            // Don't destroy this object when loading a new scene
            DontDestroyOnLoad(gameObject);
        }
    }

    // Call this method to store the name of the current scene as the previous scene
    public static void SetPreviousScene()
    {
        previousScene = SceneManager.GetActiveScene().name;
    }

    // Call this method to load the previous scene
    public void LoadPreviousScene()
    {
        if (!string.IsNullOrEmpty(previousScene))
        {
            SceneManager.LoadScene(previousScene);
        }
        else
        {
            Debug.LogWarning("No previous scene to load.");
        }
    }
}
