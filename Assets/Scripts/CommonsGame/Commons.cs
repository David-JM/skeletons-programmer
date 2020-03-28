using UnityEngine;
using System.Collections;

namespace CommonsGame
{
	public static class Commons
	{
		//Tags names
		public const string tagPlayer = "Player";
		public const string tagOtherMusic = "OtherMusic";
		public const string tagShield = "ShieldTrick";
		public const string tagIce1 = "Ice1";
		public const string tagIce2 = "Ice2";
		public const string tagCyclone = "CycloneTrick";
		public const string tagLavaHollow = "LavaHollow";
		public const string tagSkullHollow = "skullHollow";
		public const string tagMultiplayer = "MultiplayerManager";

		// Input
		public const string axisX = "Horizontal";
		public const string axisZ = "Vertical";

		// Animator controller and animations
		public const string animState = "animState";
		public const int SLEEPING = 6;
		public const int WALKING_UP = 5;
		public const int DEAD = 4;
		public const int FALLING_DOWN = 3;
		public const int WALK_BACK = 2;
		public const int RUN = 1;
		public const int IDDLE = 0;

		public const string isHidden = "isHidden";
		public const string isActive = "isActive";

		//Indices de las escenas o niveles del juego
		public const int sceneMenu = 0;
		public const int sceneIceMap = 1;
		public const int sceneEndGame = 2;

		//Aceso a la base de datos	
		public const string gameHashCode = "h4shM4z3";

		/*
		public const string urlLogin = "http://169.254.33.42/laberinto/login.php";
		public const string urlRegister = "http://169.254.33.42/laberinto/register.php";
		public const string urlLogros = "http://169.254.33.42/laberinto/guardarLogros.php";
		public const string urlDesafio = "http://169.254.33.42/laberinto/consultarDesafio.php";
		public const string urlGuardarPuntos = "http://169.254.33.42/laberinto/guardarPuntos.php";
		public const string urlAlgoritmo = "http://169.254.33.42/laberinto/consultarAlgoritmo.php";
		public const string urlVariables = "http://169.254.33.42/laberinto/consultarVariablesAlgoritmo.php";
		public const string urlConsultarConfigServer = "http://169.254.33.42/laberinto/consultarConfigServer.php";

		public const string urlLogin = "http://190.5.199.29:82/laberinto/login.php";
		public const string urlRegister = "http://190.5.199.29:82/laberinto/register.php";
		public const string urlLogros = "http://190.5.199.29:82/laberinto/guardarLogros.php";
		public const string urlDesafio = "http://190.5.199.29:82/laberinto/consultarDesafio.php";
		public const string urlGuardarPuntos = "http://190.5.199.29:82/laberinto/guardarPuntos.php";
		public const string urlAlgoritmo = "http://190.5.199.29:82/laberinto/consultarAlgoritmo.php";
		public const string urlVariables = "http://190.5.199.29:82/laberinto/consultarVariablesAlgoritmo.php";
		public const string urlConsultarConfigServer = "http://190.5.199.29:82/laberinto/consultarConfigServer.php";
		
		*/

		public const string urlLogin = "http://127.0.0.1/laberinto/login.php";
		public const string urlRegister = "http://127.0.0.1/laberinto/register.php";
		public const string urlLogros = "http://127.0.0.1/laberinto/guardarLogros.php";
		public const string urlDesafio = "http://127.0.0.1/laberinto/consultarDesafio.php";
		public const string urlGuardarPuntos = "http://127.0.0.1/laberinto/guardarPuntos.php";
		public const string urlAlgoritmo = "http://127.0.0.1/laberinto/consultarAlgoritmo.php";
		public const string urlVariables = "http://127.0.0.1/laberinto/consultarVariablesAlgoritmo.php";
		public const string urlConsultarConfigServer = "http://127.0.0.1/laberinto/consultarConfigServer.php";

		//Variables de red
		public static int numPlayers = 15;
		public static string portHades = "9595";
		public static string portShadow = "9095";
		public static string ipServer = "127.0.0.1";

		//Mensaje de exito consultas a la BD
		public const string msgTrue = "true";

		//Mensajes
		public const string msgFailedConection = "Conexión fallida";
		public const string msgLostConection = "Has perdido la conexión con el servidor";
		public const string msgServerFull = "Servidor lleno";

		//Niveles de jugadores
		public const string experto = "Experto";
		public const string novato = "Novato";

		//Enumerados 
		public enum Server {Shadow, Hades};
		public enum ModalWindow {MsgError, Loading};
	}
}