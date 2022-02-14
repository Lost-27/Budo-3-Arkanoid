using System.Collections.Generic;
using UnityEngine;

public class HeartBar : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject _heartCellPrefab;
    [SerializeField] private Transform _heartsBar;

    private List<GameObject> _maxHearts = new List<GameObject>();

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        InstantiateHearts();
        UpdateCells();
        GameManager.Instance.OnLivesChanged += UpdateCells;
    }


    private void OnDestroy()
    {
        GameManager.Instance.OnLivesChanged -= UpdateCells;
    }

    #endregion


    #region Private methods

    private void InstantiateHearts()
    {
        for (int i = 0; i < GameManager.Instance.MaxLives; i++)
        {
            GameObject heart = Instantiate(_heartCellPrefab, _heartsBar);
            _maxHearts.Add(heart);
        }
    }

    private void UpdateCells()
    {
        for (int i = 0; i < _maxHearts.Count; i++)
        {
            GameObject heart = _maxHearts[i];
            bool isActive = GameManager.Instance.CurrentLives > i;
            heart.SetActive(isActive);
        }
    }

    #endregion
}