using System;

using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    private float _horizontalDirection = 0f;



    public event Action<float> HorizontalDirChanged;

    public event Action NextCharButtonPressed;



    #region Unity messages

    private void FixedUpdate()
    {
        _horizontalDirection = Input.GetAxis("Horizontal");
    }

    private void Update()
    {
        HorizontalDirChanged?.Invoke(_horizontalDirection);

        if (Input.GetButtonDown("Next character"))
        {
            NextCharButtonPressed?.Invoke();
        }
    }

    #endregion
}
