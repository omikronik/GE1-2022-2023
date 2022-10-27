using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AITank : MonoBehaviour {

    public float radius = 10;
    public int numWaypoints = 5;
    public int current = 0;
    public List<Vector3> waypoints;
    public float speed = 10;
    public Transform player;
    public Text playerBehind;
    public Text playerInFov;
    public Text info;

    void SetUpWayponts()
    {
        waypoints = new List<Vector3>();
        waypoints.Clear();
        float theta = (Mathf.PI * 2.0f) / (float) numWaypoints;

        for(int i = 0; i < numWaypoints; i++)
        {
            float angle = i * theta;
            Vector3 p = new Vector3(
                        Mathf.Sin(angle) * radius,
                        0,
                        Mathf.Cos(angle) * radius
                    );
            p = transform.TransformPoint(p);
            waypoints.Add(p);
        }
    }
    public void OnDrawGizmos()
    {
        // Task 1 Put code here to draw the gizmos
        // Use sin and cos to calculate the positions of the waypoints 
        // You can draw gizmos using
        // Gizmos.color = Color.green;
        // Gizmos.DrawWireSphere(pos, 1);
        SetUpWayponts();
        foreach(Vector3 waypoint in waypoints)
        {
            Gizmos.DrawWireSphere(waypoint, 1);
        }
    }

    // Use this for initialization
    void Awake () {

    }

    // Update is called once per frame
    void Update () {
        // Task 3
        // Put code here to move the tank towards the next waypoint
        // When the tank reaches a waypoint you should advance to the next one
        float dist = Vector3.Distance(transform.position, waypoints[current]);
        if (dist < 1.0f)
        {
            current = (current + 1) % waypoints.Count;
        }
        transform.LookAt(waypoints[current]);
        transform.Translate(0, 0, speed * Time.deltaTime);

        // Task 4
        // Put code here to check if the player is in front of or behine the tank
        Vector3 playerDirection = transform.position - player.position;
        float angleToPlayer = Vector3.Angle(transform.forward, playerDirection);

        if (Mathf.Abs(angleToPlayer) < 90)
        {
            playerBehind.text = "Player is behind";
        }
        else
        {
            playerBehind.text = "Player is in front";
        }

        if ((Mathf.Abs(angleToPlayer) > 157.5f) && (Mathf.Abs(angleToPlayer) < 202.5f) && (Vector3.Distance(transform.position, player.position) < 10)) {
            playerInFov.text = "Player is in Fov and range";
        }
        else
        {
            playerInFov.text = "Player is not in Fov or range";
        }

        info.text = Mathf.Abs(angleToPlayer).ToString();

        // Task 5
        // Put code here to calculate if the player is inside the field of view and in range
        // You can print stuff to the screen using:
    }
}
