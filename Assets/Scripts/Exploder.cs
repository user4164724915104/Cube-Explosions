using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForse;
    [SerializeField] private float _explosionRadius;

    public void Explode(List<Rigidbody> newCubes, Vector3 position)
    {
        if (newCubes != null)
        {
            foreach (Rigidbody rigidbody in newCubes)
            {
                rigidbody.AddExplosionForce(_explosionForse, position, _explosionRadius);
            }
        }
    }
}
