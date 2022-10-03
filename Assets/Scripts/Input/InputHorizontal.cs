using System;
using UnityEngine;


public sealed class InputHorizontal : IExecute
{
    public event Action<float> AxisOnChange = delegate (float f) { };

    public void Execute()
    {
        GetAxis();
    }

    private void GetAxis()
    {
        AxisOnChange.Invoke(Input.GetAxis(StringManager.AXIS_HORIZONTAL));
    }
}

