using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour {

    [Range(0f, 5f)] public float speed;

    public Transform left_check;
    public Transform right_check;
    public LayerMask platform;

    [SerializeField] private int direct = 1;
    private Rigidbody2D body;

    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {
        bool left_wall = Physics2D.OverlapCircle(left_check.position, 0.1f, platform);
        if (left_wall) { direct = 1; }

        bool right_wall = Physics2D.OverlapCircle(right_check.position, 0.1f, platform);
        if (right_wall) { direct = -1; }

        body.velocity = new Vector2(speed*direct,body.velocity.y);

    }
}
