using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 1f;

    public TextMeshPro debugText;

    InputAction moveAction;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        debugText.text = "Horizontal: " + move.x + ", Vertical: " + move.y;

        Debug.Log(move.x + ", " + move.y);

        // Move the player
        transform.position += transform.forward * speed * Time.deltaTime * move.y + transform.right * speed * Time.deltaTime * move.x;
    }
}