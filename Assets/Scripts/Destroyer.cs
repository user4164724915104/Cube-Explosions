using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private RandomChance _randomChance;
    [SerializeField] private Exploding _exploding;
    [SerializeField] private Raycast _raycast;

    private void OnEnable()
    {
        _raycast.OnCubeHit += DestroyCube;
    }
    private void OnDisable()
    {
        _raycast.OnCubeHit -= DestroyCube;
    }

    private void DestroyCube(GameObject cube)
    {
        _exploding.Explode(
            _spawner.SpawnCubes(
                _randomChance.Random(cube.GetComponent<Cube>().chance),
                cube.transform.localScale,
                cube.GetComponent<Cube>().chance,
                cube.transform.position),
            cube.transform.position);
        Destroy(cube);
    }
}
