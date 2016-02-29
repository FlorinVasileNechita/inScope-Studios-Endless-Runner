using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {
    private float tileFallDelay = 0.7f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            TileManager.Instance.SpawnTile();
            StartCoroutine(DropTile());
        }
    }

    IEnumerator DropTile() {
        yield return new WaitForSeconds(tileFallDelay);
        GetComponent<Rigidbody>().isKinematic = false;

        yield return new WaitForSeconds(2);
        switch (gameObject.name) {
            case "LeftTile":
                TileManager.Instance.LeftTiles.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;

            case "TopTile":
                TileManager.Instance.TopTiles.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;
        }
    }
}
