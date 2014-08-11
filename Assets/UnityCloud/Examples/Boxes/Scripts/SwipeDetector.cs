using UnityEngine;
using System;

public class SwipeDetector : MonoBehaviour {

	public bool useWorldUnits = false;
	public bool useDelta = true;
	public float updateInterval = 0.0f;

	public Action<Vector3, Vector3> onSwipeContinued;

	private bool swipeStarted = false;
	private Vector3 swipeStart;
	private Vector3 swipeEnd;

	private Camera cam;
	private float swipeStartTime;

	private void Start () {
		cam = Camera.main;
	}

	private void LateUpdate () {
#if UNITY_EDITOR || UNITY_STANDALONE
		if (swipeStarted) {
			swipeStarted = !Input.GetMouseButtonUp (0);
			swipeEnd     = Input.mousePosition;
		} else {
			swipeStarted = Input.GetMouseButtonDown (0);
			swipeStart   = Input.mousePosition;
			swipeStartTime = Time.time;
		}
#elif UNITY_IPHONE || UNITY_ANDROID
		if (Input.touchCount > 0) {
			TouchPhase phase = Input.touches[0].phase;
			if (swipeStarted) {
				swipeStarted = phase != TouchPhase.Ended;
				swipeEnd     = Input.touches[0].position;
			} else {
				swipeStarted = phase == TouchPhase.Began;
				swipeStart   = Input.touches[0].position;
			}
		}
#endif
		if (swipeStarted && onSwipeContinued != null &&
		        Time.time - swipeStartTime >= updateInterval && Time.timeScale != 0.0f) {
			//convert screen position to world units if necessary
			Vector3 start = swipeStart;
			Vector3 end   = swipeEnd;
			if (useWorldUnits) {
				start = cam.ScreenToWorldPoint (swipeStart);
				end   = cam.ScreenToWorldPoint (swipeEnd);
			}
			if (useDelta) end = end - start;
			onSwipeContinued (start, end);
			swipeStartTime = Time.time;
		}
	}
}
