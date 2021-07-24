using UnityEngine;
using UnityEngine.InputSystem;

public class StartController : MonoBehaviour
{
    UiInput input = null;
    void Awake()
    {
        input = new UiInput();
    }

    void OnEnable()
    {
        input.UI.Enable();
        input.UI.Confirm.performed += HandleConfirmPerformed;
    }

    void OnDisable()
    {
        input.UI.Confirm.performed -= HandleConfirmPerformed;
    }


    void HandleConfirmPerformed(InputAction.CallbackContext ctx)
    {
        FlowController.Instance.LoadScene(SceneIndex.Game, null);
    }
}