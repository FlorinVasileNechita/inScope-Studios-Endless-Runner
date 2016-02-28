using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    [SerializeField]
    private float speed;
    private Vector3 direction;

    void Start() {
        direction = Vector3.zero;
    }

    void Update() {
        // Handle mouse input
        if (Input.GetMouseButtonDown(0)) {
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
}
