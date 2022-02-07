using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    #region Variables

    public TextMeshProUGUI ScoreLabel;
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

        ScoreLabel.text = Convert.ToString(GameManager.Instance.Score);
    }    

    #endregion


    #region Private methods

    private void QuitButtonClicked()
    {
        _sceneHelper.Quit();
    }

    private void PlayButtonClicked()
    {
        GameManager.Instance.Reset();
        _sceneHelper.LoadScene(1);
    }

    #endregion
}