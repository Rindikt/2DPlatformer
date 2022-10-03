using System;
using UnityEngine;

public sealed class InputJump : IExecute
{
    public event Action OnClickJump = delegate { };

    public void Execute()
    {
        OnPressetJump();
    }

    private void OnPressetJump()
    {
        if (Input.GetButtonDown(StringManager.BUTTON_JUMP))
        {
            OnClickJump?.Invoke();
        }
    }
}

