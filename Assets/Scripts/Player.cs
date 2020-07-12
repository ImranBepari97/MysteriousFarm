using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
	public float movementSpeed;
    public bool whiteKey = false;
    public bool stalled = false;
    public int stallTimerSeconds = 0;
    public int currentTimeSeconds = 0;
    public int lastTimeSeconds = 0;
    public bool hasPlant = false;
    public int plantScore = 0;
    public bool canEquiped = false;

    List<Interactable> interactables;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  
        interactables = new List<Interactable>();
        GetComponent<Animation>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

    }

    public void stallPlayer(int stallSec)
    {
        GetComponent<Animation>().enabled = true;
        stalled = true;
        stallTimerSeconds = stallSec;
        //Kill player momentum
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void Update()
    {
        if(stalled == false && !GameManager.isGameOver)
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
                if (interactables.Count > 0)
                {
                    interactables[0].OnInteract(this.gameObject);
                }
            }

            //Equip Watering Can
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if(canEquiped == false)
                {
                    //Create child object watering can on player
                    canEquiped = true;
                }
                else
                {
                    //Remove can object
                    canEquiped = false;
                }
                
            }
            

        }
        else
        {
            //If a second has passed
            currentTimeSeconds = (int)(TimeManager.time % 60);
            if (currentTimeSeconds > lastTimeSeconds)
            {
                stallTimerSeconds -= 1;
                if(stallTimerSeconds < 0)
                {
                    stalled = false;
                    GetComponent<Animation>().enabled = false;
                }
            }
            lastTimeSeconds = (int)(TimeManager.time % 60);
        }

    }


    public void OnTriggerExit(Collider coll) {
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
