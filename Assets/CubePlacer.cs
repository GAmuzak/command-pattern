    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    public static void PlaceCube(Vector3 posn, Color color, Transform cube)
    {
        posn.y += 0.5f;
        Transform newCube = GameObject.Instantiate(cube, posn, Quaternion.identity);
        newCube.GetComponentInChildren<MeshRenderer>().material.color = color;
    }
}
