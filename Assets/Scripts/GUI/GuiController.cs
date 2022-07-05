using UnityEngine;
using TMPro;

public class GuiController : MonoBehaviour
{
    [SerializeField]
    private SceneController _sceneController;

    [SerializeField]
    private TMP_Text _text;


    #region Private methods

    private void OnLevelFinished()
    {
        _text.enabled = true;
    }

    #endregion



    #region Unity messages

    private void Awake()
    {
        _sceneController.LevelFinished += OnLevelFinished;
    }

    #endregion
}
