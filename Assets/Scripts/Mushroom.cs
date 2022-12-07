using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    int hp = 2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Lily")
        {
            hp--;
            if (hp<= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
