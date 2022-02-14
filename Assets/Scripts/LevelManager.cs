using System;

public class LevelManager : GeneralSingleton<LevelManager>
{
    #region Variables

    private int _blocksCount;

    #endregion


    #region Events

    public event Action OnGameOver;

    #endregion


    #region Unity lifecycle

    private void OnEnable()
    {
        Block.OnCreated += AddBlock;
        Block.OnDestroyed += RemoveBlock; 
    }
    private void OnDisable()
    {
        Block.OnCreated -= AddBlock;
        Block.OnDestroyed -= RemoveBlock;
    }

    #endregion


    #region Private methods

    private void AddBlock()
    {
        _blocksCount++;
    }
    private void RemoveBlock(Block block)
    {
        _blocksCount--;        

        if (_blocksCount <= 0)
        {
            OnGameOver?.Invoke();
        }
    }

    #endregion
}
