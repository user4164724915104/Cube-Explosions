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

    private void InitializationExplode(Cube cube)
    {
        if (_randomChance.Random(cube.Chance))
        {
            _exploding.Explode(
                _spawner.SpawnCubes(
                    cube.transform.localScale,
                    cube.Chance,
                    cube.transform.position),
                cube.transform.position);
        }
        Destroy(cube.gameObject);
    }
}
