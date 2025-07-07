using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    private readonly int _half = 2;

    public List<Cube> SpawnCubes(Vector3 scale, float chance, Vector3 position)
    {
        List<Cube> cubes = new();
        int random = Random.Range(2, 6);

        for (int i = 0; i < random; i++)
        {
            Cube newCube = Instantiate(_cubePrefab, position, Random.rotation);
            newCube.Initialize(chance / _half, scale / _half, Random.ColorHSV());
            cubes.Add(newCube);
        }

        return cubes;
    }
}