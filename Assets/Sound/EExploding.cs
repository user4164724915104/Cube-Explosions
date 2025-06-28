using System.Collections.Generic;
using UnityEngine;

public class EExploding : MonoBehaviour
{
    [Range(0f, 100f)]
    [SerializeField] private float _chance;
    [SerializeField] private float _explosionForse = 999;
    [SerializeField] private float _explosionRadius = 10;
    [SerializeField] private Cube _CubePrefab;
    private List<Rigidbody> _cubes = new();
    private RandomChance _random = new RandomChance();
    
    //private void OnMouseDown()
    //{
    //    Destroy(gameObject);
    //    int random = UnityEngine.Random.Range(2, 6);
    //    Debug.Log("e''''''''");
    //    if (_random.Random(_chance))
    //    {
    //        _CubePrefab.transform.localScale = gameObject.transform.localScale / 2;
    //        for (int i = 0; i < random; i++)
    //        {
    //            CreateNewCube();
    //        } 
    //    }

    //    Explode();
    //}

    private void CreateNewCube()
    {
        Instantiate(_CubePrefab);
        //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube.transform.localScale = gameObject.transform.localScale / 2;
        //cube.transform.localPosition = gameObject.transform.localPosition;
        //cube.transform.localRotation = UnityEngine.Random.rotation;
        //cube.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
        //cube.AddComponent<Rigidbody>();
        //cube.AddComponent<Exploding>()._chance = _chance / 2;
        //_cubes.Add(cube.GetComponent<Rigidbody>());
    }

    private void Explode()
    {
        foreach (Rigidbody rigidbody in _cubes)
            rigidbody.AddExplosionForce(_explosionForse, transform.position, _explosionRadius);
    }
}