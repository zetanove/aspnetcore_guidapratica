﻿namespace TodoWebApp.Models
{
	public class Todo
	{
		public int Id { get; set; }
		public string Titolo { get; set; }
		public string Descrizione { get; set; }
		public DateTime Promemoria { get; set; }
		public bool Completato { get; set; }
	}

}
