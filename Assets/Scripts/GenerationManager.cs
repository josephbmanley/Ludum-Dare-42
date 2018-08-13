using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerationManager : MonoBehaviour {
    float currentLoc = -20;
    const int loadOffset = 41;
    const int unloadOffset = 40;
    int areasGenerated = 0;
    public int generationBeforeCheckout = 10;
    bool generate = true;
    List<RegionData> generateRegions = new List<RegionData>();

    Transform player;


    public List<RegionData> regions;

    void GenerateRegion(RegionData region)
    {
        Debug.Log("Spawning " + region.name + " Region!");
        areasGenerated++;
        GameObject gobj = Instantiate(region.prefab);
        gobj.transform.position = new Vector3(currentLoc + region.length/2, gobj.transform.position.y, gobj.transform.position.z);
        gobj.AddComponent<RegionDeathMachine>();
        gobj.GetComponent<RegionDeathMachine>().DestroyDistance = region.length * 1.5f + unloadOffset;
        gobj.name = "Generated Region: " + areasGenerated.ToString();
        foreach (ItemSpawnLocation loc in gobj.gameObject.GetComponentsInChildren<ItemSpawnLocation>())
        {
            GameObject newItemPrefab = region.objectsInArea[Random.Range(0, region.objectsInArea.Count)];
            GameObject newItem = Instantiate(newItemPrefab);
            newItem.name = newItemPrefab.name;
            newItem.transform.position = loc.transform.position;
            ShoppingItem item = newItem.GetComponent<ShoppingItem>();
            if(item != null)
            {
                item.rotates = loc.rotates;
                item.SetGlobalScale();
            }
            newItem.transform.SetParent(loc.transform);
        }
        currentLoc += region.length;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GenerateRegion(regions[0]);
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
        if(player.transform.position.x > currentLoc - loadOffset & generate)
        {
            if (areasGenerated > generationBeforeCheckout)
            {
                generate = false;
                GenerateRegion(regions[2]);
            }
            else
            {
                GenerateRegion(generateRegions[Random.Range(0, generateRegions.Count)]);
            }
        }
    }

}

