using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Transform InitialPos;
    public Transform BattlefieldPos;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Portal A"))
        {
            Debug.Log("Portal A");
            transform.position = BattlefieldPos.position;
        }
        if (collision.gameObject.CompareTag("Portal B"))
        {
            Debug.Log("Portal B");
            transform.position = InitialPos.position;
        }
    }
}
