using UnityEngine;
using System.Collections;
using CommonsGame;

namespace DataManager
{
	public class PlayerInfoManager
	{
		private PlayerInfo playerInfo;

		private static PlayerInfoManager instance;
		public static PlayerInfoManager Instance
		{
			get
			{
				if (instance == null){
					instance = new PlayerInfoManager ();
					instance.playerInfo = new PlayerInfo();
				}
				return instance;
			}
		}

		public WWW ValidaConectar(string userName, string password)
		{
			WWWForm form = new WWWForm ();
			form.AddField ("myform_hash", Commons.gameHashCode);
			form.AddField ("myform_user", userName);
			form.AddField ("myform_pass", password);
			form.AddBinaryData ("binary", new byte[1]);
			return new WWW (Commons.urlLogin, form);
		}
		
		public string Conectar(WWW login)
		{
			string mensaje = "";
			if (login.error != null) {
				mensaje = login.error;
			} else {
				string[] datos = login.text.Split("-" [0]);
				if(datos.Length>1){
					playerInfo = new PlayerInfo ();
					playerInfo.PlayerName = datos[0];
					playerInfo.Nivel = datos[1];
					playerInfo.Rango = datos[2];
					playerInfo.Lifes = 3;
					mensaje = Commons.msgTrue;
				}else{
					mensaje = datos[0];
				}
				login.Dispose();
			}
			return mensaje;
		}

		public WWW ValidaRegistrar(string userName, string password, string nivel)
		{
			WWWForm form = new WWWForm ();
			form.AddField ("myform_hash", Commons.gameHashCode);
			form.AddField ("myform_user", userName);
			form.AddField ("myform_pass", password);
			form.AddField ("myform_nivel", nivel);
			form.AddBinaryData ("binary", new byte[1]);
			return new WWW (Commons.urlRegister, form);
		}
		
		public string Registrar(WWW register)
		{
			string mensaje = "";
			if (register.error != null) {
				mensaje = register.error;
			} else {
				playerInfo = new PlayerInfo ();
				string[] datos = register.text.Split("-" [0]);
				mensaje = playerInfo.PlayerName = datos[0];
				if(datos.Length > 1){
					playerInfo.Nivel = datos[1];
					playerInfo.Rango = datos[2];
				}
				playerInfo.Lifes = 3;
				register.Dispose();
			}
			return mensaje;
		}

		public PlayerInfo getPlayer(){
			return playerInfo;
		}
	}
}