using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawn : MonoBehaviour
{

    public float spawnChance = 0.1f;
    public Plant currentVegetable; 

    public List<Plant> possiblePlants;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPlant());
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Called by Plant on this when the plants been picked so a new plant can be spawned
    public void TrySpawningNewPlant() {
        currentVegetable = null;
        StartCoroutine(SpawnPlant());
    }

    IEnumerator SpawnPlant()
    {
        while(!GameManager.isGameOver && currentVegetable == null) {
            yield return new WaitForSeconds(1f);
            float spawn = Random.Range(0, 1f);
            if(spawn < spawnChance) {
                Debug.Log("Spawn rng: " + spawn);
                currentVegetable = Instantiate(possiblePlants[Random.Range(0, possiblePlants.Count-1)], gameObject.transform.position, Quaternion.identity);
                currentVegetable.spawner = this;
                spawnChance += 0.01f;
            }
        }
    }
}
