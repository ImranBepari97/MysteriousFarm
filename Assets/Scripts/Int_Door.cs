using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Int_Door : Interactable
{
    // Start is called before the first frame update

    public bool keyRequired = false;
    //The game times at which the isOpenState Changes (secs)
    public int[] stateChanges = { };

    public bool isOpenTime = true;

    public bool doorOpen = false;

    public GameObject blocker;

    void Start()
    {
        
    }

    public void openDoor()
    {
        doorOpen = true;
        blocker.SetActive(false);
    }

    public void closeDoor()
    {
        doorOpen = false;
        blocker.SetActive(true);
    }

    public override void OnInteract(GameObject objPlayer)
    {
        if(doorOpen == false)
        {
            Player pComp = objPlayer.GetComponent<Player>();
            //Does player have things for door
            if ((keyRequired == true && pComp.whiteKey == true) || keyRequired == false)
            {
                openDoor();
            } else {
                //if no Chat message player does not have key for door
                Debug.Log("You didn't have the key !");
                return;
            }
            //Is it the right time for the door
            if (isOpenTime == true)
            {
                openDoor();
            } else {
                Debug.Log("Maybe come back another time");
                return;
            }
        } else {
            closeDoor();
        }

            //If no chat message that cannot be opened at this time
        
        //Open or do not open door

    }

    // Update is called once per frame
    void Update()
    {
        updateOpenTimeState();
    }

    public void updateOpenTimeState()
    {
        int timeSecs = (int)(TimeManager.time % 60);
        for(int i = 0; i < stateChanges.Length; i++)
        {
            if (stateChanges[i] == timeSecs)
            {
                stateChanges[i] = 0;
                isOpenTime = !isOpenTime;
            }
        }
    }
}
