using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    public float scrollSpeed = 1f;
    public float offset;
    Vector2 startPos;
    private float newXposition;

    void Start() {
        startPos = transform.position;
        offset = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update() {
        newXposition = Mathf.Repeat (Time.time * scrollSpeed, offset);
        transform.position = startPos + Vector2.right * newXposition;
    }
}
