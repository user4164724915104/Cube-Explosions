using UnityEngine;

public class CubeExplosionsMain : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private RandomChance _randomChance;
    [SerializeField] private Exploder _exploding;
    [SerializeField] private Raycast _raycast;
    private Vector3 _initialScale;
    private bool _isFirstClick = false;

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
        if (!_isFirstClick)
        {
            _initialScale = cube.transform.localScale;
            _isFirstClick = true;
        }

        Destroy(cube.gameObject);

        if (_randomChance.Random(cube.Chance))
        {
            _exploding.SpawnExplode(
                _spawner.SpawnCubes(
                    cube.transform.localScale,
                    cube.Chance,
                    cube.transform.position),
                cube.transform.position);
        }
        else
        {
            _exploding.DestroyExplode(cube, _initialScale);
        }
    }
}
