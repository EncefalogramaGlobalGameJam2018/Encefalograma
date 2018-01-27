using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncefalogramaConstructor : MonoBehaviour {

    private float[] points = { 0.0f, -1f, 7f, 1f, -2f, -7f, 5f };
    private Vector3[] positions;
    private float intervalo = 0.3f;

    void Start()
    {

        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = points.Length;
        lineRenderer.widthMultiplier = 0.1f;

        positions = new Vector3[points.Length];

        for (int i = 0; i < points.Length; i++)
        {



            Vector3 position = new Vector3(transform.position.x + intervalo, transform.position.y + points[i], 0.0f);

            positions[i] = position;

            intervalo += intervalo;
        }

        lineRenderer.SetPositions(positions);
    }

    void Update()
    {

    }
}
