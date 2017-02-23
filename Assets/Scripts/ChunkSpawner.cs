using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChunkSpawner : MonoBehaviour {

    [SerializeField]private List<GameObject> _chunks = new List<GameObject>();
    [SerializeField]private Transform _camera;
    [SerializeField]private Transform _player;
    [SerializeField]private Transform _chunkParent;
    private List<GameObject> _spawnedChunks = new List<GameObject>();
    private GameObject _lastSpawnedChunk;
    private SpriteRenderer _lastChunkSpriteRenderer;
    private bool _spawnedFirstChunk;

    public List<GameObject> SpawnedChunks
    {
        get { return _spawnedChunks; }
        set { _spawnedChunks = value; }
    }

	void Start () {
        SpawnRandomChunk();
	}
	
	void Update () {
        if (_player != null)
        {
            if (_player.transform.position.y >= _lastSpawnedChunk.transform.position.y)
            {
                SpawnRandomChunk();
            }
        }

        if (_camera.position.y >= _lastSpawnedChunk.transform.position.y)
        {
            SpawnRandomChunk();
        }

        DestroyOldChunks();
	}

    void SpawnRandomChunk()
    {

        int randomChunk = Random.Range(0, _chunks.Count);
        if (_lastSpawnedChunk != null) { }
        
        GameObject spawnedChunk = Instantiate(_chunks[randomChunk]);    //Spawns a chunk
        spawnedChunk.transform.parent = _chunkParent;
        SpriteRenderer spriterenderer = spawnedChunk.GetComponent<SpriteRenderer>();
        if (_lastSpawnedChunk != null)
        {
            SpriteRenderer lastChunkSpriteRenderer = _lastSpawnedChunk.GetComponent<SpriteRenderer>();
            float spawnPos = lastChunkSpriteRenderer.bounds.max.y;
            spawnedChunk.transform.position = new Vector2(0,spawnPos + 4.9f); //Spawns the next chunk atop the last one
        }
        _lastSpawnedChunk = spawnedChunk;
        _spawnedChunks.Add(spawnedChunk);
    }

    void DestroyOldChunks()
    {
        if (_spawnedChunks.Count >= 5)
        {
            Destroy(_spawnedChunks[0]);
            Destroy(_spawnedChunks[1]);
        }
    }
}
