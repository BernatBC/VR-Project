using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 1f;

    InputAction moveAction;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();

        // Move the player
        transform.position += gameObject.transform.GetChild(0).forward * speed * Time.deltaTime * move.y + gameObject.transform.GetChild(0).forward * speed * Time.deltaTime * move.x;
    }
}