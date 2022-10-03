using System;
using UnityEngine;
internal class ControllerLifts : IFixedUpdate
{
    private LiftView _viewLift;
    private SliderJoint2D _sliderJoint;
    private float _speedLift;

    public ControllerLifts(LiftView viewLift)
    {
        _viewLift = viewLift;
        _sliderJoint = _viewLift.Anchor.GetComponent<SliderJoint2D>();
        _viewLift.OnCollisionEnter += CheckCollision;
    }

    public void FixedUpdate()
    {
        MoveLift();
    }

    private void MoveLift()
    {
        JointMotor2D motor = _sliderJoint.motor;
        motor.motorSpeed = _speedLift;
        _sliderJoint.motor = motor;
    }

    private void CheckCollision(Collision2D collision)
    {
        if (collision.collider.GetComponent<LiftDownView>())
        {
            _speedLift = -0.5f;
        }
        else if (collision.collider.GetComponent<LiftTopView>())
        {
            _speedLift = 0.5f;
        }
    }
}
