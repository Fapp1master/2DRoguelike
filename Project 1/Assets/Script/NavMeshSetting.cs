using NavMeshPlus.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshSetting : MonoBehaviour
{

    
    private void Start()
    {
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}
