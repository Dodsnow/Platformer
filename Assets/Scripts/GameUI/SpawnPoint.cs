using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] public GameObject enemyPrefab;
    private Vector2 spawnPosition;

    private void Awake()
    {
        enemyPrefab = GetComponent<GameObject>();
        spawnPosition = new Vector2();
    }
}