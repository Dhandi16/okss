using UnityEngine;

public class RespawnZone : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        PlayerRespawn respawn = other.GetComponent<PlayerRespawn>();

        if (respawn != null)
        {
            respawn.Respawn(other.gameObject);
        }
    }
}


}
