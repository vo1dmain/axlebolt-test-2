using UnityEngine;
using System.Linq;
using System;

[RequireComponent(typeof(CharacterManager))]
[RequireComponent(typeof(Spawner))]
[RequireComponent(typeof(FinishManager))]
public class SceneController : MonoBehaviour
{
    [SerializeField]
    private CharacterManager _characterManager;

    [SerializeField]
    private Spawner _spawner;

    [SerializeField]
    private FinishManager _finish;



    public event Action LevelFinished;



    #region Private methods

    private void OnLevelFinished()
    {
        LevelFinished?.Invoke();
    }

    #endregion



    #region Unity messages

    private void Awake()
    {
        _finish.AllFinished += OnLevelFinished;

        _spawner.SetRespawnQueue(_characterManager.Characters.Cast<ISpawnable>());
        _finish.SetCharacters(_characterManager.Characters);
    }

    private void Start()
    {
        _spawner.Respawn();
    }

    private void OnDestroy()
    {
        _finish.AllFinished -= OnLevelFinished;
    }

    #endregion
}
