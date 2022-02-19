using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    #region Variables
    
    public TextMeshProUGUI ScoreLabel;

    #endregion


    #region Unity lifecycle
    private void Start()
    {        
        GameManager.Instance.OnScoreChanged += UpdateScoreLabel;        
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnScoreChanged -= UpdateScoreLabel;        
    }

    #endregion


    #region Private methods

    private void UpdateScoreLabel()
    {
        ScoreLabel.text = $"Score: {GameManager.Instance.Score}";
    }    

    #endregion
}