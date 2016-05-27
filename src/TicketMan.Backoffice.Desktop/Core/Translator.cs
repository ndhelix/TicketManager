using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Resources;

namespace TicketMan.Backoffice.Desktop.Core
{
	public static class EnumTranslator
	{
		static Hashtable ru, dict;
		static string separator = "***";

		public static string Translate(string type, string word)
		{
			if (dict == null)
				FillDictionary();
			Hashtable lng = (Hashtable)dict["ru"];
			string key =  type+separator+ word;
			if (lng[key] != null)
			return lng[key].ToString();
			else		return word;
		}

		static void FillDictionary()
		{
			string filebody = Properties.Resources.EnumDictionary;
			dict = new Hashtable();
			ru = new Hashtable();
			string[] s = { "\r\n" };
			foreach (string line in filebody.Split(s,StringSplitOptions.RemoveEmptyEntries))
			{
				string key =  line.Split("\t".ToCharArray())[0]+separator+ line.Split("\t".ToCharArray())[1] ;
				string value =  line.Split("\t".ToCharArray())[2] ;
				ru.Add(key, value);
			}
			dict.Add("ru", ru);
		}
	}
}
