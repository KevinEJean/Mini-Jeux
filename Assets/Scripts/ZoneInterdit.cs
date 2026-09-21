using System;
using UnityEngine;

public class ZoneInterdit : MonoBehaviour
{
    [SerializeField] private Transform spawn;

    private void OnTriggerEnter2D(Collider2D autre)
    {
        if (!autre.CompareTag("Player"))
            return;

        if (spawn == null)
        {
            Debug.LogError("Spawn not assigned");
            return;
        }

        autre.transform.position = spawn.position;
        Debug.Log("Player returned to spawn.");
    }
}
