using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{
    [SerializeField] int numOfSteps;
    [Space]
    [SerializeField] Transform[] vertexes;
    [SerializeField] Transform first;
    [SerializeField] GameObject dot;
    [SerializeField] TextMeshProUGUI numOfDotsTxt;
    Vector2 lastStepPos;
    Vector2 lastVertex;
    Vector2 newPos;

    IEnumerator Start()
    {
        lastStepPos = first.position;
        lastVertex = vertexes[Random.Range(0, vertexes.Length)].position;
        yield return new WaitForSeconds(1);
        for (int i = 0; i <= numOfSteps; i++) {

            //find a point between vertex and last point
            newPos = (lastStepPos + lastVertex) / 2;

            //instantiate new dot
            Instantiate(dot, newPos, Quaternion.identity, transform);

            //pick new points
            lastStepPos = newPos;
            lastVertex = vertexes[Random.Range(0, vertexes.Length)].position;

            //set text
            numOfDotsTxt.text = "DOTS: " + (i).ToString();

            //delay it a bit 
            if (i < 0.05f * numOfSteps) yield return new WaitForEndOfFrame();
            else if (i < .3f * numOfSteps) {
                if (i % 50 == 0) yield return new WaitForEndOfFrame();
            } else {
                if (i % 200 == 0) yield return new WaitForEndOfFrame();
            }
        }
    }
}
