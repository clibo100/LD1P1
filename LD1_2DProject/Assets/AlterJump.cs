using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterJump : MonoBehaviour {
    GameObject lemon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Pickup(other);
        }
    }

    void Pickup(Collider player)
    {
        //Debug.Log("did it");
        CharacterMovement controller = player.GetComponent<CharacterMovement>();
        controller.canDoubleJump = true;
        gameObject.GetComponent<Renderer>().enabled = false;

    }

}
