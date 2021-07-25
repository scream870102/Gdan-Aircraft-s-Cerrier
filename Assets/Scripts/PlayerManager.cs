using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;
using UnityEngine.UI;
using Scream.UniMO;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]Player player1;
    [SerializeField]Player player2;
    public Text Player1PairText;
    public Text Player2PairText;

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

        Player1PairText.enabled = true;
        Player2PairText.enabled = true;
        Player1PairText.text = "Press Any Key";
        Player2PairText.text = "Press Any Key";
    }

    void OnUnpairedDeviceUsed (InputControl c, InputEventPtr e) {
        if (!(c.device.GetType ( ) == Keyboard.current.GetType ( ) || c.device.GetType ( ) == Gamepad.current.GetType ( )))
            return;
        if (!player1.InputUser.valid) {
            player1.InputUser = InputUser.PerformPairingWithDevice (c.device);
            player1.InputUser.AssociateActionsWithUser (player1.PlayerInput);
            // player1.ActivePlayer = true;
            Debug.Log ("Pairing player1 with " + c.device.name);
            Player1PairText.enabled = false;
        }
        else if (!player2.InputUser.valid) {
            player2.InputUser = InputUser.PerformPairingWithDevice (c.device);
            player2.InputUser.AssociateActionsWithUser (player2.PlayerInput);
            // player2.ActivePlayer = true;
            Debug.Log ("Pairing player2 with " + c.device.name);
            Player2PairText.enabled = false;
        }
        if(player1.InputUser.valid && player2.InputUser.valid)
        {
            DomainEvents.Raise<OnPairComplete>(null);
        }
    }
}
