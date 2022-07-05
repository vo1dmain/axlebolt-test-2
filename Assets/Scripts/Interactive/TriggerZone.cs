using System;

using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TriggerZone : MonoBehaviour
{
    [SerializeField]
    private bool _isTriggered = false;

    private Collider2D _subject = null;

    public bool IsTriggered => _isTriggered;

    public event Action OnToggle;



    #region Private methods

    private void TryToggleTriggeredState(Collider2D subject, bool isTriggered)
    {
        bool subjectIsCharacter = subject.gameObject.TryGetComponent(out Character _);
        if (!subjectIsCharacter) return;
        if (_isTriggered == isTriggered) return;

        _isTriggered = isTriggered;
        OnToggle?.Invoke();
    }

    #endregion



    #region Unity messages

    private void OnTriggerStay2D(Collider2D subject)
    {
        if (_subject != null) return;

        _subject = subject;
        TryToggleTriggeredState(subject, true);
    }

    private void OnTriggerExit2D(Collider2D subject)
    {
        if (!_subject.Equals(subject)) return;

        _subject = null;
        TryToggleTriggeredState(subject, false);
    }

    #endregion
}
