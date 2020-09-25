using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private float speed = 30;
    void Start() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Left Racket") {
            float y = hitFactor(transform.position,
                                collision.transform.position,
                                collision.collider.bounds.size.y);
            Debug.Log("New Y is : " + y);

            Vector2 dir = new Vector2(1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        // Hit the right Racket?
        if (collision.gameObject.name == "Right Racket") {
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
