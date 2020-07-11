using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Interactable
{
    //Growth stage 0 = seedling, 1 = sprouting, 2= adult, 3=rotten, roughly 
    public float growthValue = 0.0f;
    public int plantedTimeSeconds = 0;
    public int currentTimeSeconds = 0;
    public int lastTimeSeconds = 0;
    public float sproutingGrowth = 1.0f;
    public float adultGrowth = 2.0f;
    public float rottenGrowth = 3.0f;
    public enum Growth_Stage {SEEDLING, SPROUTING, ADULT, ROTTEN};
    public Growth_Stage Stage = Growth_Stage.SEEDLING;
    public 

    public override void OnInteract(GameObject objPlayer)
    {

    }

    public void checkState()
    {
        if(growthValue > sproutingGrowth && Stage != Growth_Stage.SPROUTING)
        {
            becomeSprouting();
        }
        else if (growthValue > adultGrowth && Stage != Growth_Stage.ADULT)
        {
            becomeAdult();
        }
        else if (growthValue > adultGrowth && Stage != Growth_Stage.ROTTEN)
        {
            becomeRotten();
        }
    }

    public void becomeSprouting()
    {
        GetComponent<MeshFilter).mesh = anotherMesh;
    }

    public void becomeAdult()
    {
        GetComponent(MeshFilter).mesh = anotherMesh;
    }

    public void becomeRotten()
    {
        GetComponent(MeshFilter).mesh = anotherMesh;
    }
    // Start is called before the first frame update
    void Start()
    {
        plantedTimeSeconds = (int)(TimeManager.time % 60);
    }

    // Update is called once per frame
    void Update()
    {
        //If a second has passed
        currentTimeSeconds = (int)(TimeManager.time % 60);
        if(currentTimeSeconds > lastTimeSeconds)
        {
            growthValue += 0.1f;
        }
        lastTimeSeconds = (int)(TimeManager.time % 60);
    }
}
