using UnityEngine;

public class Pad : MonoBehaviour
{
    #region Variables

    [SerializeField] private float _xRange;    

    #endregion


    #region Unity lifecycle
        
    private void Update()
    {
        MovingPadWithMouse();
    }

    #endregion


    #region Private methods

    private void MovingPadWithMouse()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log(worldPos);

        Vector2 currentPos = transform.position;
        currentPos.x = Mathf.Clamp(worldPos.x, -_xRange, _xRange);
        transform.position = currentPos;
    }

    #endregion
}