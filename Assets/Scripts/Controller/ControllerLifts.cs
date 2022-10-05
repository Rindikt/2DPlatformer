using UnityEngine;

internal sealed class ControllerLifts : IFixedUpdate
{
    private LiftView _viewLift;
    private SliderJoint2D _sliderJoint;
    private float _speedLift;
    private const float SpeedUp = 0.5f;
    private const float SpeedDown = -0.5f;

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
            _speedLift = SpeedDown;
        }
        else if (collision.collider.GetComponent<LiftTopView>())
        {
            _speedLift = SpeedUp;
        }
    }
}
