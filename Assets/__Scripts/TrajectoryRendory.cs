using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRendory : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject Point;
    public int numberOfPoints;

    [Header("Set Dynamically")]
    public GameObject[] Points;
    public Vector3 Pos;

    private void Start()
    {
        Points = new GameObject[numberOfPoints];
        Pos = Slingshot.S.launchPos;
        Pos.z = 10;
        for (int i = 0; i < numberOfPoints; i++)
            Points[i] = Instantiate(Point, Pos, Quaternion.identity);
    }

    Vector3 PointPosition(float t)
    {
        Vector3 currentPosition = (Pos + (Slingshot.S.force * t / 1.15f) + 0.5f * Physics.gravity * (t * t));
        return currentPosition;
    }

    private void Update()
    {
        for (int i = 0; i < Points.Length; i++)
            Points[i].transform.position = PointPosition(i * 0.1f);
    }
}