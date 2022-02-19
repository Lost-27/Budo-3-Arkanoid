using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelVictoryScreen : MonoBehaviour
{
    #region Veriables

    [SerializeField] private GameObject _innerContainer;
    [SerializeField] private TextMeshProUGUI _dynamicScoreLabel;
    [SerializeField] private Button _nextButton;

    public static bool _isLevelVictoryScreen; //???

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        _nextButton.onClick.AddListener(NextButtonClick);
    }

    private void Start()
    {
        _isLevelVictoryScreen = false;
        SetVisibility(false);
        LevelManager.Instance.OnLevelCleared += LevelCleared;
    }

    private void OnDestroy()
    {
        LevelManager.Instance.OnLevelCleared -= LevelCleared;
    }

    #endregion
    

    #region Private methods

    private void SetVisibility(bool isActive)
    {
        _innerContainer.SetActive(isActive);
    }

    private void LevelCleared()
    {
        _isLevelVictoryScreen = true;
        SetVisibility(true);
        _dynamicScoreLabel.text = GameManager.Instance.Score.ToString();
    }

    private void NextButtonClick()
    {
        SceneHelper.Instance.LoadNextScene();;
        PauseManager.Instance.UnPause();
    }

    #endregion
}