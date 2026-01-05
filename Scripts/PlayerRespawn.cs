using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Transform checkpoint;

    public void SetCheckpoint(Transform point)
    {
        checkpoint = point;
    }

    public void Respawn(GameObject kart)
    {
        if (checkpoint == null) return;

        kart.transform.position = checkpoint.position;
        kart.transform.rotation = checkpoint.rotation;
        kart.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
