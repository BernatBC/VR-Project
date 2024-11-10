using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InteractiveButton : MonoBehaviour
{

    public Material InactiveMaterial;
    public Material SelectedInactiveMaterial;
    public Material ActiveMaterial;
    public Material SelectedActiveMaterial;

    public bool fovToggler = false;
    public bool changeTimeToggler = false;

    public GameObject fovRestricter;
    public GameObject mainCamera;

    private MeshRenderer _myRenderer;
    private bool buttonIsActive = false;
    private bool freezePeriod = false;
    private Color skyBlue = new Color(0.55f, 0.72f, 0.98f);
    private Color darkBlue = new Color(0.13f, 0.21f, 0.36f);

    InputAction makeAction;

    private bool selected = false;

    public void Start()
    {
        makeAction = InputSystem.actions.FindAction("MakeAction");
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

    private void SetMaterial()
    {
        if (InactiveMaterial != null && ActiveMaterial != null && SelectedInactiveMaterial != null && SelectedActiveMaterial != null)
        {
            _myRenderer.material = GetMaterial();
        }
    }

    private Material GetMaterial() {
        if (buttonIsActive) return selected ? SelectedActiveMaterial : ActiveMaterial;
        else return selected ? SelectedInactiveMaterial : InactiveMaterial;
    }

    private void Update()
    {
        if (!freezePeriod && selected && makeAction.ReadValue<float>() > 0.1)
        {
            buttonIsActive = !buttonIsActive;
            SetMaterial();
            if (fovToggler) {
                fovRestricter.SetActive(buttonIsActive);
            }
            if (changeTimeToggler) {

                mainCamera.GetComponent<Camera>().backgroundColor = buttonIsActive ? skyBlue : darkBlue;
            }
            StartCoroutine(FreezePeriod(1f));
        }
    }

    private IEnumerator FreezePeriod(float delay)
    {
        freezePeriod = true;
        yield return new WaitForSeconds(delay);
        freezePeriod = false;
    }
}
