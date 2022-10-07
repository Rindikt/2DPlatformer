using UnityEngine;
using UnityEngine.Tilemaps;

public class SqureGrid
{
    public Square[,] Squares;

    public SqureGrid(Square[,] map, float squareSize)
    {
        var nodeCountX = map.GetLength(0);
        var nodeCountY = map.GetLength(1);
        var mapWidth = nodeCountX * squareSize;
        var mapHeight = nodeCountY * squareSize;

        var controlNodes = new ControlNode[nodeCountX, nodeCountY];

        for (int x = 0; x < nodeCountX; x++)
        {
            for (int y = 0; y < nodeCountY; y++)
            {
                var position = new Vector3(-mapWidth / 2 + x * squareSize + squareSize / 2, -mapHeight / 2 + y * squareSize + squareSize / 2);
                //controlNodes[x, y] = new ControlNode(position, map[x, y] == 1)); не понимаю по чему тут он не хочет работаеть..
            }
        }

        var squares = new Square[nodeCountX-1, nodeCountY-1];
        for (int x = 0; x < nodeCountX - 1; x++)
        {
            for (int y = 0; y < nodeCountY - 1; y++)
            {
                squares[x, y] = new Square(controlNodes[x, y + 1], controlNodes[x + 1, y + 1], controlNodes[x + 1, y], controlNodes[x, y]);
            }
        }
    }
}
