using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wall : MonoBehaviour {

    private int score;
    public TextMeshProUGUI scoreText;
    [SerializeField] GameObject explosion;
    void Start() {
        score = 0;
        scoreText.text = "" + score;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Instantiate(explosion, collision.transform.position, collision.transform.rotation);
        score++;
        scoreText.text = "" + score;
    }
}
