using UnityEngine;
using System.Collections;

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

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 25; i++) {
            SpawnTile();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnTile() {
        int randomIndex = Random.Range(0, 2);
        currentTile = (GameObject)Instantiate(tilePrefabs[randomIndex], currentTile.transform.GetChild(0).transform.GetChild(randomIndex).transform.position, Quaternion.identity);
        
    }
}
