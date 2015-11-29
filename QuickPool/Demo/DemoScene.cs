﻿using UnityEngine;
using System.Collections;
using QuickPool;

[RequireComponent(typeof(ObjectsPool))]
public class DemoScene : MonoBehaviour 
{
    private ObjectsPool poolObj;
    public GameObject[] prefabs;

    private void Start()
    {
        poolObj = ObjectsPool.Instance;
        StartCoroutine(RandomSpawning());
    }

    private void OnGUI()
    {
        GUILayout.BeginVertical(GUI.skin.box, GUILayout.Width(200));
        foreach(var pool in poolObj.pools)
        {
            GUILayout.Label("Spawned: " + pool.spawnedCount + "/" + pool.totalCount);
        }
        if (GUILayout.Button("Despawn all"))
            ObjectsPool.DespawnAll();
        GUILayout.EndVertical();
    }

    private IEnumerator RandomSpawning()
    {
        while(true)
        {
            for (int i = 0; i < prefabs.Length; i++ )
            {
                Vector3 randomPos = Random.insideUnitSphere * 10;
                prefabs[i].Spawn(randomPos, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
