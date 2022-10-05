using UnityEngine;
using Pathfinding;

public class EnemyView : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private AIDestinationSetter _destinationSetter;

    [SerializeField]
    private Rigidbody2D _rigidbody2D;

    [SerializeField]
    private float demage;

    [SerializeField]
    private Transform[] _wayPoint;

    [SerializeField]
    private AIPath _aIPath;

    [SerializeField]
    private float _maxVisibility;

    public Transform[] WayPoint => _wayPoint;

    
    public AIDestinationSetter DestinationSetter { get => _destinationSetter; set => _destinationSetter = value; }
    public SpriteRenderer SpriteRenderer { get => _spriteRenderer; set => _spriteRenderer = value; }
    public float Demage => demage;

    public AIPath AIPath  => _aIPath;

    public float MaxVisibility  => _maxVisibility;

    public Rigidbody2D Rigidbody2D { get => _rigidbody2D; set => _rigidbody2D = value; }
}
  