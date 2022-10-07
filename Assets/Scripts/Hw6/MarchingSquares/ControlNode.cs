using System;
using UnityEngine;


public class ControlNode : Node
{
    public bool Active;

    public ControlNode(Vector3 pos, bool active):base(pos)
    {
        Active = active;
    }
}
