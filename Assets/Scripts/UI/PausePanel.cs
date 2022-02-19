using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject Text;

    private void Update()
    {
        if (LevelVictoryScreen._isLevelVictoryScreen)
        {
            Text.SetActive(false);
        }
        else
        {
            Text.SetActive(true);
        }
        PauseScreen.SetActive(PauseManager.Instance.IsPaused);
    }
}