using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class CharacterManager : MonoBehaviour
{
    #region Private fields

    [SerializeField]
    private List<Character> _characters;

    [SerializeField]
    private Character _currentCharacter;

    [SerializeField]
    private InputHandler _inputHandler;

    #endregion



    #region Public properties

    public IEnumerable<Character> Characters => _characters;

    #endregion



    #region Public methods

    public void PickNextCharacter()
    {
        int nextIndex = _characters.IndexOf(_currentCharacter) + 1;
        if (nextIndex >= _characters.Count)
        {
            nextIndex = 0;
        }

        SetCurrentCharacter(nextIndex);
    }

    #endregion



    #region Private methods

    private void MoveCurrentCharacter(float direction)
    {
        _currentCharacter.Controller.Move(direction);
    }

    private void SetCurrentCharacter(int index)
    {
        _currentCharacter.Controller.Stop();
        _currentCharacter = _characters[index];
    }

    #endregion



    #region Unity messages

    private void Awake()
    {
        _inputHandler = GetComponent<InputHandler>();
        SetCurrentCharacter(0);

        _inputHandler.HorizontalDirChanged += MoveCurrentCharacter;
        _inputHandler.NextCharButtonPressed += PickNextCharacter;
    }

    private void OnDestroy()
    {
        _inputHandler.HorizontalDirChanged -= MoveCurrentCharacter;
        _inputHandler.NextCharButtonPressed -= PickNextCharacter;
    }

    #endregion
}
