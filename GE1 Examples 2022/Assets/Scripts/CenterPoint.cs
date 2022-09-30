using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CenterPoint : MonoBehaviour
{
    public GameObject rotatingCube;
    public float CenterOffset;
    public int RingCount;

    public void GenerateCubes(int numOfObjects, float centerOffset)
    {
        for (int i = 0; i < numOfObjects; i++)
        {
            var rad = i * 2 * MathF.PI / numOfObjects;
            var x = MathF.Sin(rad) * centerOffset;
            var z = MathF.Cos(rad) * centerOffset;

            Vector3 spawnPos = transform.position + new Vector3(x, 0, z);

            float angle = -rad*Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(-90, angle, 0);
            Instantiate(rotatingCube, spawnPos, rotation);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < RingCount+1; i++)
        GenerateCubes(6 * i, CenterOffset * i);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
