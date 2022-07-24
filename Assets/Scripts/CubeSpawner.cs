using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public int tickDelay;

    private int delay = 0;

    private void Start()
    {
        Debug.Log(name + ": I am alive and my prefab is " + cubePrefab);
    }

    void FixedUpdate()
    {
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
