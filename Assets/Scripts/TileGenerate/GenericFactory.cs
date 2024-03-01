using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T[] _prefab;
    [SerializeField] private Transform _pointToSpawn;

    public T GetNewInstance() {
        Vector3 pos = _pointToSpawn.position;
        
        return Instantiate(_prefab[Random.Range(0, _prefab.Length)], pos, Quaternion.identity);
    }
    public T GetNewInstance2(int i) {
        Vector3 pos = _pointToSpawn.position;
        
        return Instantiate(_prefab[i], pos, Quaternion.identity);
    }
}
