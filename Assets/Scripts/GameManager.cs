using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    public TextMeshProUGUI ScoreLabel;

    private int _score;

    #endregion


    #region Unity lifecycle

    void Start()
    {
        UpdateScore(_score);
    }

    #endregion


    #region Public methods

    public void UpdateScore(int pointValue)
    {
        _score += pointValue;
        ScoreLabel.text = "Score: " + _score;
    }

    #endregion

}
