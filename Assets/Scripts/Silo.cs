using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silo : Interactable
{
    

    public void sellPlant(Player player) {
        
        player.hasPlant = false;
        player.plantScore += 100;
    }

    public override void OnInteract(GameObject objPlayer)
    {
        Player pComp = objPlayer.GetComponent<Player>();
        if(pComp.hasPlant == true) {
            sellPlant(pComp);
            Debug.Log("You sold some crops!");
        } else {
            Debug.Log("You need crops");
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
