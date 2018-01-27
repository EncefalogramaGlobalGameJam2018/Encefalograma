using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncefalogramaConstructor : MonoBehaviour {

    private float[] points = {0f,-1f,7f,-4f,4f,-7f,5f,-10f,3f,-7f,5f,-3f,8f,1f,10f,-10f,2f,-8f,5f};
    private Vector3[] positions;
    private float intervalo = 1f;
    private float posX;

    void Start()
    {

        LineRenderer lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = points.Length;
        lineRenderer.widthMultiplier = 0.1f;

        positions = new Vector3[points.Length];

        posX = intervalo;

        float scale = (transform.lossyScale.y - 0.5f) / 2f;

        for (int i = 0; i < points.Length; i++)
        {
            float posY = points[i] * scale / 10;

            Vector3 position = new Vector3(transform.position.x + posX, transform.position.y + posY, 0.0f);

            positions[i] = position;

            posX += intervalo;
        }

        lineRenderer.SetPositions(positions);
    }
}
