using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public float scrollSpeed = 1f;
    float spriteSize;
    Vector2 startPos;

    void Start() {
        startPos = transform.position;
        spriteSize = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update() {
        float newPos = Mathf.Repeat (Time.time * scrollSpeed, spriteSize);
        transform.position = startPos + Vector2.right * newPos;
    }
}
