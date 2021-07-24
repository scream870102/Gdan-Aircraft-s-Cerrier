using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IControllable
{
    bool IsUnderControll{get;set;}
    void EnableControll(bool isUnderControlled,PlayerInput inputActions);

}
