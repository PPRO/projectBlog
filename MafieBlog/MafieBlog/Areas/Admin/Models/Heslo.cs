using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace MafieBlog.Areas.Admin.Models
{
	public static class Heslo
	{
		
		public static string NoveHeslo(string message)
		{
			SHA256 sha = new SHA256CryptoServiceProvider();
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes(message);
			byte[] byteHas = sha.ComputeHash(bytes);
			

			return Convert.ToBase64String(byteHas);
		}

		public static string Zkouska(byte[] message)
		{
			string base64 = Convert.ToBase64String(message);
			
			return base64;

		}

	}
}