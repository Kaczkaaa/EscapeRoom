
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false; //zmienna do sprawdzania czy gra jest zastopowana
    public GameObject pauseMenuUi; //potrzebujemy referencji do gameobjectu na scenie
    public ScriptableObjectBool isGamePause;
    private float velocity;
    

    void Awake()
    {
         pauseMenuUi.SetActive(false);
         isGamePause.value = false;
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)) //kiedy gracz wciśnie escape
        {
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
            isGamePause.value = false;
            pauseMenuUi.SetActive(false); //dzięki temu możemy wyłączyć GameObject na scenie
            Time.timeScale = 1f; //prędkość gry równy 1 znaczy czas rzeczywisty
            gameIsPaused = false; //nasza zmienna jest fałszywa = gra nie jest zastopowana
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Pause()
        {
            isGamePause.value = true;
            pauseMenuUi.SetActive(true); //dzięki temu możemy włączyć GameObject na scenie
            Time.timeScale = 0f; //zatrzymujemy czas gry w tle, ustawiając jej prędkość na zero
            gameIsPaused = true; //nasza zmienna jest prawdziwa = gra jest zastopowana
            Cursor.lockState = CursorLockMode.None;
        }
        public void LoadMenu()//metoda do załączania Menu 
        {
            Time.timeScale=1f;
            SceneManager.LoadScene(0); //ładuje się scena z indeksem odpowiadającym liczbie
        }
        public void QuitGame()//metoda do wyłączania gry
        {
            Application.Quit(); //aplikacja się wyłącza
        }

    
}
