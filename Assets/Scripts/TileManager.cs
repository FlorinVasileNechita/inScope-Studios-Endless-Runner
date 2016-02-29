using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileManager : MonoBehaviour {
    private static TileManager instance;
    public static TileManager Instance
    {
        get
        {
            if (!instance) {
                instance = GameObject.FindObjectOfType<TileManager>();
            }
            return instance;
        }
    }

    public GameObject currentTile;
    public GameObject[] tilePrefabs;

    private Stack<GameObject> leftTiles = new Stack<GameObject>();
    public Stack<GameObject> LeftTiles {
        get { return leftTiles; }
        set { leftTiles = value; }
    }
    private Stack<GameObject> topTiles = new Stack<GameObject>();
    public Stack<GameObject> TopTiles {
        get { return topTiles; }
        set { topTiles = value; }
    }

    // Use this for initialization
    void Start () {
        CreateTiles(20);

        for (int i = 0; i < 10; i++) {
            SpawnTile();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnTile() {
        // Make a bunch of tiles
        if (leftTiles.Count == 0 || topTiles.Count == 0) {
            CreateTiles(10);
        }

        // Get a random number between 0 and 1
        int randomIndex = Random.Range(0, 2);

        // Spawning a left tile
        if (randomIndex == 0) {
            GameObject temp = leftTiles.Pop();
            temp.SetActive(true);
            temp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            currentTile = temp;
        }
        else if (randomIndex == 1) {
            GameObject temp = topTiles.Pop();
            temp.SetActive(true);
            temp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            currentTile = temp;
        }
        
    }

    public void CreateTiles(int amount) {
        for (int i = 0; i < amount; i++) {
            leftTiles.Push(Instantiate(tilePrefabs[0]));
            topTiles.Push(Instantiate(tilePrefabs[1]));

            topTiles.Peek().name = "TopTile";
            leftTiles.Peek().name = "LeftTile";

            topTiles.Peek().SetActive(false);
            leftTiles.Peek().SetActive(false);

        }
    }
}
