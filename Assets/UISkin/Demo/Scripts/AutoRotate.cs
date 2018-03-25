using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fields;

public class AutoRotate : MonoBehaviour
{
	public FloatField xAngle, yAngle, zAngle;

	// Update is called once per frame
	void Update()
	{
		if (xAngle != null && yAngle != null && zAngle != null)
		{
			transform.Rotate(xAngle.GetValue(), yAngle.GetValue(), zAngle.GetValue());
		}
		
	}
}
