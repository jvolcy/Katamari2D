using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCtrl : MonoBehaviour
{
    public float lifeTimeSec = 10f;

    //food Y position will be stratified (integer values from -4 to +4)
    const int maxY = 4;
    const int minY = -4;

    //food X position min and max values are inside the play area
    const float minX = -7;
    const float maxX = 7;

    float expirationTime;

    // Start is called before the first frame update
    void Start()
    {
        Place();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > expirationTime) Place();
    }

    public void Place()
    {
        var xpos = Random.Range(minX, maxX);
        var ypos = Random.Range(minY, maxY + 1);
        transform.position = new Vector2(xpos, ypos);
        expirationTime = Time.time + lifeTimeSec;
    }
}
