using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    // detect move box 
    // when close to center 
    // set box to kinematic 
    // change color of preessure pad 

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "MoveBox")
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);
            Debug.Log(distance);

            if(distance < 1.10f)
            {
                Rigidbody box = other.GetComponent<Rigidbody>(); 
                if(box != null)
                {
                    box.isKinematic = true;
                }

                MeshRenderer renderer = GetComponent<MeshRenderer>(); 
                if(renderer != null)
                {
                    renderer.material.color = Color.cyan;
                }
                Destroy(this);
            }
        }
    }
}
