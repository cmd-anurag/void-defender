using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundManagerScript : MonoBehaviour
{

    // REFERENCES
    private Transform SpaceShip;
    public Tilemap tilemap;
    public TileBase[] tiles;
    public TileBase[] rareTiles;


    // SIZE AND SHAPE
    public int rows = 4;
    public int columns = 6;
    private int tileSize = 3;


    // Boundary values
    private float rightBoundary = 18;
    private float leftBoundary = -18;
    private float topBoundary = 12;
    private float bottomBoundary = -12;


    // Constants
    public float threshold = 10f;
    private const int rareTileChance = 20;
    private const int rareTileOffset = 1;


    void Start()
    {
        SpaceShip = GameObject.FindGameObjectWithTag("SpaceShip").transform;
        InitializeBackground();
        InvokeRepeating(nameof(CheckSpaceshipProximity), 0f, 0.5f);
    }

    void InitializeBackground()
    {
        for (int i = -rows; i < rows; ++i)
        {
            for (int j = -columns; j < columns; ++j)
            {
                Vector3Int tilePosition = new(i * tileSize, j * tileSize, 0);
                PlaceTileWithChance(tilePosition);
            }
        }
    }

    
    void PlaceTileWithChance(Vector3Int tilePosition)
    {
        TileBase randomTile = GetRandomBGTile();
        tilemap.SetTile(tilePosition, randomTile);

        if (UnityEngine.Random.Range(0, rareTileChance) == 3)
        {
            Vector3Int rareTilePos = new(tilePosition.x + rareTileOffset, tilePosition.y + rareTileOffset, 0);
            tilemap.SetTile(rareTilePos, GetRandomRareTile());
        }
    }

    TileBase GetRandomBGTile()
    {
        int randomIndex = UnityEngine.Random.Range(0, tiles.Length);
        return tiles[randomIndex];
    }

    TileBase GetRandomRareTile()
    {
        int randomIndex = UnityEngine.Random.Range(0, rareTiles.Length);
        return rareTiles[randomIndex];
    }

    void CalculateDistanceToBoundary(out float rightDistance, out float leftDistance, out float topDistance, out float bottomDistance)
    {
        rightDistance = Mathf.Abs(SpaceShip.position.x - rightBoundary);
        leftDistance = Mathf.Abs(SpaceShip.position.x - leftBoundary);
        topDistance = Mathf.Abs(SpaceShip.position.y - topBoundary);
        bottomDistance = Mathf.Abs(SpaceShip.position.y - bottomBoundary);
    }

    void CheckSpaceshipProximity()
    {
        if(!SpaceShip) return;
        
        CalculateDistanceToBoundary(out float rightDistance, out float leftDistance, out float topDistance, out float bottomDistance);
        
        if (rightDistance < threshold)
            ExpandInDirection(Vector3.right, ref rightBoundary);
        
        if (leftDistance < threshold)
            ExpandInDirection(Vector3.left, ref leftBoundary);
        
        if (topDistance < threshold)
            ExpandInDirection(Vector3.up, ref topBoundary);
        
        if (bottomDistance < threshold)
            ExpandInDirection(Vector3.down, ref bottomBoundary);
    }

    
    void ExpandInDirection(Vector3 direction, ref float boundary)
    {
        if (direction == Vector3.right || direction == Vector3.left)
        {
            for (float i = bottomBoundary; i <= topBoundary; i += tileSize)
            {
                Vector3Int tilePosition = WorldToCell(new Vector3(boundary + direction.x * tileSize, i, 0));
                PlaceTileWithChance(tilePosition);
            }
        }
        else if (direction == Vector3.up || direction == Vector3.down)
        {
            for (float i = leftBoundary; i <= rightBoundary; i += tileSize)
            {
                Vector3Int tilePosition = WorldToCell(new Vector3(i, boundary + direction.y * tileSize, 0));
                PlaceTileWithChance(tilePosition);
            }
        }

        boundary += direction.x != 0 ? direction.x * tileSize : direction.y * tileSize;
    }

    Vector3Int WorldToCell(Vector3 position)
    {
        return tilemap.WorldToCell(position);
    }
}
