using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPickups : MonoBehaviour {

    [SerializeField]private List<GameObject> _pickUps = new List<GameObject>();
    [SerializeField]private List<Transform> _platforms = new List<Transform>();

	void Start () {
        AddPlatformsToList();
        Spawn();	
	}

    void AddPlatformsToList()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == Tags.PLATFORM)
            {
                _platforms.Add(child);
            }
        }
    }

    void Spawn()
    {
        for (int i = 0; i < _platforms.Count; i++)
        {
            int chanceToSpawn = Random.Range(0, 100);
            int pickUpToSpawn = Random.Range(0, _pickUps.Count);
            if (chanceToSpawn > 0 && chanceToSpawn < 10)
            {
                Transform spawnPos = _platforms[i].GetChild(0);
                GameObject pickUpObject = Instantiate(_pickUps[pickUpToSpawn]);
                pickUpObject.transform.position = new Vector3(spawnPos.position.x,spawnPos.position.y,-1);
                pickUpObject.transform.SetParent(spawnPos);
            }
        }        
    }
}
