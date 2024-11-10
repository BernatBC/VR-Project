using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Transform InitialPos;
    public Transform BattlefieldPos;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Portal A"))
        {
            CharacterController cc = GetComponent<CharacterController>();

            cc.enabled = false;
            transform.position = BattlefieldPos.transform.position;
            transform.rotation = new Quaternion(transform.rotation.x, BattlefieldPos.rotation.y, transform.rotation.z, transform.rotation.w);

            cc.enabled = true;
        }
        if (col.CompareTag("Portal B"))
        {
            CharacterController cc = GetComponent<CharacterController>();

            cc.enabled = false;
            transform.position = InitialPos.transform.position;
            transform.rotation = new Quaternion(transform.rotation.x, InitialPos.rotation.y, transform.rotation.z, transform.rotation.w);

            cc.enabled = true;
        }
    }

}
