using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;

    private Rigidbody2D body;
    private Text youDiedText;
    private bool dead = false;

    void Start() {
        this.body = this.GetComponent<Rigidbody2D>();
        this.youDiedText = GameObject.Find("YouDiedText").GetComponent<Text>();
        this.youDiedText.gameObject.SetActive(false);
    }

    void Update() {
        if (!dead) { // ez branch prediciton (more likely to be !dead than dead).
            this.body.MovePosition(this.transform.position + new Vector3(Input.GetAxis("MoveHorizontal"), Input.GetAxis("MoveVertical")) * Time.deltaTime * moveSpeed);
            this.transform.Rotate(new Vector3(0, 0, Input.GetAxis("RotateFlashlight") * -this.rotateSpeed));
        } else {
            if (Input.anyKeyDown) {
                // restart scene now.
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("LevelFinish")) {
            int nextIdx = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextIdx >= SceneManager.sceneCountInBuildSettings) { Debug.LogWarning("AT END! Got to an exit without a next level?!?"); return; }
            SceneManager.LoadScene(nextIdx, LoadSceneMode.Single);
        } else if (collision.CompareTag("Enemy")) {
            this.dead = true;
            this.youDiedText.gameObject.SetActive(true);
            this.GetComponent<Collider2D>().enabled = false;
            this.body.simulated = false; // i think this effectively disables it....??? there is no .enabled
        }
    }
}
