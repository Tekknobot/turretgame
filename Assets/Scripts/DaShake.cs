using UnityEngine;
using System.Collections;
using CustomCamera;

public class DaShake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform target;
	
	// How long the object should shake for.
	public float shakeDuration = 0f;
	
	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;
	
	Vector3 originalPos;

    public bool shaketrue = false;
	
	void Awake()
	{
		if (target == null)
		{
			target = GetComponent(typeof(Transform)) as Transform;
		}
	}
	
	void OnEnable()
	{
		//originalPos = camTransform.localPosition;
	}

	void Update()
	{
        if (shaketrue) {
            if (shakeDuration > 0)
            {
                transform.position = transform.position + Random.insideUnitSphere * shakeAmount;
                
                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shakeDuration = 0.1f;
                target.localPosition = new Vector3(transform.position.x, 0, -10);
                shaketrue = false;
            }
        }
	}

    public void shakecamera()
    {
        shaketrue = true;
    }    
}