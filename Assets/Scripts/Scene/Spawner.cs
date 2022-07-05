using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private SpawnPoint[] _respawnPoints;

    private HashSet<ISpawnable> _queue;


    #region Public methods

    public void Respawn()
    {
        foreach (var respPoint in _respawnPoints)
        {
            if (respPoint is null) throw new NullReferenceException();
            if (respPoint.IsTaken) continue;

            if (respPoint.TrySpawn(_queue.Last()))
            {
                _queue.Remove(_queue.Last());
            }
        }
    }

    public void SetRespawnQueue(IEnumerable<ISpawnable> queue)
    {
        if (queue is null) throw new ArgumentNullException(nameof(queue));

        _queue = new HashSet<ISpawnable>(queue);
    }

    #endregion
}
