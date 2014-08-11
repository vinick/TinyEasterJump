using UnityEngine;
using System.Collections;

public class SortingRenderer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		this.renderer.sortingLayerName = "Coelho";
		this.renderer.sortingOrder = -4;
	
	}
}
