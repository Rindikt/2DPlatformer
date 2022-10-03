using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float _demage;

    public float Demage  => _demage;
}
