using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
	public float movementSpeed;
    public bool whiteKey = false;


    List<Interactable> interactables;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  
        interactables = new List<Interactable>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

    }

    void Update()
    {

        rb.velocity = new Vector3(movementSpeed * Input.GetAxis("Horizontal"), rb.velocity.y, movementSpeed * Input.GetAxis("Vertical"));
		 
		if (rb.velocity.magnitude != 0)
        {
            rb.rotation = Quaternion.LookRotation(rb.velocity);
        }

        //Interaction Call
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Press E");
            if(interactables.Count > 0) {
                interactables[0].OnInteract(this.gameObject);
            }
                
            
        }
    }


    void OnTriggerExit(Collider coll) {
        if(coll.gameObject.GetComponent<Interactable>()) {
            interactables.Remove(coll.gameObject.GetComponent<Interactable>());
        }
    }

    void OnTriggerEnter(Collider coll) {
        if(coll.gameObject.GetComponent<Interactable>()) {
            interactables.Add(coll.gameObject.GetComponent<Interactable>());
        }
    }
}
