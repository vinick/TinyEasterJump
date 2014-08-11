using UnityEngine;

[RequireComponent (typeof (SwipeDetector))]
public class SwipeLook : MonoBehaviour {

	public Transform target;
	public Vector2 sensitivity = 0.1f * Vector2.one;
	public bool invertX = false;
	public bool invertY = false;

	private SwipeDetector swipeDetector;
	private float x;
	private float y;

	private void Awake () {
		swipeDetector = GetComponent<SwipeDetector> ();
		swipeDetector.onSwipeContinued = OnSwipeContinued;
		swipeDetector.useDelta = true;
		if (invertX) sensitivity.x *= -1.0f;
		if (invertY) sensitivity.y *= -1.0f;
	}

	private void Start () {
		if (target == null) target = transform;
		x = target.localEulerAngles.x;
		y = target.localEulerAngles.y;
	}

	private void OnSwipeContinued (Vector3 start, Vector3 delta) {
		//horizontal swipe rotates around y axis, vertical swipe rotates around x axis
		x -= delta.y * sensitivity.x;
		y += delta.x * sensitivity.y;
		target.localRotation = Quaternion.Euler (x, y, 0.0f);
	}
}
