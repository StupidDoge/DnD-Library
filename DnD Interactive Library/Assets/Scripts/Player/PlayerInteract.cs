using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
	[SerializeField] private Transform _flashlight;

	private bool _flashlightIsActive = false;
	private InputHandler _inputHandler;

	private void Start()
	{
		_inputHandler = GetComponent<InputHandler>();
	}

	private void Update()
	{
		if (_inputHandler.Flashlight && !InteractionCollider.CanvasIsActive && !PauseController.GameIsPaused)
			ActivateFlashlight();
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.TryGetComponent(out InteractionCollider collider))
		{
			if (_inputHandler.Use && !InteractionCollider.CanvasIsActive)
				collider.ShowCanvas();

			if (_inputHandler.Exit && InteractionCollider.CanvasIsActive)
				collider.HideCanvas();
		}
	}

	private void ActivateFlashlight()
	{
		_flashlightIsActive = !_flashlightIsActive;
		_flashlight.gameObject.SetActive(_flashlightIsActive);
	}
}
