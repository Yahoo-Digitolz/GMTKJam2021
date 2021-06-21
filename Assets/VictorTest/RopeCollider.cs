using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCollider : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private MeshCollider _meshCollider;
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _meshCollider = GetComponent<MeshCollider>();
    }

    private void Update()
    {
        Mesh _lineMesh = new Mesh();
        _lineRenderer.BakeMesh(_lineMesh, true);
        _meshCollider.sharedMesh = _lineMesh;
    }
}
