using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCode : MonoBehaviour
{
    private LineRenderer lineRenderer;

    public Transform origin;
    public Transform destination;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    private void Update()
    {
        HandleLineRendererPosition();
    }

    private void HandleLineRendererPosition()
    {
        lineRenderer.SetPosition(0, origin.transform.localPosition);
        lineRenderer.SetPosition(1, destination.transform.localPosition);
    }
}
