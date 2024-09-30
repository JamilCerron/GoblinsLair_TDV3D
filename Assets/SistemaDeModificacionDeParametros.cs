using TMPro;
using UnityEngine;

public class SistemaDeModificacionDeParametros : MonoBehaviour
{
    public FPScamera scriptCamara;
    public personaje_movimiento scriptJugador;
    public TextMeshProUGUI textoVelocidad;
    public TextMeshProUGUI textoSensibilidad;

    void Start()
    {
        ActualizarTextoVelocidad();
        ActualizarTextoSensibilidad();
        textoSensibilidad.text = scriptJugador.GetComponent<FPScamera>().sensibility.x.ToString();
        textoVelocidad.text = scriptJugador.GetComponent<personaje_movimiento>().speed.ToString();
    }

    public void AumentarVelocidad()
    {
        ModificarValoresJugador(1);
        ActualizarTextoVelocidad();
    }

    public void DisminuirVelocidad()
    {
        ModificarValoresJugador(-1);
        ActualizarTextoVelocidad();
    }

    public void AumentarSensibilidad()
    {
        ModificarValoresCamara(Vector2.one);
        ActualizarTextoSensibilidad();
    }

    public void DisminuirSensibilidad()
    {
        ModificarValoresCamara(-Vector2.one);
        ActualizarTextoSensibilidad();
    }

    public void ModificarValoresCamara(Vector2 cambio)
    {
        if (scriptCamara != null)
        {
            var camara = scriptCamara.GetComponent<FPScamera>();
            camara.sensibility += cambio;
            camara.sensibility = new Vector2(Mathf.Max(camara.sensibility.x, 1.5f), Mathf.Max(camara.sensibility.y, 1.5f)); // Restringir a valores mínimos de 1.5
        }
    }

    public void ModificarValoresJugador(float cambio)
    {
        if (scriptJugador != null)
        {
            var jugador = scriptJugador.GetComponent<personaje_movimiento>();
            jugador.speed += cambio;
            jugador.speed = Mathf.Max(jugador.speed, 1); // Restringir a valores mínimos de 1
        }
    }

    void ActualizarTextoVelocidad()
    {
        if (textoVelocidad != null && scriptJugador != null)
        {
            float velocidadActual = scriptJugador.GetComponent<personaje_movimiento>().speed;
            textoVelocidad.text = velocidadActual.ToString();
        }
    }

    void ActualizarTextoSensibilidad()
    {
        if (textoSensibilidad != null && scriptCamara != null)
        {
            Vector2 sensibilidadActual = scriptCamara.GetComponent<FPScamera>().sensibility;
            textoSensibilidad.text = sensibilidadActual.x.ToString();
        }
    }
}
