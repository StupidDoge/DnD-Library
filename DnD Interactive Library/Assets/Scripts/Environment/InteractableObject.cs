using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private string _phpFileName;
    [SerializeField] private string _paramsString;

    private WebTest _webTest;
    private Renderer _renderer;

    public bool IsVisible { get; private set; }

    private void Awake()
    {
        _webTest = FindObjectOfType<WebTest>();
        _renderer = GetComponentInParent<Renderer>();
    }

    private void Update()
    {
        IsVisible = _renderer.isVisible;
    }

    public void ShowOrClearText()
    {
        if (_renderer.isVisible)
        {
            if (!_webTest.TextIsShown)
            {
                StartCoroutine(_webTest.GetText(_phpFileName, _paramsString));
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                _webTest.ClearText();
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void ClearText()
    {
        _webTest.ClearText();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (_webTest.TextIsShown)
                player.enabled = false;
            else
                player.enabled = true;
        }
    }
}
