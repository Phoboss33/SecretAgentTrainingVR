using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileGeneratorScript : MonoBehaviour
{
    public GameObject[] defaultTilePrefabs;
    public GameObject[] spiralTilePrefabs;
    public GameObject[] LeftRightTilePrefabs;
    public GameObject[] OtherSpiralTilePrefabs;

    public GameObject[] startTilePrefabs;

    public Move move;
    
    public float tileLenght = 10;
    public int offsetPlayer = 10;
    public int startTileCount = 15;

    private int tileCount = 0;
    private float spawnPos = 0;


    private bool canSpawnSpiral;
    private bool canSpawnLeftRight;
    private bool canSpawnOther;
    

    [SerializeField] private Transform player;

    
    private List<GameObject> activeTiles = new List<GameObject>();

    private void Start() {
        ToTrueAllFunc();

        SpawnStartTile(0);

        for (int i = 0; i < startTileCount; i++) {
            SpawnTile(Random.Range(0, defaultTilePrefabs.Length));
        }
    }

    private void Update() {
        if (player.position.z - offsetPlayer > spawnPos - (startTileCount * tileLenght)) {
            if (move.timeElapsed < 15) {
                SpawnTile(Random.Range(0, defaultTilePrefabs.Length));
                ToTrueAllFunc();
            }
            else if (move.timeElapsed > 15 && canSpawnSpiral) {
                int randomTile = Random.Range(0, 2);
                SpawnSpiral();
                /*if (randomTile == 0)
                    SpawnSpiral();
                else if (randomTile == 1)
                    SpawnLeftRight();
                else
                    SpawnOtherSpiral();*/


            }
            else if (move.timeElapsed > 35 && canSpawnLeftRight) {
                SpawnLeftRight();
                
            }
            else if (move.timeElapsed > 70 && canSpawnOther) {
                SpawnOtherSpiral();
                
            }
            else {
                SpawnTile(Random.Range(0, defaultTilePrefabs.Length));
                
            }
            
            RemoveTile();
            tileCount++;
        }
    }
    private void FixedUpdate() {
        
    }

    public void ToTrueAllFunc() {
        canSpawnSpiral = true;
        canSpawnLeftRight = true;
        canSpawnOther = true;
    }
    private void SpawnTile(int tileIndex) {
        GameObject nextTile =  Instantiate(defaultTilePrefabs[tileIndex], transform.forward * spawnPos, transform.rotation);
        

        activeTiles.Add(nextTile);
        spawnPos += tileLenght;
    }
    private void SpawnStartTile(int tileIndex) {
        GameObject nextTile =  Instantiate(startTilePrefabs[tileIndex], transform.forward * spawnPos, transform.rotation);

        activeTiles.Add(nextTile);
        spawnPos += tileLenght;
    }
    
    public void SpawnSpiral() {
        for (int i = 0; i < spiralTilePrefabs.Length; i++) {
            GameObject nextTile = Instantiate(spiralTilePrefabs[i], transform.forward * spawnPos, transform.rotation);

            activeTiles.Add(nextTile);

            spawnPos += tileLenght;
        }
        canSpawnSpiral = false;
    }

    public void SpawnLeftRight() {
        for (int i = 0; i < LeftRightTilePrefabs.Length; i++) {
            GameObject nextTile = Instantiate(LeftRightTilePrefabs[i], transform.forward * spawnPos, transform.rotation);

            activeTiles.Add(nextTile);

            spawnPos += tileLenght;
        }
        canSpawnLeftRight = false;
    }
    public void SpawnOtherSpiral() {
        for (int i = 0; i < OtherSpiralTilePrefabs.Length; i++) {
            GameObject nextTile = Instantiate(OtherSpiralTilePrefabs[i], transform.forward * spawnPos, transform.rotation);

            activeTiles.Add(nextTile);

            spawnPos += tileLenght;
        }
        canSpawnOther = false;
    }

    private void RemoveTile() {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
