using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DataManager
{
	public class PlayerInfo
	{
		private int prefab;
		private Color lightColor;
		private Sprite iconPlayer;
		private string playerName;
		private string rango;
		private string nivel;
		private int lifes;
		private int desafiosSuperados;
		private int logrosDesbloqueados;
		private Dictionary<int, DesafioInfo> desafios;
					

		public int Prefab{ get; set; }
		public Color LightColor{ get; set; }
		public Sprite IconPlayer{ get; set; }
		public string PlayerName{ get; set; }
		public string Rango{ get; set; }
		public string Nivel{ get; set; }
		public int Lifes{ get; set; }
		public int DesafiosSuperados{ get; set; }
		public int LogrosDesbloqueados{ get; set; }
		public Dictionary<int, DesafioInfo> Desafios{ get; set; }

	}
	
}