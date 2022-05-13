using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private CharacterController _player;
    private PlayerSoundController _playerSoundController;
    private InputHandler _input;
    private Vector3 _moveDir;

    private float _gravity = -9.8f;
    private float _verticalSpeed = 0;

    private void Awake()
    {
        _player = GetComponent<CharacterController>();
        _playerSoundController = GetComponent<PlayerSoundController>();
        _input = GetComponent<InputHandler>();
    }

    public void Move()
    {
        _moveDir = (transform.right * _input.Horizontal + transform.forward * _input.Vertical) * _speed;

        if (_player.isGrounded)
            _verticalSpeed = 0;
        else 
            _verticalSpeed = _gravity;
        _moveDir.y = _verticalSpeed;

        _player.Move(_moveDir * Time.deltaTime);

        if (_player.velocity.magnitude > 2f)
            _playerSoundController.PlayMoveSound();
    }
}
