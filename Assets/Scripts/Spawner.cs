using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _CubePrefab;

    public List<Rigidbody> SpawnCubes(bool isValid, Vector3 scale, float chance, Vector3 position)
    {
        if (isValid)
        {
            List<Rigidbody> _cubes = new();
            int random = Random.Range(2, 6);

            for (int i = 0; i < random; i++)
            {
                GameObject newCube = Instantiate(_CubePrefab);
                newCube.GetComponentInChildren<Cube>().chance = chance / 2;
                newCube.GetComponentInChildren<Rigidbody>().transform.localScale = scale / 2;
                newCube.GetComponentInChildren<Transform>().localPosition = position;
                newCube.GetComponentInChildren<Renderer>().material.color = Random.ColorHSV();
                _cubes.Add(newCube.GetComponent<Rigidbody>());
            }

            return _cubes;
        } else {
            return null;
        }
    }
}
