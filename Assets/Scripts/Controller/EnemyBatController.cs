using Pathfinding;
using UnityEngine;

public class EnemyBatController : IFixedUpdate
{
    private int _currentPointIndex;
    private EnemyView _view;
    private AIDestinationSetter _destinationSetter;
    private Transform _charector;
    private SpriteAnimation _spriteAnimation;

    public EnemyBatController(EnemyView view,Transform charector, SpriteAnimation spriteAnimation)
    {
        _charector = charector;
        _spriteAnimation = spriteAnimation;
        _view = view;
        _destinationSetter = _view.DestinationSetter;
        _destinationSetter.target = GetNextWaypoint();
    }

    public void FixedUpdate()
    {
        _destinationSetter.target = CalculateVelocity((Vector2)_view.transform.position);
    }

    public Transform CalculateVelocity(Vector2 fromPosition)
    {
        var distance = Vector2.Distance((Vector2)_destinationSetter.target.position, fromPosition);
        var distanceToCharector = Vector2.Distance((Vector2)_charector.position, fromPosition);

       
        if (distanceToCharector<= _view.MaxVisibility)
        {
            if (distanceToCharector<= _view.AIPath.pickNextWaypointDist)
            {
                Attack();
            }
            return _charector;
        }
        else
        {
            Fly();
            if (_charector == _destinationSetter.target)
            {
                return GetNextWaypoint();
            }
            else if (distance <= _view.AIPath.pickNextWaypointDist)
            {
                return GetNextWaypoint();
            }
            return _destinationSetter.target;
        }
    }


    private Transform GetNextWaypoint()
    {
        _currentPointIndex = (_currentPointIndex + 1) % _view.WayPoint.Length;
        return _view.WayPoint[_currentPointIndex];
    }

    private void Fly()
    {
        _spriteAnimation.StartAnimation(_view.SpriteRenderer, Track.batFly, true, 5.0f);
    }

    private void Attack()
    {
        _spriteAnimation.StartAnimation(_view.SpriteRenderer, Track.batAttack, true, 5.0f);
    }
}
