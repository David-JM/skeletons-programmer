using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DataManager
{
	public class AlgoritmoInfo
	{
		private int id;
		private string guia;
		private string algoritmo;
		private List<VariableAlgoritmo> variables;

		public int ID{ get; set; }
		public string Guia{ get; set; }
		public string Algoritmo{ get; set; }
		public List<VariableAlgoritmo> Variables{ get; set; }

	}

	public class VariableAlgoritmo
	{
		private string valor;
		private float posX;
		private float posY;

		public VariableAlgoritmo(string valor, float posX, float posY)
		{
			this.valor = valor;
			this.posX = posX;
			this.posY = posY;
		}

		public string getValor(){
			return valor;
		}
		public float getPosX(){
			return posX;
		}
		public float getPosY(){
			return posY;
		}

	}
}