//VERTION 1
/* using UnityEngine;
using System.Collections;

public class BrainwaveController : MonoBehaviour
{
    private int connectionID = -1;

    void Start()
    {
        Debug.Log("Iniciando BrainwaveController...");
        ConnectToThinkGear();
    }

    void ConnectToThinkGear()
    {
        Debug.Log("Intentando conectar a ThinkGear...");
        connectionID = ThinkGear.TG_GetNewConnectionId();

        if (connectionID >= 0)
        {
            Debug.Log("ID de conexión obtenido: " + connectionID);
            int connectStatus = ThinkGear.TG_Connect(connectionID, "COM3", ThinkGear.BAUD_9600, ThinkGear.STREAM_PACKETS);

            if (connectStatus >= 0)
            {
                Debug.Log("Conectado exitosamente a ThinkGear.");
            }
            else
            {
                Debug.LogError("Error al conectar a ThinkGear. Código de estado: " + connectStatus);
            }
        }
        else
        {
            Debug.LogError("No se pudo obtener un ID de conexión válido.");
        }
    }

    void Update()
    {
        ReadBrainwaveData();
    }

    void ReadBrainwaveData()
    {
        if (connectionID >= 0)
        {
            int packetCount = ThinkGear.TG_ReadPackets(connectionID, -1);

            if (packetCount > 0)
            {
                Debug.Log("Paquetes recibidos: " + packetCount);
                float attention = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_ATTENTION);
                float meditation = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_MEDITATION);

                Debug.Log("Atención: " + attention);
                Debug.Log("Meditación: " + meditation);
            }
            else
            {
                Debug.LogWarning("No se recibieron paquetes de datos.");
            }
        }
        else
        {
            Debug.LogWarning("ID de conexión no válido. No se pueden leer datos.");
        }
    }
}
 */
//VERTION 2
/*  using UnityEngine;
using System.Collections;

public class BrainwaveController : MonoBehaviour
{
    private int connectionID = -1;
    private const string PORT_NAME = "COM3";

    void Start()
    {
        // Iniciar la conexión al iniciar el juego
        ConnectToThinkGear();
    }

    void ConnectToThinkGear()
    {
        // Generar un identificador para la conexión ThinkGear
        connectionID = ThinkGear.TG_GetNewConnectionId();

        if (connectionID >= 0)
        {
            // Establecer la conexión real usando el puerto COM3
            int connectStatus = ThinkGear.TG_Connect(connectionID, PORT_NAME, ThinkGear.BAUD_9600, ThinkGear.STREAM_PACKETS);

            if (connectStatus >= 0)
            {
                Debug.Log("Conectado exitosamente a ThinkGear.");
            }
            else
            {
                Debug.LogError($"Error al conectar a ThinkGear. Código de estado: {connectStatus}");
                ReconnectToThinkGear();
            }
        }
        else
        {
            Debug.LogError("No se pudo obtener un ID de conexión válido.");
        }
    }

    void Update()
    {
        // Leer datos en cada frame
        ReadBrainwaveData();
    }

    void ReadBrainwaveData()
    {
        if (connectionID >= 0)
        {
            int packetCount = ThinkGear.TG_ReadPackets(connectionID, -1);

            if (packetCount > 0)
            {
                float attention = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_ATTENTION);
                float meditation = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_MEDITATION);

                Debug.Log("Atención: " + attention);
                Debug.Log("Meditación: " + meditation);
            }
        }
    }

    public void ReconnectToThinkGear()
    {
        // Si ya estamos conectados, desconectamos primero
        if (connectionID >= 0)
        {
            ThinkGear.TG_FreeConnection(connectionID);
            Debug.Log("Desconectado de ThinkGear para reiniciar la conexión.");
        }

        // Espera un momento antes de intentar reconectar
        StartCoroutine(ReconnectAfterDelay());
    }

    IEnumerator ReconnectAfterDelay()
    {
        yield return new WaitForSeconds(1.0f);  // Espera 1 segundo
        ConnectToThinkGear();
    }
}
 */

 //VERTION 3
