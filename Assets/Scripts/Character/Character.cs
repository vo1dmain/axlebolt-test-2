using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]
public class Character : MonoBehaviour, ISpawnable
{
    [SerializeField]
    private CharacterController2D _controller;

    [SerializeField]
    private bool _hasFinished = false;



    public CharacterController2D Controller => _controller;
    public bool HasFinished => _hasFinished;



    #region Public methods

    public void SpawnTo(Vector3 position)
    {
        transform.position = position;
    }

    public void SetHasFinished()
    {
        _hasFinished = true;
    }

    public void SetUnfinished()
    {
        _hasFinished = false;
    }

    #endregion



    #region Unity messages

    private void Awake()
    {
        _controller = GetComponent<CharacterController2D>();
    }

    #endregion
}
