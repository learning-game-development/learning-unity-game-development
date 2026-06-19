using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(RectTransform))]
public class MSACCJoystick : UIBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {

	public RectTransform _joystickGraphic; 
	Vector2 _axis;
	bool _isDragging;
	[HideInInspector]
	public float joystickY;
	[HideInInspector]
	public float joystickX;

	RectTransform _rectTransform;
	public RectTransform rectTransform {
		get {
			if (!_rectTransform) {
				_rectTransform = transform as RectTransform;
			}
			return _rectTransform;
		}
	}

	public void OnBeginDrag(PointerEventData eventData) {
		if (!IsActive ()) {
			return;
		}
		EventSystem.current.SetSelectedGameObject(gameObject, eventData);
		Vector2 newAxis = transform.InverseTransformPoint(eventData.position);
		newAxis.x /= rectTransform.sizeDelta.x * 0.5f;
		newAxis.y /= rectTransform.sizeDelta.y * 0.5f;
		SetAxisMS(newAxis);
		_isDragging = true;
	}

	public void OnEndDrag(PointerEventData eventData) {
		_isDragging = false;
	}

	public void OnDrag(PointerEventData eventData) {
		RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out _axis);
		_axis.x /= rectTransform.sizeDelta.x * 0.5f;
		_axis.y /= rectTransform.sizeDelta.y * 0.5f;
		SetAxisMS(_axis);
	}

	void OnDeselect() {
		_isDragging = false;
	}

	void LateUpdate() {
		if (!_isDragging) {
			if (_axis != Vector2.zero) {
				Vector2 newAxis = _axis - (_axis * Time.deltaTime * 25.0f);
				if (newAxis.sqrMagnitude <= 0.1f) {
					newAxis = Vector2.zero;
				}
				SetAxisMS (newAxis);
			}
		}
	}

	public void SetAxisMS(Vector2 axis) {
		_axis = Vector2.ClampMagnitude(axis, 1);
		UpdateJoystickGraphicMS();
		joystickY = _axis.y;
		joystickX = _axis.x;
	}

	void UpdateJoystickGraphicMS() {
		if (_joystickGraphic) {
			_joystickGraphic.localPosition = _axis * Mathf.Max (rectTransform.sizeDelta.x, rectTransform.sizeDelta.y) * 0.5f;
		}
	}

	#if UNITY_EDITOR
	protected override void OnValidate() {
		base.OnValidate();
		UpdateJoystickGraphicMS();
	}
	#endif
}