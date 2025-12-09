using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // This method is called when you want to load a new scene
    public void LoadNewScene(string sceneName)
    {
        // Store the current scene as the previous scene before loading the new one
        SceneManagerHelper.SetPreviousScene();

        // Load the new scene
        SceneManager.LoadScene(sceneName);
    }
}
