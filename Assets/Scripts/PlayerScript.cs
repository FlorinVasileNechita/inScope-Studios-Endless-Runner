using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    [SerializeField]
    private float speed;
    private Vector3 direction;

    public ParticleSystem getPickup;

    private bool isDead;
    public GameObject resetButton;

    private int score;
    public Text scoreText;

    void Start() {
        direction = Vector3.zero;
        isDead = false;
        score = 0;
    }

    void Update() {
        // Handle mouse input
        if (Input.GetMouseButtonDown(0) && !isDead) {
            score++;
            scoreText.text = "Score: " + score;
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
            score += 3;
            scoreText.text = "Score: " + score;
            CombatTextManager.Instance.CreateText(other.transform.position, "+3", Color.green, false);
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
