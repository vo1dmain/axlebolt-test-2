using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody;

    [Range(1f, 10f)]
    [SerializeField]
    private float _movementSpeed = 10f;



    #region Public methods

    public void Move(float direction)
    {
        float x = direction * _movementSpeed;
        float y = _rigidbody.velocity.y;
        Vector2 targetVelocity = new Vector2(x, y);

        _rigidbody.velocity = targetVelocity;
    }

    public void Stop()
    {
        _rigidbody.velocity = Vector2.zero;
    }

    #endregion

}