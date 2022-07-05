using System;

using UnityEngine;

class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    private bool _isTaken = false;

    public bool IsTaken => _isTaken;


    #region Public methods

    public bool TrySpawn(ISpawnable spawnable)
    {
        if (spawnable is null) return false;
        if (_isTaken) return false;

        spawnable.SpawnTo(transform.position);
        _isTaken = true;
        return true;
    }

    #endregion
}
