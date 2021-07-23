using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]Player player1;
    [SerializeField]Player player2;

    void OnEnable()
    {
        InputUser.onUnpairedDeviceUsed += OnUnpairedDeviceUsed;
    }

    void OnDisable()
    {
        InputUser.onUnpairedDeviceUsed -= OnUnpairedDeviceUsed;
    }

    void Awake ( ) {
        ++InputUser.listenForUnpairedDeviceActivity;
    }

    void OnUnpairedDeviceUsed (InputControl c, InputEventPtr e) {
        if (!(c.device.GetType ( ) == Keyboard.current.GetType ( ) || c.device.GetType ( ) == Gamepad.current.GetType ( )))
            return;
        if (!player1.InputUser.valid) {
            player1.InputUser = InputUser.PerformPairingWithDevice (c.device);
            player1.InputUser.AssociateActionsWithUser (player1.PlayerInput);
            Debug.Log ("Pairing player1 with " + c.device.name);
        }
        else if (!player2.InputUser.valid) {
            player2.InputUser = InputUser.PerformPairingWithDevice (c.device);
            player2.InputUser.AssociateActionsWithUser (player2.PlayerInput);
            Debug.Log ("Pairing player2 with " + c.device.name);
        }
    }
}
