using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    private HashSet<string> keys = new HashSet<string>();

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddKey(string keyName)
    {
        keys.Add(keyName);
        Debug.Log("Key added: " + keyName);
    }

    public bool HasKey(string keyName)
    {
        return keys.Contains(keyName);
    }
}