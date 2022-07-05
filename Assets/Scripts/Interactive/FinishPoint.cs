using System;

using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FinishPoint : MonoBehaviour
{
    public event Action<Character> FinishCrossed;

    public event Action<Character> FinishLeft;



    #region Private methods

    private bool IsSubjectCharacter(Collider2D subject, out Character character)
    {
        return subject.gameObject.TryGetComponent(out character);
    }

    #endregion



    #region Unity messages

    private void OnTriggerEnter2D(Collider2D subject)
    {
        if (IsSubjectCharacter(subject, out Character c))
        {
            FinishCrossed?.Invoke(c);
        }
    }

    private void OnTriggerExit2D(Collider2D subject)
    {
        if (IsSubjectCharacter(subject, out Character c))
        {
            FinishLeft?.Invoke(c);
        }
    }

    #endregion
}
