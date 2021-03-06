﻿using System.Collections;
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
    public int baseValue = 20;
    public enum Growth_Stage { SEEDLING, SPROUTING, ADULT, ROTTEN };
    public Growth_Stage Stage = Growth_Stage.ADULT;
    public Mesh Sprout, Adult, Rotten;
    public Material matSprout, matAdult, matRotten;

    public PlantSpawn spawner = null;

    public override void OnInteract(GameObject objPlayer)
    {

        //Stall player for X time while doing action
        //Run an action animation
        Player pl1 = objPlayer.GetComponent<Player>();
        if(pl1.hasPlant == false)
        {
            pl1.stallPlayer(1);

            if (Stage == Growth_Stage.ADULT)
            {
                pl1.plantScore = baseValue;
                pl1.hasPlant = true;
                pl1.whatPlantHolding = 1;
                pl1.OnTriggerExit(this.GetComponent<Collider>());
                if (spawner != null)
                {
                    spawner.TrySpawningNewPlant();
                }
                Destroy(this.gameObject);
            }
            else if (Stage == Growth_Stage.ROTTEN)
            {
                pl1.plantScore = -1*baseValue;
                pl1.hasPlant = true;
                pl1.whatPlantHolding = 2;
                pl1.OnTriggerExit(this.GetComponent<Collider>());
                if (spawner != null)
                {
                    spawner.TrySpawningNewPlant();
                }
                Destroy(this.gameObject);
            }
        }
    }

    public void checkState()
    {
        if (growthValue > sproutingGrowth && Stage == Growth_Stage.SEEDLING)
        {
            becomeSprouting();
        }
        else if (growthValue > adultGrowth && Stage == Growth_Stage.SPROUTING)
        {
            becomeAdult();
        }
        else if (growthValue > rottenGrowth && Stage == Growth_Stage.ADULT)
        {
            becomeRotten();
        }
    }

    public void becomeSprouting()
    {
        Stage = Growth_Stage.SPROUTING;
        GetComponent<MeshFilter>().mesh = Sprout;
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material = matSprout;
        }
    }
    public void becomeAdult()
    {
        Stage = Growth_Stage.ADULT;
        GetComponent<MeshFilter>().mesh = Adult;
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material = matAdult;
        }
    }
    public void becomeRotten()
    {
        Stage = Growth_Stage.ROTTEN;
        GetComponent<MeshFilter>().mesh = Rotten;
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material = matRotten;
        }
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
        if (currentTimeSeconds > lastTimeSeconds)
        {
            growthValue += 0.1f;
        }
        lastTimeSeconds = (int)(TimeManager.time % 60);
        checkState();
    }
}
