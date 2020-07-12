using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : Interactable
{
    public void DumpPlant(Player player)
    {
        player.hasPlant = false;
        player.whatPlantHolding = 0;
    }

    public override void OnInteract(GameObject objPlayer)
    {
        Player pComp = objPlayer.GetComponent<Player>();
        if (pComp.hasPlant == true)
        {
            DumpPlant(pComp);
        }
        else
        {
            Debug.Log("You need crops to dump");
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
