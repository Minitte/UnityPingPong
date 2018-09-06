using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour {

	public float Speed;

	public Vector3 StartPoint;

	public Vector3 EndPoint;

	private float _t = 0.5f;

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		float tDist = Speed / Vector3.Distance(EndPoint, StartPoint);
		tDist *= Time.deltaTime;

		if (Input.GetKey("w"))
		{
			_t += tDist;

			// max _t at 1
			_t = _t > 1f ? 1f : _t;
		}

		else if (Input.GetKey("s"))
		{
			_t -= tDist;

			// min _t at 0
			_t = _t < 0f ? 0f : _t;
		}

		transform.position = Vector3.Lerp(StartPoint, EndPoint, _t);
	}
}
