using UnityEngine;

public class ChackPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<MavkaController>().chackPoint = transform.position;
        }
    }
}
