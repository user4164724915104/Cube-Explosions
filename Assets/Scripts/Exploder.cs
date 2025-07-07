using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForse;
    [SerializeField] private float _explosionRadius;

    public void Explode(List<Cube> objects, Vector3 position)
    {
        if (objects != null)
        {
            foreach (Cube rigidbody in objects)
            {
                rigidbody.Rigidbody.AddExplosionForce(_explosionForse, position, _explosionRadius);
            }
        }
    }
}
