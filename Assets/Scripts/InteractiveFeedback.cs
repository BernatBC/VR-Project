using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractiveFeedback : MonoBehaviour
{

    public Material InactiveMaterial;
    public Material GazedAtMaterial;
    public string objectId;

    private MeshRenderer _myRenderer;

    InputAction grabAction;

    private bool selected = false;

    public void Start()
    {
        grabAction = InputSystem.actions.FindAction("GrabDrop");
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
        if (selected && grabAction.ReadValue<float>() > 0.1) {
            GameObject.Find("Player").GetComponent<ObjectsManager>().GrabRequest(gameObject);
        }
    }
}
