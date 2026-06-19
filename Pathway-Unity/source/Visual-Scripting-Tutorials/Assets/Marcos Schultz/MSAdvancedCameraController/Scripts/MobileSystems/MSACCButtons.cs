using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class MSACCButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	[HideInInspector]
	public float input;
	bool pressing;

	public void OnPointerDown(PointerEventData eventData){
		pressing = true;
	}

	public void OnPointerUp(PointerEventData eventData){
		pressing = false;
	}

	void Update () {
		if (pressing) {
			input += Time.deltaTime * 3;
		} else {
			input -= Time.deltaTime * 3;
		}
		input = Mathf.Clamp (input, 0, 1);
	}
}