using UnityEngine;

public class CubeExplosionsMain : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private RandomChance _randomChance;
    [SerializeField] private Exploder _exploding;
    [SerializeField] private Raycast _raycast;

    private void OnEnable()
    {
        _raycast.OnCubeHit += InitializationExplode;
    }

    private void OnDisable()
    {
        _raycast.OnCubeHit -= InitializationExplode;
    }

    private void InitializationExplode(GameObject cube)
    {
        if (_randomChance.Random(cube.GetComponent<Cube>().Chance))
        {
            _exploding.Explode(
                _spawner.SpawnCubes(
                    cube.transform.localScale,
                    cube.GetComponent<Cube>().Chance,
                    cube.transform.position),
                cube.transform.position);
        }
        Destroy(cube);
    }
}
