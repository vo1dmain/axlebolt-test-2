using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Door : MonoBehaviour
{
    [SerializeField]
    private bool _isOpen = false;



    public bool IsOpen => _isOpen;



    public void Open()
    {
        if (_isOpen) return;

        gameObject.SetActive(false);
        _isOpen = true;
    }

    public void Close()
    {
        if (!_isOpen) return;

        gameObject.SetActive(true);
        _isOpen = false;
    }


}
