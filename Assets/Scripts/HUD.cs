using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    #region Variables

    public TextMeshProUGUI LivesLabel;
    public TextMeshProUGUI ScoreLabel;

    #endregion

    private void Start()
    {
    }


    private void Update()
    {
        ScoreLabel.text = $"Score: {GameManager.Instance.Score}";
        LivesLabel.text = $"Lives: {GameManager.Instance.Lives}";
    }
}