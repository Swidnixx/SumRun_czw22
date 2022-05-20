using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScroller : MonoBehaviour
{
    public Transform floor1;
    public Transform floor2;

    public GameObject[] tiles;

    private float speed;

    private void FixedUpdate()
    {
        speed = GameManager.instance.worldScrollingSpeed;

        floor1.position -= new Vector3(speed, 0, 0);
        floor2.position -= new Vector3(speed, 0, 0);

        if(floor2.position.x <= 0)
        {
            GameObject tileToCreate = tiles[Random.Range(0, tiles.Length)];
            Transform newTile = Instantiate( 
                tileToCreate, floor2.position +
                    new Vector3(20f, 0, 0),
                Quaternion.identity
                ).transform;

            Destroy( floor1.gameObject );
            floor1 = floor2;
            floor2 = newTile;
        }
    }

}
