using UnityEngine.SceneManagement;

public class SceneHelper : GeneralSingleton<SceneHelper>
{
    #region Public methods

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    
    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (SceneManager.sceneCountInBuildSettings <= nextSceneIndex)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    #endregion
}