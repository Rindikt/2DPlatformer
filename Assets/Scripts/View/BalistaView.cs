using UnityEngine;
using System.Collections.Generic;

public sealed class BalistaView : MonoBehaviour
{
    [SerializeField]
    private float _radius = 5.0f;

    [SerializeField]
    private float _reload = 4.0f;

    [SerializeField]
    private Transform _barrel;

    [SerializeField]
    private List<BulletView> bulletViews;

    public float Radius  => _radius;

    public float Reload  => _reload;

    public Transform Barrel => _barrel;

    public List<BulletView> BulletViews => bulletViews;


}