/* using UnityEngine;
using System.Collections;

public class BrainwaveController : MonoBehaviour
{
    private int connectionID = -1;
    private const string PORT_NAME = "COM3";

    void Start()
    {
        // Iniciar la conexión al iniciar el juego
        ConnectToThinkGear();
    }

    void ConnectToThinkGear()
    {
        // Generar un identificador para la conexión ThinkGear
        connectionID = ThinkGear.TG_GetNewConnectionId();

        if (connectionID >= 0)
        {
            // Establecer la conexión real usando el puerto COM3
            int connectStatus = ThinkGear.TG_Connect(connectionID, PORT_NAME, ThinkGear.BAUD_9600, ThinkGear.STREAM_PACKETS);

            if (connectStatus >= 0)
            {
                Debug.Log("Conectado exitosamente a ThinkGear.");
            }
            else
            {
                Debug.LogError($"Error al conectar a ThinkGear. Código de estado: {connectStatus}");
                ReconnectToThinkGear();
            }
        }
        else
        {
            Debug.LogError("No se pudo obtener un ID de conexión válido.");
        }
    }

    void Update()
    {
        // Leer datos en cada frame
        ReadBrainwaveData();
    }

    void ReadBrainwaveData()
    {
        if (connectionID >= 0)
        {
            int packetCount = ThinkGear.TG_ReadPackets(connectionID, -1);

            if (packetCount > 0)
            {
                float attention = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_ATTENTION);
                float meditation = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_MEDITATION);

                Debug.Log("Atención: " + attention);
                Debug.Log("Meditación: " + meditation);
            }
        }
    }

    public float GetMeditationValue()
    {
        if (connectionID >= 0)
        {
            return ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_MEDITATION);
        }
        else
        {
            Debug.LogError("No se pudo obtener el valor de meditación debido a un ID de conexión no válido.");
            return -1;  // Devuelve -1 para indicar un error
        }
    }

    public float GetAttentionValue()
    {
        if (connectionID >= 0)
        {
            return ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_ATTENTION);
        }
        else
        {
            Debug.LogError("No se pudo obtener el valor de atención debido a un ID de conexión no válido.");
            return -1;  // Devuelve -1 para indicar un error
        }
    }

    public void ReconnectToThinkGear()
    {
        // Si ya estamos conectados, desconectamos primero
        if (connectionID >= 0)
        {
            ThinkGear.TG_FreeConnection(connectionID);
            Debug.Log("Desconectado de ThinkGear para reiniciar la conexión.");
        }

        // Espera un momento antes de intentar reconectar
        StartCoroutine(ReconnectAfterDelay());
    }

    IEnumerator ReconnectAfterDelay()
    {
        yield return new WaitForSeconds(1.0f);  // Espera 1 segundo
        ConnectToThinkGear();
    }
}
 */

 //Vertion 4

using UnityEngine;
using System.Collections;

public class BrainwaveController : MonoBehaviour
{
    private int connectionID = -1;
    private const string PORT_NAME = "COM3";

    // Variables para almacenar los valores de las ondas cerebrales y otros datos
    private float indexSignalIcons;
    private int PoorSignal;
    private int Attention;
    private int Meditation;
      private float Delta;
    private float Theta;


    void Start()
    {
        ConnectToThinkGear();
    }

    void ConnectToThinkGear()
    {
        connectionID = ThinkGear.TG_GetNewConnectionId();

        if (connectionID >= 0)
        {
            int connectStatus = ThinkGear.TG_Connect(connectionID, PORT_NAME, ThinkGear.BAUD_9600, ThinkGear.STREAM_PACKETS);

            if (connectStatus >= 0)
            {
                Debug.Log("Conectado exitosamente a ThinkGear.");
            }
            else
            {
                Debug.LogError($"Error al conectar a ThinkGear. Código de estado: {connectStatus}");
                ReconnectToThinkGear();
            }
        }
        else
        {
            Debug.LogError("No se pudo obtener un ID de conexión válido.");
        }
    }

    void Update()
    {
        ReadBrainwaveData();
    }

    void ReadBrainwaveData()
    {
        if (connectionID >= 0)
        {
            int packetCount = ThinkGear.TG_ReadPackets(connectionID, -1);

            if (packetCount > 0)
            {
                // Leer y almacenar los valores de las ondas cerebrales y otros datos
                Attention = (int)ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_ATTENTION);
                Meditation = (int)ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_MEDITATION);              
                Delta = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_DELTA);
                Theta = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_THETA);               
                // Imprimir algunos valores para depuración
                Debug.Log($"Atención: {Attention}, Meditación: {Meditation}, Delta: {Delta}, Theta: {Theta}");
            }
        }
    }

    // Funciones para obtener los valores de las ondas cerebrales y otros datos
    public int GetAttentionValue() => Attention;
    public int GetMeditationValue() => Meditation;
    //public float GetAlphaValue() => Alpha;
    public float GetDeltaValue() => Delta;
    public float GetThetaValue() => Theta;   
    // Aquí puedes agregar más funciones getter si es necesario

    public void ReconnectToThinkGear()
    {
        if (connectionID >= 0)
        {
            ThinkGear.TG_FreeConnection(connectionID);
            Debug.Log("Desconectado de ThinkGear para reiniciar la conexión.");
        }

        StartCoroutine(ReconnectAfterDelay());
    }

    IEnumerator ReconnectAfterDelay()
    {
        yield return new WaitForSeconds(1.0f);
        ConnectToThinkGear();
    }
}