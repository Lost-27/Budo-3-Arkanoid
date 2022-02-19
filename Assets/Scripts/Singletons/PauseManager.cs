using UnityEngine;

public class PauseManager : GeneralSingleton<PauseManager>
{
    #region Properties

    public bool IsPaused { get; private set; }

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        if (IsEscPressed())
        {
            ChangePaused();
        }
    }

    #endregion
    

    #region Public methods

    public void Pause()
    {
        IsPaused = true;
        ApplyTimeScale();
    }
    public void UnPause()
    {
        IsPaused = false;
        ApplyTimeScale();
    }

    #endregion
    

    #region Private methods

    private void ChangePaused()
    {
        IsPaused = !IsPaused;

        ApplyTimeScale();
    }

    private void ApplyTimeScale()
    {
        Time.timeScale = IsPaused ? 0 : 1;
    }

    private bool IsEscPressed()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }

    #endregion
}