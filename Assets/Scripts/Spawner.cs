using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowsSpawner : MonoBehaviour
{
    public int LowsCount = 50;
    public GameObject LowsPrefab;
    public Vector2 minMaxXPos;
    

    private float zValue = 0f;

    private void Start()
    {
        for (int i = 0; i < LowsCount; i++)
        {
            Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(minMaxXPos.x, minMaxXPos.y), 1.08F, zValue + 260f);

            Instantiate(LowsPrefab, spawnPos, Quaternion.identity);
            zValue += 8f;
        }
    }
}
