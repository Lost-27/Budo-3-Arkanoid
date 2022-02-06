using UnityEngine.SceneManagement;

public class SceneHelper : GeneralSingleton<SceneHelper>
{
    #region Public methods

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
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