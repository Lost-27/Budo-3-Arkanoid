using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public GameObject PauseScreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseManager.Instance.IsPaused)
            {
                PauseScreen.SetActive(true);
            }
            else
            {
                PauseScreen.SetActive(false);
            }
        }
    }
}