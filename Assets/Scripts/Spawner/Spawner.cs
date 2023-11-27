using System.Collections;
using System.Linq;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Mover[] _moverObjectTemplates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private GameObject[] _spawnableObjects;
    private Coroutine _spawn;

    private void Start()
    {
        _spawnableObjects = _moverObjectTemplates.Select(spawnableObject => spawnableObject.gameObject).ToArray();
        Initialize(_spawnableObjects);

        if (_spawn != null)
            StopCoroutine(_spawn);

        _spawn = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var waitForNewSpawn = new WaitForSeconds(_secondsBetweenSpawn);

        while (Time.timeScale != 0)
        {
            if (TryGetObject(out GameObject spawnableObject))
            {
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetSpawnableObject(spawnableObject, _spawnPoints[spawnPointNumber].position);
            }

            yield return waitForNewSpawn;
        }
    }

    private void SetSpawnableObject(GameObject spawnableObject, Vector3 spawnPoint)
    {
        spawnableObject.gameObject.SetActive(true);
        spawnableObject.transform.position = spawnPoint;
    }
}