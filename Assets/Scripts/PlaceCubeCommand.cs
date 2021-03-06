using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCubeCommand : ICommand
{
    Vector3 posn;
    Color color;
    Transform cube;

    public PlaceCubeCommand(Vector3 posn, Color color, Transform cube)
    {
        this.posn = posn;
        this.color = color;
        this.cube = cube;
    }
    public void Execute()
    {
        CubePlacer.PlaceCube(posn, color, cube);
        //throw new System.NotImplementedException();
    }

    public void Undo()
    {
        CubePlacer.RemoveCube(posn, color);
    }
}
