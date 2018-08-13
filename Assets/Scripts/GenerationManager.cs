using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerationManager : MonoBehaviour {
    float currentLoc = -20; //Area to load in

    const int loadOffset = 41; //How early should loading be
    const int unloadOffset = 40; //How far away should be unloaded

    int areasGenerated = 0;
    public int generationBeforeCheckout = 10;

    bool generate = true; //Stop generation after checkout
    List<RegionData> generateRegions = new List<RegionData>();

    Transform player;


    public List<RegionData> regions;

    void GenerateRegion(RegionData region)
    {
        Debug.Log("Spawning " + region.name + " Region!");
        areasGenerated++;

        //Create region
        GameObject gobj = Instantiate(region.prefab);
        //Move region to location
        gobj.transform.position = new Vector3(currentLoc + region.length/2, gobj.transform.position.y, gobj.transform.position.z);

        //Setup region unload
        gobj.AddComponent<RegionDeathMachine>();
        gobj.GetComponent<RegionDeathMachine>().DestroyDistance = region.length * 1.5f + unloadOffset;

        //Name region
        gobj.name = "Generated Region: " + areasGenerated.ToString();

        //Find item spawn location and spawn items
        foreach (ItemSpawnLocation loc in gobj.gameObject.GetComponentsInChildren<ItemSpawnLocation>())
        {
            //Get random item
            GameObject newItemPrefab = region.objectsInArea[Random.Range(0, region.objectsInArea.Count)];
            //Create item
            GameObject newItem = Instantiate(newItemPrefab);
            newItem.name = newItemPrefab.name;
            newItem.transform.position = loc.transform.position;

            //Setup item settings
            ShoppingItem item = newItem.GetComponent<ShoppingItem>();
            if(item != null)
            {
                item.rotates = loc.rotates;
                item.SetGlobalScale();
            }
            newItem.transform.SetParent(loc.transform.parent);
            Destroy(loc.gameObject);
        }
        currentLoc += region.length;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //Get player loc
        GenerateRegion(regions[0]); //Generate default region

        //Create region pool
        foreach(RegionData region in regions)
        {
            for(int i = 0; i < region.spawnProbability; i++)
            {
                generateRegions.Add(region);
            }
        }
    }

    void Update()
    {
        //If within space distance
        if(player.transform.position.x > currentLoc - loadOffset & generate)
        {
            //Check if it should generate checkout
            if (areasGenerated > generationBeforeCheckout)
            {
                //Generate checkout and stop generation
                generate = false;
                GenerateRegion(regions[2]);
            }
            else
            {
                //Generate "random" region
                GenerateRegion(generateRegions[Random.Range(0, generateRegions.Count)]);
            }
        }
    }

}

