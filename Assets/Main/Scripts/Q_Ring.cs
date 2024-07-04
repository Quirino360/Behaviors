using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q_Ring : MonoBehaviour
{
    [SerializeField] public LineRenderer bigCircle;
    [SerializeField] public LineRenderer smallCircle;
    [SerializeField] public LineRenderer direction;
    [SerializeField] public LineRenderer speed;


    // Start is called before the first frame update
    void Start()
    {
        bigCircle.SetWidth(0.03f, 1.0f);
        smallCircle.SetWidth(0.03f, 1.0f);
        direction.SetWidth(0.03f, 1.0f);
        speed.SetWidth(0.03f, 1.0f);
    }

    float  radio = 1;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawCircle(LineRenderer lr, int steps, float radius)
    {
        lr.positionCount = steps;

        for (int i = 0; i < steps; i++) 
        {
            float circunferenceProgress = (float)i / steps;
            float currentRadian = circunferenceProgress * 2 * Mathf.PI;
            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);

            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currentPosition = new Vector3(x, y, 0);

            lr.SetPosition(i, currentPosition + transform.position);
        }
    }

    public void DrawLine(LineRenderer lr, Vector3 startPos, Vector3 finalPos)
    {
        Vector3[] positions = {startPos, finalPos };
        lr.SetPositions(positions);
    }
}
