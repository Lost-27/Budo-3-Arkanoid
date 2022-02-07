using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public GameObject PauseScreen;

    private void Update()
    {
        PauseScreen.SetActive(PauseManager.Instance.IsPaused);
    }
}