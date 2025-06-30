using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    public List<Rigidbody> SpawnCubes(bool isValid, Vector3 scale, float chance, Vector3 position)
    {
        if (isValid)
        {
            List<Rigidbody> cubes = new();
            int random = Random.Range(2, 6);

            for (int i = 0; i < random; i++)
            {
                GameObject newCube = Instantiate(_cubePrefab);

                if (newCube.TryGetComponent<Cube>(out var j))
                {
                    newCube.GetComponent<Cube>().Chance = chance / 2;
                }
                else
                {
                    return null;
                }

                newCube.GetComponent<Rigidbody>().transform.localScale = scale / 2;
                newCube.GetComponent<Transform>().localPosition = position;
                newCube.GetComponent<Renderer>().material.color = Random.ColorHSV();
                cubes.Add(newCube.GetComponent<Rigidbody>());
            }

            return cubes;
        } 
        else 
        {
            return null;
        }
    }
}
