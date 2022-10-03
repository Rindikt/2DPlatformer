using System;
using UnityEngine;


public class InputButtonE : IExecute
{
    public event Action OnButtonClick;

    public void Execute()
    {
        CheckPressButtonE();
    }

    private void CheckPressButtonE()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnButtonClick?.Invoke();
        }
    }
}

