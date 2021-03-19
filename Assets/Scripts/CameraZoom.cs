 using UnityEngine;
 using System.Collections;
 
public class CameraZoom : MonoBehaviour {
    private Camera cam;
    private float targetZoom;
    private float zoomFactor = 3f;
    [SerializeField]
    private float zoomLerpSpeed = 10;

    public float minZoom;
    public float maxZoom;

    private void Awake() {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
    }

    private void Update() {
        float scrollData = Input.GetAxis("Mouse ScrollWheel");
        targetZoom -= scrollData * zoomFactor;
        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);
    }
}    