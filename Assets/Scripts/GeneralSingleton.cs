using UnityEngine;

public class GeneralSingleton<T> : MonoBehaviour
{
    #region Variables

    private static T _instance;

    #endregion


    #region Properties

    public static T Instance => _instance;

    #endregion
            

    #region Unity lifecycle

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion
}