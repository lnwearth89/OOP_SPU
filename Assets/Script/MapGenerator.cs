using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [Header("Set MapGenerator")]
    public int rows;
    public int cols;

    [Header("Set Player")]
    //public OOPPlayer player;
    public Vector2Int playerStartPos;

    [Header("Set Exit")]
    //public OOPExit Exit;

    [Header("Set Prefab")]
    public GameObject[] BlockPrefab;
    public GameObject[] wallsPrefab;
    public GameObject[] demonWallsPrefab;
    public GameObject[] itemsPrefab;
    public GameObject[] keysPrefab;
    public GameObject[] enemiesPrefab;
    public GameObject[] fireStormPrefab;

    [Header("Set Transform")]
    public Transform BlockParent;
    public Transform wallParent;
    public Transform itemParent;
    public Transform enemyParent;

    [Header("Set object Count")]
    public int obsatcleCount;
    public int itemPotionCount;
    public int itemKeyCount;
    public int itemFireStormCount;
    public int enemyCount;

    public string[,] mapdata;
    public Identity[,] ObjectInscene;
    //public OOPEnemy[,] EnemyInscene;


    // block types ...
    [Header("Block Types")]
    public string playerBlock = "Player";
    public string empty = string.Empty;
    public string demonWall = "DemonWall";
    public string potion = "Potion";
    public string bonuesPotion = "bonuesPotion";
    public string exit = "Exit";
    public string key = "Key";
    public string enemy = "Enemy";
    public string Skill = "Skill";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateMap();
    }

    private void CreateMap()
    {
        mapdata = new string[rows, cols];
        ObjectInscene = new Identity[rows, cols];
        //EnemyInscene = new OOPEnemy[rows, cols];
        for (int x = -1; x < rows + 1; x++)
        {
            for (int y = -1; y < cols + 1; y++)
            {
                if (x == -1 || x == rows || y == -1 || y == cols)
                {
                    int r = Random.Range(0, wallsPrefab.Length);
                    GameObject obj = Instantiate(wallsPrefab[r], new Vector3(x, 0, y), Quaternion.identity);
                    obj.transform.parent = wallParent;
                    obj.name = "Wall_" + x + ", " + y;
                }
                else
                {
                    int r = Random.Range(0, BlockPrefab.Length);
                    GameObject obj = Instantiate(BlockPrefab[r], new Vector3(x, 0, y), Quaternion.identity);
                    obj.transform.parent = BlockParent;
                    obj.name = "floor_" + x + ", " + y;
                }
            }
        }
    }
    public string GetMapData(int x, int y)
    {
        if (x >= rows || x < 0 || y >= cols || y < 0) return empty;
        return mapdata[x, y];
    }
}
