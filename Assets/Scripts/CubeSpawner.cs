using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public int tickDelay;

    private int delay = 0;

    private bool _discovered = false;

    private void Start()
    {
        _discovered = false;
    }

    private void OnEnable()
    {
        _discovered = true;
    }

    void FixedUpdate()
    {
        if (!_discovered) return;

        if (delay-- == 0)
        {
            SpawnCube();
            delay = tickDelay;
        }
    }

    private void SpawnCube()
    {
        var cube = Instantiate(cubePrefab, gameObject.transform.position, gameObject.transform.rotation);
        var rb = cube.GetComponent<Rigidbody>();
        rb.velocity = gameObject.transform.rotation * Vector3.forward;
    }
}
