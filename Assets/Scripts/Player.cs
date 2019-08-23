using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    GameManager gameManager;
    public GameObject death_part;

    float angle = 0;
    int playerXSpeed = 3;
    int playerYSpeed = 20;
    bool IsDead = false;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Update() {
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
                rb.AddForce(new Vector2(0, -playerYSpeed));
            }
            else {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Obstacle") {
            Destroy(Instantiate(death_part, this.transform.position, Quaternion.identity), 1f);
            PlayerDead();
            gameManager.PlayerDead();
        } else if(other.gameObject.tag == "Item") {
            Debug.Log("You picked item!");
        }
    }

    void PlayerDead() {
        IsDead = true;
        rb.isKinematic = true;
        rb.velocity = new Vector2(0 , 0);
    }
}