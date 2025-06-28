using System;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;
    public event Action<GameObject> OnCubeHit;

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
            {
                GameObject objectHit = hit.transform.gameObject;
                if (objectHit.TryGetComponent<Cube>(out var i))
                {
                    Debug.Log(i);
                    OnCubeHit?.Invoke(objectHit);
                }
            }
        }
    }
}
