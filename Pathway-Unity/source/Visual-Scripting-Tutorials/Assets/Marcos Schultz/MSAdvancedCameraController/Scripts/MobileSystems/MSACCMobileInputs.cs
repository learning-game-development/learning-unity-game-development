using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MSACCMobileInputs : MonoBehaviour {

	[Header("Controller")][Tooltip("Here you must associate a camera controller of type 'MSCameraController' that will receive the inputs of this object.")]
	public MSCameraController cameraController;

	[Header("Settings")]
	[Tooltip("Here it is possible to define the speed at which the variable that controls the scroll will be incremented or decremented by the buttons.")][Range(0.1f, 1.0f)]
	public float sensibilityScroll = 0.5f;
	[Range(0.1f, 1.0f)][Tooltip("Here you can set the X-axis sensitivity of the virtual joystick.")]
	public float sensibilityX = 0.5f;
	[Range(0.1f, 1.0f)][Tooltip("Here you can set the Y-axis sensitivity of the virtual joystick.")]
	public float sensibilityY = 0.5f;
	[Tooltip("If this variable is true, the X-axis inputs of the virtual joystick will be reversed.")]
	public bool invertJoystickX = false;
	[Tooltip("If this variable is true, the Y-axis inputs of the virtual joystick will be reversed.")]
	public bool invertJoystickY = false;

    MSACCJoystick joystick;
	MSACCButtons scrollUpButton;
	MSACCButtons scrollDownButton;
    Button changeCamerasButton;

    Vector2 joystickInput;
	float scrollInput;
	bool error;

	void Awake(){
		error = false;
		if (cameraController) {
			joystick = transform.root.Find ("Canvas/Joystick").GetComponent<MSACCJoystick> ();
			scrollUpButton = transform.root.Find ("Canvas/scrollUp").GetComponent<MSACCButtons> ();
			scrollDownButton = transform.root.Find ("Canvas/scrollDown").GetComponent<MSACCButtons> ();
            changeCamerasButton = transform.root.Find("Canvas/changeCamerasButton").GetComponent<Button>();

            //joystick
            if (!joystick) {
				Debug.LogWarning ("The prefab " + transform.root.name + " had its structure modified and this interferes in the correct functioning of the code. The controller will be disabled to avoid problems.");
				error = true;
				transform.root.gameObject.SetActive (false);
			}

			//change cameras button
			if (changeCamerasButton) {
				changeCamerasButton.onClick = new Button.ButtonClickedEvent ();
				changeCamerasButton.onClick.AddListener (() => cameraController.MSADCCChangeCameras ());
			} else {
				Debug.LogWarning ("The prefab " + transform.root.name + " had its structure modified and this interferes in the correct functioning of the code. The controller will be disabled to avoid problems.");
				error = true;
				transform.root.gameObject.SetActive (false);
			}

			//scroll Up Button
			if (!scrollUpButton) {
				Debug.LogWarning ("The prefab " + transform.root.name + " had its structure modified and this interferes in the correct functioning of the code. The controller will be disabled to avoid problems.");
				error = true;
				transform.root.gameObject.SetActive (false);
			}

			//scroll Down Button
			if (!scrollDownButton){
				Debug.LogWarning ("The prefab " + transform.root.name + " had its structure modified and this interferes in the correct functioning of the code. The controller will be disabled to avoid problems.");
				error = true;
				transform.root.gameObject.SetActive (false);
			}
		} else {
			Debug.LogWarning ("No 'camera controller' was associated to object " + transform.root.name + ", so it was disabled from the scene.");
			error = true;
			transform.root.gameObject.SetActive (false);
		}
	}

	void Update () {
		if (!error) {
			//enable inputs
			cameraController._enableMobileInputs = true;
			EnableMobileInputs (cameraController._mobileInputsIndex);


			//get Joystick Inputs
			joystickInput = new Vector2 (joystick.joystickX, joystick.joystickY);
			if (invertJoystickX) {
				joystickInput = new Vector2 (-joystickInput.x, joystickInput.y);
			}
			if (invertJoystickY) {
				joystickInput = new Vector2 (joystickInput.x, -joystickInput.y);
			}

			//get scroll inputs
			scrollInput = (scrollUpButton.input - scrollDownButton.input) * 0.02f;


			//set inputs
			cameraController._horizontalInputMSACC = joystickInput.x * sensibilityX;
			cameraController._verticalInputMSACC = joystickInput.y * sensibilityY;
			cameraController._scrollInputMSACC = scrollInput * sensibilityScroll;
		}
	}

	void EnableMobileInputs(int index){
		// 0 = off,   1 = all,   2 = scroll buttons only
		//changeCamerasButton.gameObject.SetActive (false);
		if (index == 0) {
			joystick.gameObject.SetActive (false);
			scrollUpButton.gameObject.SetActive (false);
			scrollDownButton.gameObject.SetActive (false);
		}
		if (index == 1) {
			joystick.gameObject.SetActive (true);
			scrollUpButton.gameObject.SetActive (true);
			scrollDownButton.gameObject.SetActive (true);
		}
		if (index == 2) {
			joystick.gameObject.SetActive (false);
			scrollUpButton.gameObject.SetActive (true);
			scrollDownButton.gameObject.SetActive (true);
		}
	}
}
