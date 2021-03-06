﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncefalogramaConstructor : MonoBehaviour {

    private float[] points = {0f,-5f,7f,-4f,4f,-7f,5f,-10f,3f,-7f,5f,-3f,8f,1f,10f,-10f,2f,-8f,5f,-9f, 0f,0f,0f,-10f,10f,-3f,8f,-1f};

    private Vector3[] positions;
    private Vector2[] edges;
    private float intervalo = 1.3f;
    private float posX;

    public GameObject finalTrigger;

    void Start()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();

        lineRenderer.positionCount = points.Length;
        lineRenderer.widthMultiplier = 0.1f;

        positions = new Vector3[points.Length];
        edges = new Vector2[points.Length];

        posX = intervalo;

        float scale = (transform.lossyScale.y - 0.4f) / 2f;

        for (int i = 0; i < points.Length; i++)
        {
            float posY = points[i] * scale / 10;

            Vector3 position = new Vector3(transform.position.x + posX, transform.position.y + posY, lineRenderer.transform.position.z);

            Vector2 edge = transform.InverseTransformPoint(new Vector2(transform.position.x + posX, transform.position.y + posY));

            positions[i] = position;

            edges[i] = edge;

            posX += intervalo;
        }

        Instantiate(finalTrigger, new Vector3(transform.position.x + posX, transform.position.y, transform.position.z),transform.rotation);

        lineRenderer.SetPositions(positions);

        edgeCollider.points = edges;
    }
}
