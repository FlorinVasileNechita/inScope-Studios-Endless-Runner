using UnityEngine;
using System.Collections;

public class TileManager : MonoBehaviour {
    [SerializeField]
    private GameObject leftTilePrefab;
    [SerializeField]
    private GameObject topTilePrefab;
    public GameObject currentTile;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 10; i++) {
            SpawnTile();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnTile() {
        currentTile = (GameObject)Instantiate(leftTilePrefab, currentTile.transform.GetChild(0).transform.GetChild(0).transform.position, Quaternion.identity);
        
    }
}
