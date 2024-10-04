
using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundManagerScript : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase[] tiles;
    public int rows = 4;
    public int columns = 6;
    public float threshold = 10f;
    private int tileSize = 3;
    private Transform SpaceShip;
    // boundary values
    private float rightBoundary = 19;
    private float leftBoundary = -19;
    private float topBoundary = 13;
    private float bottomBoundary = -13;


    // Start is called before the first frame update
    void Start()
    {
        SpaceShip = GameObject.FindGameObjectWithTag("SpaceShip").transform;
        InitializeBackground();
    }

    // Update is called once per frame
    void Update()
    {
        CheckSpaceshipProximity();
    }

    void InitializeBackground() {
        for(int i = -rows; i < rows; ++i) {
            for(int j = -columns; j < columns; ++j) {
                
                Vector3Int tileposition = new(i * tileSize,j * tileSize, 0);
                TileBase randomTile = GetRandomBGTile();
                tilemap.SetTile(tileposition, randomTile);
            }
        }
    }

    TileBase GetRandomBGTile() {
        int randomIndex = UnityEngine.Random.Range(0, tiles.Length);
        return tiles[randomIndex];
    }

    void CalculateDistanceToBoundary(out float rightDistance, out float leftDistance, out float topDistance, out float bottomDistance) {
        
        rightDistance = Mathf.Abs(SpaceShip.position.x - rightBoundary);
        leftDistance = Mathf.Abs(SpaceShip.position.x - leftBoundary);
        topDistance = Mathf.Abs(SpaceShip.position.y - topBoundary);
        bottomDistance = Mathf.Abs(SpaceShip.position.y - bottomBoundary);
    }

    void CheckSpaceshipProximity() {
        CalculateDistanceToBoundary(out float rightDistance, out float leftDistance, out float topDistance, out float bottomDistance);
        if(rightDistance < threshold) {
            GenerateTile(Vector3.right);
        }
        if(leftDistance < threshold) {
            GenerateTile(Vector3.left);
        }
        if(topDistance < threshold) {
            GenerateTile(Vector3.up);
        }
        if(bottomDistance < threshold) {
            GenerateTile(Vector3.down);
        }
    }

    void GenerateTile(Vector3 direction) {
        if(direction == Vector3.right) {
            for(float i = bottomBoundary; i <= topBoundary; i+=tileSize) {
                Vector3Int tilepos = WorldToCell(new(rightBoundary+tileSize, i, 0));
                tilemap.SetTile(tilepos, GetRandomBGTile());
            }
            rightBoundary += tileSize;
        }
        else if(direction == Vector3.left) {
            for(float i = bottomBoundary; i <= topBoundary; i+=tileSize) {
                Vector3Int tilepos = WorldToCell(new(leftBoundary-tileSize, i, 0));
                tilemap.SetTile(tilepos, GetRandomBGTile());
            }
            leftBoundary -= tileSize;
        }
        else if(direction == Vector3.up) {
            for(float i = leftBoundary; i <= rightBoundary; i+=tileSize) {
                Vector3Int tilepos = WorldToCell(new(i, topBoundary+tileSize, 0));
                tilemap.SetTile(tilepos, GetRandomBGTile());
            }
            topBoundary += tileSize;
        }
        else {
            for(float i = leftBoundary; i <= rightBoundary; i+=tileSize) {
                Vector3Int tilepos = WorldToCell(new(i, bottomBoundary-tileSize,0));
                tilemap.SetTile(tilepos, GetRandomBGTile());
            }
            bottomBoundary -= tileSize;
        }
    }

    Vector3Int WorldToCell(Vector3 pos) {
        return tilemap.WorldToCell(pos);
    }
    
}
