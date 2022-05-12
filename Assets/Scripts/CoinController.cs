using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    Transform player;
    GameManager gm;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gm = GameManager.instance;
    }

    private void FixedUpdate()
    {
        if (gm == null || player == null) return;
        if (gm.magnet.isActive == false) return;

        if(Vector3.Distance(transform.position, player.position) < gm.magnet.range)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * gm.magnet.coinSpeed;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, gm.magnet.range);
    }
}
