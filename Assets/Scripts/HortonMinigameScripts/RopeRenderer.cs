using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField]
    private Transform startPos;
    private float lineWidth = 0.05f;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RenderLine(Vector3 endPos, bool enableRenderer)
    {
        if (enableRenderer)
        {
            if (!lineRenderer.enabled)
                lineRenderer.enabled = true;
            lineRenderer.positionCount = 2;
        }
        else
        {
            lineRenderer.positionCount = 0;
            if (lineRenderer.enabled)
                lineRenderer.enabled = false;
        }

        if (lineRenderer.enabled)
        {
            Vector3 temp = startPos.position;
            temp.z = -10f;

            startPos.position = temp;

            temp = endPos;
            temp.z = 0f;

            endPos = temp;

            lineRenderer.SetPosition(0, startPos.position);
            lineRenderer.SetPosition(1, endPos);
        }
    }

}
