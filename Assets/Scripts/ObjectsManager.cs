using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectsManager : MonoBehaviour
{

    public GameObject[] placeHolderObjects;

    private GameObject currentObject = null;

    InputAction dropAction;
    InputAction makeAction;

    bool freezePeriod = false;

    // Start is called before the first frame update
    void Start()
    {
        dropAction = InputSystem.actions.FindAction("GrabDrop");
        makeAction = InputSystem.actions.FindAction("MakeAction");
    }

    // Update is called once per frame
    void Update()
    {
        if (dropAction.ReadValue<float>() > 0.1)
        {
            DropObject();
        }
        if (makeAction.ReadValue<float>() > 0.1) {
            MakeInteraction();
        }
    }

    private void MakeInteraction() {
        if (currentObject == null || freezePeriod) return;

        if (currentObject.name == "weapon") {
            // Shoot
            StartCoroutine(FreezePeriod(1f));
            return;
        }

        foreach (var item in placeHolderObjects)
        {
            if (item.name == currentObject.GetComponent<InteractiveFeedback>().objectId) item.SetActive(false);
        }
        Vector3 dropPosition = transform.position + gameObject.transform.GetChild(0).forward;
        currentObject.transform.position = dropPosition;
        currentObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.GetChild(0).forward * 20, ForceMode.Impulse);
        currentObject.SetActive(true);
        currentObject = null;
        StartCoroutine(WaitAndExplode(3f));
        StartCoroutine(FreezePeriod(1f));
    }

    private void DropObject() {
        if (currentObject == null || freezePeriod) return;
        foreach (var item in placeHolderObjects)
        {
            if (item.name == currentObject.GetComponent<InteractiveFeedback>().objectId) item.SetActive(false);
        }
        Vector3 dropPosition = transform.position + gameObject.transform.GetChild(0).forward;
        currentObject.transform.position = dropPosition;
        currentObject.SetActive(true);
        currentObject = null;
        StartCoroutine(FreezePeriod(1f));
    }

    private void SetPlaceHolderObject(GameObject grabbingObject) {
        currentObject = grabbingObject;
        foreach (var item in placeHolderObjects)
        {
            if (item.name == grabbingObject.GetComponent<InteractiveFeedback>().objectId) item.SetActive(true);
        }
    }

    public void GrabRequest(GameObject grabbingObject) {
        if (currentObject != null || freezePeriod) return;
        StartCoroutine(FreezePeriod(1f));
        grabbingObject.SetActive(false);
        SetPlaceHolderObject(grabbingObject);
    }

    private IEnumerator FreezePeriod(float delay)
    {
        freezePeriod = true;
        yield return new WaitForSeconds(delay);
        freezePeriod = false;
    }

    private IEnumerator WaitAndExplode(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Explosion animation
        Destroy(gameObject);
    }
}
