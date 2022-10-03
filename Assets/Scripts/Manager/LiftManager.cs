using System;
using System.Collections.Generic;

internal class LiftManager : IFixedUpdate
{
    private List<ControllerLifts> _controllerLifts = new List<ControllerLifts>();

    public LiftManager(List<LiftView> controllerLifts)
    {
        foreach (var liftView in controllerLifts)
        {
            _controllerLifts.Add(new ControllerLifts(liftView));
        }
    }

    public void FixedUpdate()
    {
        foreach (var item in _controllerLifts)
        {
            item.FixedUpdate();
        }
    }
}
