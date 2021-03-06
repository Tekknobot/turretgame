using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash : MonoBehaviour {

	public Color flashColor;
	public float flashDuration;

	Material mat;

    private IEnumerator flashCoroutine;

	private void Awake() {
		mat = GetComponent<SpriteRenderer>().material;
	}

	private void Start() {
		mat.SetColor("_FlashColor", flashColor);
	}

    private void Update() {
		if(Input.GetKeyDown(KeyCode.Space))
			Flash();
	}

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Bullet") {
            Flash();
        }              
	}		

	public void Flash() {
		if (flashCoroutine != null)
		    	StopCoroutine(flashCoroutine);
		
		flashCoroutine = DoFlash();
        StartCoroutine(flashCoroutine);
    }

    private IEnumerator DoFlash() {
        float lerpTime = 0;

        while (lerpTime < flashDuration) {
            lerpTime += Time.deltaTime;
            float perc = lerpTime / flashDuration;

            SetFlashAmount(1f - perc);
            yield return null;
        }
        SetFlashAmount(0);
    }
	
    private void SetFlashAmount(float flashAmount) {
        mat.SetFloat("_FlashAmount", flashAmount);
    }
}