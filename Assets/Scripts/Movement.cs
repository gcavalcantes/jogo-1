﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject expression;
    public GameObject destino;
    public GameObject handWithChalk;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveHandToExpression();
    }

    void moveHandToExpression()
    {
        // Vector2.MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta);
        Vector2 dest = new Vector2(destino.transform.position.x, destino.transform.position.y-30);
        handWithChalk.transform.position = Vector2.MoveTowards(handWithChalk.transform.position, dest, 10.0f);
    }
}