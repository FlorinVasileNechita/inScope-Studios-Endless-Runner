using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    [SerializeField]
    private float speed;
    private Vector3 direction;

    public ParticleSystem getPickup;

    private bool isDead;
    public GameObject resetButton;

    void Start() {
        direction = Vector3.zero;
        isDead = false;
    }

    void Update() {
        // Handle mouse input
        if (Input.GetMouseButtonDown(0) && !isDead) {
            if (direction == Vector3.forward) {
                direction = Vector3.left;
            }
            else {
                direction = Vector3.forward;
            }
        }

        // Move the player
        float amountToMove = speed * Time.deltaTime;
        transform.Translate(direction * amountToMove);
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Pickup") {
            other.gameObject.SetActive(false);
            Instantiate(getPickup, transform.position, Quaternion.identity);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Tile") {
            RaycastHit hit;
            Ray downRay = new Ray(transform.position, -Vector3.up);

            if (!Physics.Raycast(downRay, out hit)) {
                isDead = true;
                if (transform.childCount > 0) {
                    transform.GetChild(0).transform.parent = null;
                }
                resetButton.SetActive(true);
            }
        }
    }
}
