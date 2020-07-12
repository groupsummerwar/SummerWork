﻿using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform Target;
	private Transform camTransform;

	public float shakeDuration = 0f;
	public float shakeAmount = 0.1f;
	public float decreaseFactor = 1.0f;
	public float FollowSpeed = 2f;

	Vector3 originalPos;

	void Awake()
	{
		Cursor.visible = false;
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}

	private void Update()
	{
		Vector3 newPosition = Target.position;
		newPosition.z = -10;
		transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);

		if (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
	}

	public void ShakeCamera()
	{
		originalPos = camTransform.localPosition;
		shakeDuration = 0.2f;
	}
}
