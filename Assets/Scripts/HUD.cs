using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    #region Variables

    public TextMeshProUGUI LivesLabel;
    public TextMeshProUGUI ScoreLabel;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        UpdateScoreLabel();
    }

    private void OnEnable()
    {
        GameManager.Instance.OnScoreUpdated += UpdateScoreLabel;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnScoreUpdated -= UpdateScoreLabel;
    }

    private void Update()
    {
        UpdateLivesLabel();
    }

    #endregion


    #region Private methods

    private void UpdateScoreLabel()
    {
        ScoreLabel.text = $"Score: {GameManager.Instance.Score}";
    }

    private void UpdateLivesLabel()
    {
        LivesLabel.text = $"Lives: {GameManager.Instance.Lives}";
    }

    #endregion
}