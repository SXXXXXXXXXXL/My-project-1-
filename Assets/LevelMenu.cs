using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Pastikan Anda mengimpor namespace UI untuk menggunakan Button

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 0);

        // Pastikan semua tombol tidak dapat diklik
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        // Aktifkan tombol hingga level yang terbuka
        for (int i = 0; i < unlockedLevel; i++)
        {
            if (i < buttons.Length)  // Pastikan indeks tidak melebihi panjang array
            {
                buttons[i].interactable = true;
            }
        }
    }

    public void OpenLevel(int levelId)
    {
        SceneManager.LoadScene(levelId);
    }
}
