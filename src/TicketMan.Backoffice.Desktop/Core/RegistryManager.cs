using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace TicketMan.Backoffice.Desktop.Core
{
	public class RegRecord
	{
		public string Code { get; set; }
		public string SiteSlug { get; set; }
		public string ApiKey { get; set; }
		public string Url { get; set; }
		public bool Deleted { get; set; }
	}

	public class RegistryData
	{
		public List<RegRecord> List { get; set; }
		public string DefaultSiteSlug { get; set; }

		public RegistryData()
		{
			List = new List<RegRecord>();
		}
	}

	public static class RegistryManager
	{
		public static string RegistryPath { get { return @"HKEY_CURRENT_USER\Software\TicketMan\BackOffice\Desktop"; } }
		public static string RegistryPathReg { get { return RegistryPath + @"\Registration"; } }

		public static void CreateRegistryKeyReg(string skey = null)
		{
			string strkey = RegistryPathReg.Replace(@"HKEY_CURRENT_USER\", "");
			if (skey != null)
				strkey += "\\" + skey;
			RegistryKey key = Registry.CurrentUser.OpenSubKey(strkey);
			if (key == null)
				key = Registry.CurrentUser.CreateSubKey(strkey);
		}

		public static void DeleteRegistryKeyReg(string skey)
		{
			string strkey = RegistryPathReg.Replace(@"HKEY_CURRENT_USER\", "");
  		strkey += "\\" + skey;
			RegistryKey key = Registry.CurrentUser.OpenSubKey(strkey);
			if (key != null)
				Registry.CurrentUser.DeleteSubKey(strkey);
		}

		public static bool RegistryIsWritten()
		{
			return
					 Registry.GetValue(RegistryPathReg, "DefaultSiteSlug", "").ToString() != "";
		}

		public static void UpdateData(RegistryData data)
		{
			Registry.SetValue(RegistryPathReg, "DefaultSiteSlug", data.DefaultSiteSlug);
			foreach (RegRecord rec in data.List)
				UpdateReg(rec);
		}

		public static void UpdateDefaultSiteSlug(string defaultSiteSlug)
		{
			Registry.SetValue(RegistryPathReg, "DefaultSiteSlug", defaultSiteSlug);
		}

		static void UpdateReg(RegRecord rec)
		{
			if (rec.Deleted)
				DeleteRegistryKeyReg(rec.Code);
			else
			{
				CreateRegistryKeyReg(rec.Code);
				Registry.SetValue(RegistryPathReg + "\\" + rec.Code, "ApiKey", rec.ApiKey);
				Registry.SetValue(RegistryPathReg + "\\" + rec.Code, "SiteSlug", rec.SiteSlug);
				Registry.SetValue(RegistryPathReg + "\\" + rec.Code, "Url", rec.Url);
			}
		}

		public static RegistryData GetData()
		{
			RegistryData registryData = new RegistryData();
			registryData.DefaultSiteSlug = Registry.GetValue(RegistryPathReg, "DefaultSiteSlug", "").ToString();
			foreach (string item in Registry.CurrentUser.OpenSubKey(RegistryPathReg.Replace(@"HKEY_CURRENT_USER\", "")).GetSubKeyNames().ToList())
			{
				RegRecord rec = new RegRecord();
				rec.Code = item;
				string regpath = RegistryPathReg + "\\" + rec.Code;
				rec.ApiKey = Registry.GetValue(regpath, "ApiKey", "").ToString();
				rec.SiteSlug = Registry.GetValue(regpath, "SiteSlug", "").ToString();
				rec.Url = Registry.GetValue(regpath, "Url", "").ToString();
				rec.Deleted = false;
				registryData.List.Add(rec);
			}
			return registryData;
		}

		internal static string GetLastLogin()
		{
			return Registry.GetValue(RegistryPathReg, "LastLogin", "").ToString();
		}

		internal static void SetLastLogin(string p)
		{
			Registry.SetValue(RegistryPathReg, "LastLogin", p);
		}

		internal static bool GetRememberPasswordCheck()
		{
			return Registry.GetValue(RegistryPathReg, "RememberPasswordCheck", "").ToString() == "1";
		}

		internal static void SetRememberPasswordCheck(bool p)
		{
			string regvalue = p ? "1" : "0";
			Registry.SetValue(RegistryPathReg, "RememberPasswordCheck", regvalue);
		}

		internal static string GetPassword()
		{
			string enc = Registry.GetValue(RegistryPathReg, "Password", "").ToString();
			return Crypto.DecryptStringAES(enc, null);
		}

		internal static void SetPassword(string p)
		{
			Registry.SetValue(RegistryPathReg, "Password", Crypto.EncryptStringAES(p, null));
		}
	}
}
