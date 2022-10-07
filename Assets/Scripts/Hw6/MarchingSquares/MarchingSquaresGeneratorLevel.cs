using UnityEngine.Tilemaps;
using UnityEngine;

public class MarchingSquaresGeneratorLevel 
{
    private SquareGrid _squareGrid;
    private Tilemap _tileMapGround;
    private Tile _tileGround;

    public void GenerationGrid(int[,] map, float squareSize)
    {
        _squareGrid = new SquareGrid(map, squareSize);
    }

    public void DrawTilesOnMap(Tilemap tileMapGround, Tile tileGround)
    {
        if (_squareGrid == null)
            return;

        _tileMapGround = tileMapGround;
        _tileGround = tileGround;
        for (int x = 0; x < ; x++)
        {

        }
    }
}
