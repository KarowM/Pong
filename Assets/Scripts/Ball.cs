using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private float speed = 30;
    void Start() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "WallLeft" || collision.gameObject.name == "WallRight") {
            gameObject.transform.position = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }

        if (collision.gameObject.name == "RacketLeft") {
            float y = hitFactor(transform.position,
                                collision.transform.position,
                                collision.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (collision.gameObject.name == "RacketRight") {
            float y = hitFactor(transform.position,
                                collision.transform.position,
                                collision.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight) {
        return (ballPos.y - racketPos.y) / racketHeight;
    }
}
