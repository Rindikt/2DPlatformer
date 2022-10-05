using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrollView : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private Transform _leftEdge;

    [SerializeField]
    private Transform _rightEdge;

    [SerializeField]
    private float _speed;

    public Transform LeftEdge  => _leftEdge; 
    public Transform RightEdge => _rightEdge;

    public float Speed  => _speed;

    public SpriteRenderer SpriteRenderer { get => _spriteRenderer; set => _spriteRenderer = value; }
}
