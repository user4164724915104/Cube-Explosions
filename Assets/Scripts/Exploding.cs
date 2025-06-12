using System.Collections.Generic;
using UnityEngine;

public class Exploding : MonoBehaviour
{
    [Range(0f, 100f)]
    [SerializeField] private float _chance;
    [SerializeField] private float _explosionForse = 999;
    [SerializeField] private float _explosionRadius = 10;
    private List<Rigidbody> _cubes = new();
    private static RandomChance _random = new RandomChance();
    
    private void OnMouseDown()
    {
        Exploding._random.chance = _chance;
        Destroy(gameObject);
        int random = UnityEngine.Random.Range(2, 6);

        if (Exploding._random.Random())
        {
            for (int i = 0; i < random; i++)
            {
                CreateNewCube();
            } 
        }

        Explode();
    }

    private void CreateNewCube()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = gameObject.transform.localScale / 2;
        cube.transform.localPosition = gameObject.transform.localPosition;
        cube.transform.localRotation = UnityEngine.Random.rotation;
        cube.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
        cube.AddComponent<Rigidbody>();
        cube.AddComponent<Exploding>();
        cube.GetComponent<Exploding>()._chance = _chance / 2;
        _cubes.Add(cube.GetComponent<Rigidbody>());
    }

    private void Explode()
    {
        foreach (Rigidbody rigidbody in _cubes)
            rigidbody.AddExplosionForce(_explosionForse, transform.position, _explosionRadius);
    }
}