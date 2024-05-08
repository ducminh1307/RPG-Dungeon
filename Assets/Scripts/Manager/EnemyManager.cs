using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    [field :SerializeField] public Transform enemiesParent { get; private set; }
    public bool isClearRoom;
    private int enemyCount;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else 
            instance = this;
        
    }

    private void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        isClearRoom = enemyCount == 0? true: false;
    }

    public void SetCountEnemy(int _enemyCount)
    {
        enemyCount = _enemyCount;
    }

    public void DegreeEnemy()
    {
        enemyCount--;
    }
}
