using System;
using System.Collections.Generic;

using UnityEngine;

public class FinishManager : MonoBehaviour
{
    [SerializeField]
    private FinishPoint _finishPoint;

    [SerializeField]
    private IEnumerable<Character> _charactersToFinish;

    public event Action AllFinished;



    #region Public methods

    public void SetCharacters(IEnumerable<Character> characters)
    {
        _charactersToFinish = characters ?? throw new ArgumentNullException(nameof(characters));
    }

    #endregion



    #region Private methods

    private void OnFinishCrossed(Character character)
    {
        character.SetHasFinished();

        if (IfAllFinished())
        {
            AllFinished?.Invoke();
        }
    }

    private void OnFinishLeft(Character character)
    {
        character.SetUnfinished();
    }

    private bool IfAllFinished()
    {
        if (_charactersToFinish == null) throw new NullReferenceException();

        bool areAllFinished = true;
        foreach (Character character in _charactersToFinish)
        {
            areAllFinished &= character.HasFinished;
        }

        return areAllFinished;
    }

    #endregion



    #region Unity messages

    private void Awake()
    {
        _finishPoint.FinishCrossed += OnFinishCrossed;
        _finishPoint.FinishLeft += OnFinishLeft;
    }

    private void OnDestroy()
    {
        _finishPoint.FinishCrossed -= OnFinishCrossed;
        _finishPoint.FinishLeft -= OnFinishLeft;
    }

    #endregion
}
