using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForse;
    [SerializeField] private float _explosionRadius;

    public void SpawnExplode(List<Cube> objects, Vector3 position)
    {
        if (objects != null)
        {
            foreach (Cube rigidbody in objects)
            {
                rigidbody.Rigidbody.AddExplosionForce(_explosionForse, position, _explosionRadius);
            }
        }
    }

    public void DestroyExplode(Cube cube, Vector3 initialScale)
    {
        Vector3 position = cube.transform.position;
        Vector3 scale = cube.transform.localScale;

        foreach (Cube ExplodableCube in GetExplodableCubes(position))
        {
            float distance = Vector3.Distance(ExplodableCube.transform.position, position);

            if (distance != 0)
            {
                ExplodableCube.Rigidbody.AddExplosionForce((_explosionForse * (initialScale.x - scale.x) / distance), position, _explosionRadius * (initialScale.x - scale.x)); 
            }
        }
    }

    private List<Cube> GetExplodableCubes(Vector3 position)
    {
        Collider[] hits = Physics.OverlapSphere(position, _explosionRadius);
        List<Cube> ExplodableCubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.gameObject != null && hit.gameObject.TryGetComponent<Cube>(out var cube))
            {
                ExplodableCubes.Add(hit.transform.gameObject.GetComponent<Cube>());
            }
        }

        return ExplodableCubes;
    }
}
