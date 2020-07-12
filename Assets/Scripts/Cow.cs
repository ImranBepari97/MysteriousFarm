using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Interactable

{
    public bool isMilkedToday;
    public bool isMilkable;
    // Start is called before the first frame update
    void Start()
    {
        isMilkedToday = false;
        isMilkable = true;
        GetComponent<AudioSource>().enabled = false;
    }

    public void milk() {
        isMilkable = false;
        isMilkedToday = true;
    }

    public void updateMilkStatus() {
    }

    public override void OnInteract(GameObject objPlayer)
    {
        if(isMilkable == true) {
            milk();
            Debug.Log("You got some milk!");
            GetComponent<AudioSource>().enabled = true;
        } else {
            Debug.Log("Come back tommorow for more milk!");
            GetComponent<AudioSource>().enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
