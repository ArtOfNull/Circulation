using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotScript : MonoBehaviour
{
    public bool partOnLevel;
    bool fullOnLevel;
    public Vector3[] edgePoints;
    float _colRad;
    public bool isOnLevel => CheckIfOnLevel();
    // Start is called before the first frame update

    private void Awake()
    {
        _colRad = GetComponent<CircleCollider2D>().radius;
        SetupEdge();
    }


    // Update is called once per frame
    void Update()
    {
        print(isOnLevel);
    }

    private void SetupEdge()
    {
        edgePoints = new Vector3[9];
        edgePoints[0] = Vector3.zero;
        for (int i = 1; i < edgePoints.Length; i++)
        {
            var degree = (i - 1) * 45f;
            var x = _colRad * Mathf.Cos(degree * Mathf.Deg2Rad);
            var y = _colRad * Mathf.Sin(degree * Mathf.Deg2Rad);
            edgePoints[i] = new Vector3(x, y);
        }
    }

    private bool CheckIfOnLevel()
    {
        foreach (var edgePoint in edgePoints)
        {
            Vector3 poiToCheck = transform.position + edgePoint;
            Collider2D pathCol = Physics2D.OverlapPoint(poiToCheck, 1 << 3);
            if (pathCol == null)
            {
                return false;
            }
        }
        return true;
    }
}
