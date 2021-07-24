using UnityEngine;
using UnityEngine.InputSystem;
public class ResultController : MonoBehaviour
{
    UiInput input = null;
    void Awake()
    {
        input = new UiInput();
    }
    void Start()
    {
        if (FlowController.Instance.Data is ResultData data)
        {
            Debug.Log($"Winner is : {data.Winner}");
        }
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
        FlowController.Instance.LoadScene(SceneIndex.Title, null);
    }
}