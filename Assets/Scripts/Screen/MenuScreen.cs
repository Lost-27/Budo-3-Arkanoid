using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    #region Variables

    public Button PlayButton;
    public Button QuitButton;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        PlayButton.onClick.AddListener(PlayButtonClicked);
        QuitButton.onClick.AddListener(QuitButtonClicked);
    }

    #endregion


    #region Private methods

    private void QuitButtonClicked()
    {
        SceneHelper.Instance.Quit();
    }

    private void PlayButtonClicked()
    {
        SceneHelper.Instance.LoadNextScene();
    }

    #endregion
}