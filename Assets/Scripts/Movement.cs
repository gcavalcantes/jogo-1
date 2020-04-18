using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject destination;
    public GameObject handWithChalk;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveHand();
    }

    void moveHand()
    {
        // Vector2.MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta);
        Vector2 dest = new Vector2(destination.transform.position.x, destination.transform.position.y-30);
        handWithChalk.transform.position = Vector2.MoveTowards(handWithChalk.transform.position, dest, 4.0f);
    }
}
