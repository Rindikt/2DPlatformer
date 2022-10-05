using UnityEngine;

internal class EnemyTrollController
{
    //private int _currentPointIndex;
    //private EnemyView _view;
    //private Transform _charector;
    //private SpriteAnimation _spriteAnimation;
    //private Transform _target;
    //private float _minDistanceToTarget =1f;
    //private float _speed;
    //private float _runSpeed = 3;
    //private float _walkSpeed = 1;
    //private float _zonaAttack = 1;
    //private float _zonaVisibility = 4;


    //public EnemyTrollController (EnemyView view, Transform charector, SpriteAnimation spriteAnimation)
    //{
    //    _view = view;
    //    _charector = charector;
    //    _spriteAnimation = spriteAnimation;
    //    _target = GetNextWaypoint();
    //}

    //public void FixedUpdate()
    //{
    //    _view.Rigidbody2D.velocity = CalculateVelocity(_view.transform.position);
    //}

    //public Vector2 CalculateVelocity(Vector2 fromPosition)
    //{
    //    var distanceToCharector = Vector2.Distance((Vector2)_charector.position, fromPosition);
    //    var distance = Vector2.Distance(fromPosition, _target.position);
    //    if (distanceToCharector <= _zonaVisibility)
    //    {
    //        if (distanceToCharector <= _zonaAttack)
    //        {
    //            Attack();
    //        }
    //        else
    //        {
    //             Run();
    //            _target = _charector;
    //        }
    //    }
    //    else 
    //    {
    //        Walk();
    //        if (_charector == _target)
    //        {
    //            _target = GetNextWaypoint();
    //        }
    //        else if (distance <= _minDistanceToTarget)
    //        {
    //            _target = GetNextWaypoint();
    //        }
    //    }

    //    var direction = ((Vector2)_target.position - fromPosition).normalized;

    //    return direction * _speed;

    //}


    //private Transform GetNextWaypoint()
    //{
    //    _currentPointIndex = (_currentPointIndex + 1) % _view.WayPoint.Length;
    //    return _view.WayPoint[_currentPointIndex];
    //}

    //private void Walk()
    //{
    //    _speed = _walkSpeed;
    //    _spriteAnimation.StartAnimation(_view.SpriteRenderer, Track.trollSummerWalk, true, 5.0f);
    //}
    //private void Run()
    //{
    //    _speed = _runSpeed;
    //    _spriteAnimation.StartAnimation(_view.SpriteRenderer, Track.trollSummerRun, true, 2.0f);
    //}

    //private void Attack()
    //{
    //    _spriteAnimation.StartAnimation(_view.SpriteRenderer, Track.trollSummerAttack, true, 3.0f);
    //}

}
