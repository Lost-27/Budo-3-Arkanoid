using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    #region Variables

    public Button PlayButton;
    public Button QuitButton;

    private SceneHelper _sceneHelper;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        PlayButton.onClick.AddListener(PlayButtonClicked);
        QuitButton.onClick.AddListener(QuitButtonClicked);

        _sceneHelper = FindObjectOfType<SceneHelper>();
    }

    #endregion


    #region Private methods

    private void QuitButtonClicked()
    {
        _sceneHelper.Quit();
    }

    private void PlayButtonClicked()
    {
        _sceneHelper.LoadScene(1);
    }

    #endregion
}