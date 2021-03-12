using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    static List<Transform> cubes;
    public static void PlaceCube(Vector3 posn, Color color, Transform cube)
    {
        posn.y += 0.5f;
        Transform newCube = GameObject.Instantiate(cube, posn, Quaternion.identity);
        newCube.GetComponentInChildren<MeshRenderer>().material.color = color;
        if (cubes == null)
        {
            cubes = new List<Transform>();
        }
        cubes.Add(newCube);

    }

    public static void RemoveCube(Vector3 posn, Color color)
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            if(cubes[i].position== posn && cubes[i].GetComponentInChildren<MeshRenderer>().material.color == color)
            {
                GameObject.Destroy(cubes[i].gameObject);
                cubes.RemoveAt(i);
                break;
            }
        }
    }
}
