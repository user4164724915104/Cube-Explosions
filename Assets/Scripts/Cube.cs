using UnityEngine;

public class Cube : MonoBehaviour
{
    [Range(0f, 100f)]
    [SerializeField] private float _chance;

    public float Chance { get => _chance; set => _chance = value; }
}
