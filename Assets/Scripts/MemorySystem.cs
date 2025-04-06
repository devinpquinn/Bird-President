using System.Collections.Generic;
using UnityEngine;

public class MemorySystem : MonoBehaviour
{
    public List<string> memory = new();

    public void ToggleMemory(string keyword)
    {
        if (memory.Contains(keyword))
            memory.Remove(keyword);
        else if (memory.Count < 3)
            memory.Add(keyword);
    }

    public bool IsInMemory(string keyword) => memory.Contains(keyword);
}
