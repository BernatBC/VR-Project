using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Explosion : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MakeInteraction() {
        // Throw object
        Vector3 forwardVector = GameObject.Find("Player").transform.GetChild(0).forward;
        Vector3 dropPosition = transform.position + forwardVector;
        transform.position = dropPosition;
        gameObject.GetComponent<Rigidbody>().AddForce(forwardVector * 5, ForceMode.Impulse);
        gameObject.SetActive(true);
        StartCoroutine(WaitAndExplode(3f));
    }

    private IEnumerator WaitAndExplode(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Explosion animation
        Destroy(gameObject);
    }
}