using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTransport : MonoBehaviour {
    public GameObject ExitPortal;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("woooooo");
            other.transform.position = ExitPortal.transform.position;
        }
    }
}
