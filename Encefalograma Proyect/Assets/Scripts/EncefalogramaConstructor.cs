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

        set(lineRenderer);

        positions = new Vector3[points.Length];

        fillPositionsWithPositionCalculatedFromPoints();

        lineRenderer.SetPositions(positions);
    }

    private void set(LineRenderer lineRenderer)
    {
        lineRenderer.positionCount = points.Length;
        lineRenderer.widthMultiplier = 0.1f;
    }

    private void fillPositionsWithPositionCalculatedFromPoints()
    {
        for (int i = 0; i < points.Length; i++)
        {

            Vector3 position = new Vector3(transform.position.x + intervalo, transform.position.y + points[i], 0.0f);

            positions[i] = position;

            intervalo += intervalo;
        }
    }
}
