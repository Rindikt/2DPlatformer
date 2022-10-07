using UnityEngine;
using UnityEngine.Tilemaps;


public class GeneratorLevelController
{
    private const int CountWall = 4;

    private Tilemap _tileMapGround;
    private Tile _tileGround;
    private int _wightMap;
    private int _hightMap;
    private int _factorSmooth;
    private int _randomFillPercent;

    private int[,] _map;

    public GeneratorLevelController(GenerationView view)
    {
        _tileMapGround = view.TileMapGround;
        _tileGround = view.TileGround;
        _wightMap = view.WightMap;
        _hightMap = view.HeightMap;
        _factorSmooth = view.FactorSmooth;
        _randomFillPercent = view.RandomFillPercent;

        _map = new int[_wightMap, _hightMap];
    }

    public void Awake()
    {
        GenerationLevel();
    }

    private void GenerationLevel()
    {
        RandomFillLevel();

        for (int i = 0; i < _factorSmooth; i++)
            SmoothMap();

        DrawTilesMap();
    }


    private void RandomFillLevel()
    {
        var seed = Time.time.ToString();
        var psevdoRandom = new System.Random(seed.GetHashCode());

        for (int x = 0; x < _wightMap; x++)
        {
            for (int y = 0; y < _hightMap; y++)
            {
                if (x == 0 || x == _wightMap - 1 || y == 0 || y == _hightMap - 1)
                    _map[x, y] = 1;

                else
                    _map[x, y] = (psevdoRandom.Next(0, 100) < _randomFillPercent ? 1 : 0);
            }
        }
    }
    private void SmoothMap()
    {
        for (int x = 0; x < _wightMap; x++)
        {
            for (int y = 0; y < _hightMap; y++)
            {
                var neighbourWallTiles = GetNeighbourWall(x,y);

                if (neighbourWallTiles > CountWall)
                    _map[x, y] = 1;
                else if (neighbourWallTiles < CountWall)
                    _map[x, y] = 0;
            }

        }
    }

    private int GetNeighbourWall(int x, int y)
    {
        var wallCount = 0;

        for (int neighbourX = x-1; neighbourX < x+1; neighbourX++)
        {
            for (int neighbourY = y-1; neighbourY < y+1; neighbourY++)
            {
                if (neighbourX >= 0 && neighbourX < _wightMap && neighbourY >= 0 && neighbourY < _hightMap)
                {
                    if (neighbourX!=x||neighbourY!=y)
                    {
                        wallCount += _map[neighbourX, neighbourY];
                    }
                }
                else
                    wallCount++;
            }
        }
        return wallCount;
    }
    private void DrawTilesMap()
    {
        if (_map == null)
            return;

        for (var x = 0; x < _wightMap; x++)
        {
            for (var y = 0; y < _hightMap; y++)
            {
                var positionTitle = new Vector3Int(-_wightMap /2+x, -_hightMap / 2 + y, 0);
                if (_map[x,y]==1)
                {
                    _tileMapGround.SetTile(positionTitle, _tileGround);
                }
            }

        }
    }
}
