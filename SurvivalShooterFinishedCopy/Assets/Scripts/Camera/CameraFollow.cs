using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public PlayerHealth playerHealth;

	public Transform target;

	public float smoothing = 5f;

	private Vector3 offset;

	public float scaling;

	Camera cam;

	void Start()
	{
		cam = GetComponent<Camera>();
		offset = transform.position - target.position;
	}

	void FixedUpdate()
	{
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

		if(playerHealth.currentHealth <= 0)
        {
			cam.orthographicSize -= .015f;
        }
	}
}
