using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    #region Variables

    public TextMeshProUGUI LivesLabel;
    public TextMeshProUGUI ScoreLabel;

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        ScoreLabel.text = $"Score: {GameManager.Instance.Score}";
        LivesLabel.text = $"Lives: {GameManager.Instance.Lives}";
    }

    #endregion
}