using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private PlayerMove _move;
    private PlayerRotation _playerRotation;

    private void Awake()
    {
        _move = GetComponent<PlayerMove>();
        _playerRotation = GetComponent<PlayerRotation>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (!PauseController.GameIsPaused)
        {
            _move.Move();
            _playerRotation.Rotate();
        }
    }
}
