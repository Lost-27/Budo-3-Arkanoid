using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    #region Variables

    public int lives = 3;

    public GameObject PauseScreen;
    public TextMeshProUGUI ScoreLabel;

    #endregion

    private void Start()
    {
    }


    private void Update()
    {
        ScoreLabel.text = $"Score: {GameManager.Instance.Score}";
    }
}