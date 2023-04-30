
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false; //zmienna do sprawdzania czy gra jest zastopowana
    public GameObject pauseMenuUi; //potrzebujemy referencji do gameobjectu na scenie
    

    void Awake()
    {
         pauseMenuUi.SetActive(false);
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)) //kiedy gracz wciśnie escape
        {
            Debug.Log("Escape wciśnięty");
            if (gameIsPaused)//oraz gdy gra jest zastopowana
            {
                Resume(); //użyta zostaje metoda resume
            }
            else //jeśli nie
            {
                Pause(); // użyta jest metoda pause
            }
        }

    }

        public void Resume()
        {
            pauseMenuUi.SetActive(false); //dzięki temu możemy wyłączyć GameObject na scenie
            Time.timeScale = 1f; //prędkość gry równy 1 znaczy czas rzeczywisty
            gameIsPaused = false; //nasza zmienna jest fałszywa = gra nie jest zastopowana
        }

        void Pause()
        {
            pauseMenuUi.SetActive(true); //dzięki temu możemy włączyć GameObject na scenie
            Time.timeScale = 0f; //zatrzymujemy czas gry w tle, ustawiając jej prędkość na zero
            gameIsPaused = true; //nasza zmienna jest prawdziwa = gra jest zastopowana
        }
        public void LoadMenu()//metoda do załączania Menu 
        {
            Debug.Log("Ładuje się Menu");
            Time.timeScale=1f;
            SceneManager.LoadScene(1); //ładuje się scena z indeksem odpowiadającym liczbie
        }
        public void QuitGame()//metoda do wyłączania gry
        {
            Debug.Log("Wstaję, wychodzę");
            Application.Quit(); //aplikacja się wyłącza
        }

    
}
