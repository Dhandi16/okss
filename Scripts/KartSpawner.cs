using UnityEngine;
using Cinemachine;

public class KartSpawner : MonoBehaviour
{
    public GameObject[] kartPrefabs;
    public Transform spawnPoint;
    public CinemachineVirtualCamera vcam;

    void Start()
{
    int selectedKart = PlayerPrefs.GetInt("SelectedKart", 0);

    GameObject kart = Instantiate(
        kartPrefabs[selectedKart],
        spawnPoint.position,
        spawnPoint.rotation
    );

    vcam.Follow = kart.transform;
    vcam.LookAt = kart.transform;
}



}
