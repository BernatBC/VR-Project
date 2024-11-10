using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InteractiveButton : MonoBehaviour
{

    public Material InactiveMaterial;
    public Material GazedAtMaterial;
    public bool fovToggler = false;
    public bool changeTimeToggler = false;

    private MeshRenderer _myRenderer;

    InputAction makeAction;

    private bool selected = false;

    public void Start()
    {
        makeAction = InputSystem.actions.FindAction("makeAction");
        _myRenderer = GetComponent<MeshRenderer>();
        SetMaterial();
    }

    public void OnPointerEnter()
    {
        selected = true;
        SetMaterial();
    }

    public void OnPointerExit()
    {
        selected = false;
        SetMaterial();
    }

    public void OnPointerClick()
    {
        Debug.Log("Grab object");
    }

    private void SetMaterial()
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = selected ? GazedAtMaterial : InactiveMaterial;
        }
    }

    private void Update()
    {
        if (selected && makeAction.ReadValue<float>() > 0.1)
        {
            if (fovToggler) Debug.Log("Toggling FOV");
            if (changeTimeToggler) Debug.Log("Changing light");
        }
    }
}
