using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MapDatabase : ScriptableObject
{
    public Map[] maps;

    public int MapCount
    {
        get
        {
            return maps.Length;
        }
    }

    public Map GetMap(int index)
    {
        return maps[index];
    }
}
