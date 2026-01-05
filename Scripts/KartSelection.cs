using UnityEngine;
using UnityEngine.SceneManagement;
using KartGame;

namespace KartGame.UI
{
    public class KartSelection : MonoBehaviour
    {
        public GameObject[] karts;   // isi prefab kart
        private int currentIndex = 0;

    public int CurrentIndex
{
    get { return currentIndex; }
}


        void Start()
        {
            ShowKart();
        }

        void ShowKart()
        {
            for (int i = 0; i < karts.Length; i++)
            {
                karts[i].SetActive(i == currentIndex);
            }
        }

        public void NextKart()
        {
            currentIndex++;
            if (currentIndex >= karts.Length)
                currentIndex = 0;

            ShowKart();
        }

        public void PrevKart()
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = karts.Length - 1;

            ShowKart();
        }

        public void PlayGame()
        {
            PlayerPrefs.SetInt("SelectedKart", currentIndex);
            SceneManager.LoadScene("RaceScene");
        }
    }
}
