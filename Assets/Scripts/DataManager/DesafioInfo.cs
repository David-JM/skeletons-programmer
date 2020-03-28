using UnityEngine;
using System.Collections;

namespace DataManager
{
	public class DesafioInfo
	{
		private string descripcion;
		private bool superado;
		private int intentos;
		
		public DesafioInfo(string descripcion, bool superado, int intentos)
		{
			Descripcion = descripcion;
			Superado = superado;
			Intentos = intentos;
		}
		
		public string Descripcion{ get; set; }
		public bool Superado{ get; set; }
		public int Intentos{ get; set; }
		
	}
}