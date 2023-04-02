using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatCtrl : MonoBehaviour
{
    public float Speed = 2f;

    //rat Y position will be stratified (integer values from -4 to +4)
    const int maxY = 4;
    const int minY = -4;

    //rat X position min and max values are just outside the visible area
    const float minX = -9;
    const float maxX = 9;

    //int YPos = 0;
    //float XPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        ResetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Speed*Time.deltaTime, 0f, 0f);
        if (transform.position.x > maxX)
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        var ypos = Random.Range(minY, maxY + 1);
        transform.position = new Vector2(minX, ypos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            collision.gameObject.GetComponent<FoodCtrl>().Place();
            transform.localScale = transform.localScale * 1.1f;
        }
    }

}
