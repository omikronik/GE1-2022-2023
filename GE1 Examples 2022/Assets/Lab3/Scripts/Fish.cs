using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float Frequency = 0.01f;
    public float HeadAmplitude = 20f;
    public float TailAmplitude = 20f;
    public float Theta = 0f;

    GameObject body, head, tail;
    // Start is called before the first frame update
    void Start()
    {
        body = GameObject.CreatePrimitive(PrimitiveType.Cube);
        body.transform.rotation = transform.rotation;
        body.transform.parent = this.transform;
        head = GameObject.CreatePrimitive(PrimitiveType.Cube);
        head.transform.position = transform.TransformPoint(new Vector3(1f, 0f, 0f));
        head.transform.rotation = transform.rotation;
        head.transform.parent = this.transform;
        tail = GameObject.CreatePrimitive(PrimitiveType.Cube);
        tail.transform.position = transform.TransformPoint(new Vector3(-1f, 0f, 0f));
        tail.transform.rotation = transform.rotation;
        tail.transform.parent = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        head.transform.localRotation = Quaternion.AngleAxis(HeadAmplitude * Mathf.Sin(Theta), Vector3.up);
        tail.transform.localRotation = Quaternion.AngleAxis(TailAmplitude * Mathf.Sin(Theta), Vector3.up);
        //transform.RotateAround(head.transform.position, Vector3.up, Quaternion.AngleAxis(HeadAmplitude * Mathf.Sin(Theta)));
        //transform.RotateAround(tail.transform.position, Vector3.up, Quaternion.AngleAxis(TailAmplitude * Mathf.Sin(Theta)));
        Theta += (Frequency / 100f);
    }
}
