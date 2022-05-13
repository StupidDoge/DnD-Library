using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
	[SerializeField] private Transform _flashlight;

	private bool _inTrigger;
	private bool _allowInteraction;
	private bool _flashlightIsActive = false;
	private InputHandler _inputHandler;

	private void Start()
	{
		_inputHandler = GetComponent<InputHandler>();
	}

	private void Update()
	{
		if (_inputHandler.Use && _inTrigger)
			_allowInteraction = true;

		if (_inputHandler.Flashlight)
			ActivateFlashlight();
	}

	private void OnTriggerEnter(Collider other)
	{
		_inTrigger = true;
	}

	private void OnTriggerExit(Collider other)
	{
		_inTrigger = false;
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.TryGetComponent(out InteractableObject obj) && _allowInteraction)
		{
			obj.ShowOrClearText();
			_allowInteraction = false;
		}
	}

	private void ActivateFlashlight()
	{
		_flashlightIsActive = !_flashlightIsActive;
		_flashlight.gameObject.SetActive(_flashlightIsActive);
	}
}
