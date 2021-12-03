using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorM : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imageMute;
    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 1.0f);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();
    }
    public void RevisarSiEstoyMute()
    {
        if (sliderValue == 0)
        {
            imageMute.enabled = true;
        }
        else
        {
            imageMute.enabled = false;
        }
    }

    public void CambiarScena(string nombre)
    {
        print("cambiando a la scena" + nombre);
        SceneManager.LoadScene(nombre);
    }

    public void salir()
    {
        print("Salir del juego");
        Application.Quit();
    }

    public void pauseButton()
    {
        Panel.SetActive(true);
        Time.timeScale = 0;
    }
    public void playButton()
    {
        Panel.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseButton();
        }
        if (Input.GetKey(KeyCode.F1))
        {
            playButton();
        }

    }

   
    

}
