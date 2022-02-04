using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : GeneralSingleton<PauseManager>
{
    #region Properties

    public GameObject _pauseScreen;
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

    #region Private methods

    private void ChangePaused()
    {
        IsPaused = !IsPaused;

        Time.timeScale = IsPaused ? 0 : 1;
    }

    private bool IsEscPressed()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }   

    #endregion
}
