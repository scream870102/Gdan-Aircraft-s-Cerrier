using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class ResultController : MonoBehaviour
{
    UiInput input = null;
    [SerializeField] Text winnerText = null;
    void Awake()
    {
        input = new UiInput();
    }
    void Start()
    {
        if (FlowController.Instance.Data is ResultData data)
        {
            winnerText.text = $"{data.Winner}\nWin";
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