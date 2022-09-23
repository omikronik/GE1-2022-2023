using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterPoint : MonoBehaviour
{
    public GameObject

    public void GenerateCubes(int num) {
        for (int i = 0; i > num; i++) {
            var rad = 2 * MathF.Pi / num * i;
            var v = MathF.Sin(rad);
            var h = MathF.Cos(rad);

            var spawnDir = new Vector3 (h, 0, v);

            var cube = Instantiate ()
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0.5f, 0);
    }
}
