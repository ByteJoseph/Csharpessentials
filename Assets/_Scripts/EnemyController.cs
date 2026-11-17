using System;
using Unity.Mathematics;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private int _enemyCount = 5;
    [SerializeField]
    private Transform _spawnTopLeft, _spawnTopRight, _spawnBottomLeft, _spawnBottomRight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i=0;i<_enemyCount;i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spanPosition = SelectRandomPosition();
        GameObject enemyObject 
            = Instantiate(_enemyPrefab, spanPosition,Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.OnDie += SpawnEnemy;
        }
    }

    private Vector3 SelectRandomPosition()
    {
        Transform selected = null;
        int randomValue = UnityEngine.Random.Range(0, 4);
        SpawnPointType spawnType = (SpawnPointType)randomValue; 
        switch(spawnType)
        {
            case SpawnPointType.TopLeft:
                selected = _spawnTopLeft;
                break;
            case SpawnPointType.TopRight:
                selected = _spawnTopRight;
                break;
            case SpawnPointType.BottomLeft:
                selected = _spawnBottomLeft;
                break;
            case SpawnPointType.BottomRight:
                selected = _spawnBottomRight;
                break;
            default:
                selected = _spawnTopLeft;
                break;
        }
        return selected.position + (Vector3)UnityEngine.Random.insideUnitCircle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public enum SpawnPointType
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }
}
