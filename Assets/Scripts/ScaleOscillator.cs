using UnityEngine;
using System.Collections;

public class ScaleOscillator : MonoBehaviour
{

    public float maxScale;
    public float minScale;
    public float scalingSpeed;

    float currentScale;
    int sign;

	void Start ()
    {
        currentScale = maxScale;
        sign = -1;
	}

    void Update()
    {
        currentScale += scalingSpeed * sign * Time.deltaTime;

        if (currentScale >= maxScale)
            sign = -1;

        if (currentScale <= minScale)
            sign = 1;

        transform.localScale = new Vector3(transform.localScale.x, currentScale, transform.localScale.z);
	}
}
