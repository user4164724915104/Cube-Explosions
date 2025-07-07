using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent (typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [Range(0f, 100f)]
    [SerializeField] private float _chance;

    public float Chance { get => _chance; private set => _chance = value; }
    public Rigidbody Rigidbody { get; private set; }

    public void Initialize(float chance, Vector3 scale, Color color)
    {
        Rigidbody = GetComponent<Rigidbody>();
        _chance = chance;
        transform.localScale = scale;
        GetComponent<Renderer>().material.color = color;
    }
}
