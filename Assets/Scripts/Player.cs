using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    GameManager gameManager;
    public GameObject deathPart;
    public GameObject itemPickupPart;

    float angle = 0;
    int playerXSpeed = 3;
    int playerYSpeed = 20;
    bool IsDead = false;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void FixedUpdate() {
        if(IsDead) return;
        PlayerMove();
        GetInput();
    }

    void PlayerMove() {
        Vector2 pos = transform.position;
        pos.x = Mathf.Cos(angle) * 4;
        transform.position = pos;
        angle += Time.deltaTime * playerXSpeed;
    }

    void GetInput() {
        if (Input.GetMouseButton(0)) {
            rb.AddForce(new Vector2(0, playerYSpeed));
        }
        else {
            if (rb.velocity.y > 0) {
                rb.AddForce(new Vector2(0, -playerYSpeed / 2));
            }
            else {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Obstacle") {
            PlayerDeath();
        } else if(other.gameObject.tag == "CollectableItem") {
            Debug.Log("You picked Collectable Item!");
            Destroy(Instantiate(itemPickupPart, other.gameObject.transform.position, Quaternion.identity), 1f);
            Destroy(other.gameObject.transform.parent.gameObject);
            gameManager.AddPoints();
        }
    }

    void PlayerDeath() {
        Destroy(Instantiate(deathPart, this.transform.position, Quaternion.identity), 1f);
        IsDead = true;
        rb.isKinematic = true;
        rb.velocity = new Vector2(0 , 0);
        gameManager.PlayerDead();
    }
}