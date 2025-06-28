using System.Collections.Generic;
using UnityEngine;

public class Exploding : MonoBehaviour
{
    [SerializeField] private float _explosionForse;
    [SerializeField] private float _explosionRadius;

    public void Explode(List<Rigidbody> _newCubes, Vector3 position)
    {
        if (_newCubes != null)
        {
            foreach (Rigidbody rigidbody in _newCubes)
            {
                rigidbody.AddExplosionForce(_explosionForse, position, _explosionRadius);
            }
        }
    }
}
