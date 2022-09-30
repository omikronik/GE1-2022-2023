using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Random = UnityEngine.Random;

public class CenterPoint : MonoBehaviour
{
    public GameObject rotatingCube;
    public float CenterOffset;
    public int RingCount;

    public List<GameObject> Amoguses = new List<GameObject>();

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
            GameObject go = Instantiate(rotatingCube, spawnPos, rotation);
            go.GetComponent<Renderer>().material.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1f, 1f);
            Amoguses.Add(go);
        }
    }

    public void RandomizeColor() {
        var randColor = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1f, 1f);

        foreach (var Amogus in Amoguses)
        {
            Amogus.GetComponent<Renderer>().material.color = randColor;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < RingCount+1; i++) {
            GenerateCubes(6 * i, CenterOffset * i);
        }
        
        InvokeRepeating("RandomizeColor", 0.5f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
