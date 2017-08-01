using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DataAccess.Utill
{
	public class Cryptography
	{
		public static string MD5(string value)
		{
			MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
			byte[] bs = System.Text.Encoding.UTF8.GetBytes(value);
			bs = x.ComputeHash(bs);
			System.Text.StringBuilder s = new System.Text.StringBuilder();
			foreach (byte b in bs)
			{
				s.Append(b.ToString("x2").ToLower());
			}
			string hashValue = s.ToString();
			return hashValue;
		}

		public static string GenerateRandomPassword(int passwordLength, int numSpecialChars)
		{
			string allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
			allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
			allowedChars += "1,2,3,4,5,6,7,8,9,0";

			if (numSpecialChars > 0)
				allowedChars += "_,!,@,#,$,%,&,?";

			char[] sep = {','};
			string[] allowedCharArray = allowedChars.Split(sep);

			string passwordString = "";

			string temp = "";

			Random rand = new Random();
			for (int i = 0; i < passwordLength; i++)
			{
				temp = allowedCharArray[rand.Next(0, allowedCharArray.Length)];
				passwordString += temp;
			}
			return passwordString;
		}

		private static byte[] _keyByte = {};
		//Default Key
		//private static string _key = "Pass@123#";
		private static string _key = "v%8DmJ*#dG";
		//Default initial vector
		private static byte[] _ivByte = {0x01, 0x12, 0x23, 0x34, 0x45, 0x56, 0x67, 0x78};
		//Encryption Password
		//private static string Password = "aWMnVOGpjdBZ";
		//private static string Password = "aW$nVG*jBZ";
		private static readonly string Password = ConfigurationManager.AppSettings["EncryptionKey"];

		/// <summary> 
		/// Encrypt text 
		/// </summary> 
		/// <param name="value">plain text</param> 
		/// <returns>encrypted text</returns> 
		public static string Encrypt(string value)
		{
			return Encrypt(value, Password);
		}

		/// <summary> 
		/// Encrypt text by key 
		/// </summary> 
		/// <param name="value">plain text</param> 
		/// <param name="key"> string key</param> 
		/// <returns>encrypted text</returns> 
		public static string Encrypt(string value, string key)
		{
			return Encrypt(value, key, string.Empty);
		}

		/// <summary> 
		/// Encrypt text by key with initialization vector 
		/// </summary> 
		/// <param name="value">plain text</param> 
		/// <param name="key"> string key</param> 
		/// <param name="iv">initialization vector</param> 
		/// <returns>encrypted text</returns> 
		public static string Encrypt(string value, string key, string iv)
		{
			string encryptValue = string.Empty;
			MemoryStream ms = null;
			CryptoStream cs = null;
			if (!string.IsNullOrEmpty(value))
			{
				try
				{
					if (!string.IsNullOrEmpty(key))
					{
						_keyByte = Encoding.UTF8.GetBytes
							(key.Substring(0, 8));
						if (!string.IsNullOrEmpty(iv))
						{
							_ivByte = Encoding.UTF8.GetBytes
								(iv.Substring(0, 8));
						}
					}
					else
					{
						_keyByte = Encoding.UTF8.GetBytes(_key);
					}
					using (DESCryptoServiceProvider des =
						new DESCryptoServiceProvider())
					{
						byte[] inputByteArray =
							Encoding.UTF8.GetBytes(value);
						ms = new MemoryStream();
						cs = new CryptoStream(ms, des.CreateEncryptor
						                          	(_keyByte, _ivByte), CryptoStreamMode.Write);
						cs.Write(inputByteArray, 0, inputByteArray.Length);
						cs.FlushFinalBlock();
						encryptValue = Convert.ToBase64String(ms.ToArray());
					}
				}
				catch
				{
					//TODO: write log 
				}
				finally
				{
					if (cs != null)
						cs.Dispose();
					if (ms != null)
						ms.Dispose();
				}
			}
			return encryptValue;
		}

		/// <summary> 
		/// Decrypt text 
		/// </summary> 
		/// <param name="value">encrypted text</param> 
		/// <returns>plain text</returns> 
		public static string Decrypt(string value)
		{
			return Decrypt(value, Password);
		}

		/// <summary> 
		/// Decrypt text by key 
		/// </summary> 
		/// <param name="value">encrypted text</param> 
		/// <param name="key">string key</param> 
		/// <returns>plain text</returns> 
		public static string Decrypt(string value, string key)
		{
			return Decrypt(value, key, string.Empty);
		}

		/// <summary> 
		/// Decrypt text by key with initialization vector 
		/// </summary> 
		/// <param name="value">encrypted text</param> 
		/// <param name="key"> string key</param> 
		/// <param name="iv">initialization vector</param> 
		/// <returns>encrypted text</returns> 
		public static string Decrypt(string value, string key, string iv)
		{
			string decrptValue = string.Empty;
			if (!string.IsNullOrEmpty(value))
			{
				MemoryStream ms = null;
				CryptoStream cs = null;
				value = value.Replace(" ", "+");
				byte[] inputByteArray = new byte[value.Length];
				try
				{
					if (!string.IsNullOrEmpty(key))
					{
						_keyByte = Encoding.UTF8.GetBytes
							(key.Substring(0, 8));
						if (!string.IsNullOrEmpty(iv))
						{
							_ivByte = Encoding.UTF8.GetBytes
								(iv.Substring(0, 8));
						}
					}
					else
					{
						_keyByte = Encoding.UTF8.GetBytes(_key);
					}
					using (DESCryptoServiceProvider des =
						new DESCryptoServiceProvider())
					{
						inputByteArray = Convert.FromBase64String(value);
						ms = new MemoryStream();
						cs = new CryptoStream(ms, des.CreateDecryptor
						                          	(_keyByte, _ivByte), CryptoStreamMode.Write);
						cs.Write(inputByteArray, 0, inputByteArray.Length);
						cs.FlushFinalBlock();
						Encoding encoding = Encoding.UTF8;
						decrptValue = encoding.GetString(ms.ToArray());
					}
				}
				catch
				{
					//TODO: write log 
				}
				finally
				{
					if (cs != null)
						cs.Dispose();
					if (ms != null)
						ms.Dispose();
				}
			}
			return decrptValue;
		}

		/// <summary> 
		/// Compute Hash 
		/// </summary> 
		/// <param name="plainText">plain text</param> 
		/// <param name="salt">salt string</param> 
		/// <returns>string</returns> 
		public static string ComputeHash(string plainText, string salt)
		{
			return ComputeHash(plainText, salt, HashName.MD5);
		}

		/// <summary> 
		/// Compute Hash 
		/// </summary> 
		/// <param name="plainText">plain text</param> 
		/// <param name="salt">salt string</param> 
		/// <param name="hashName">Hash Name</param> 
		/// <returns>string</returns> 
		public static string ComputeHash(string plainText, string salt, HashName hashName)
		{
			if (!string.IsNullOrEmpty(plainText))
			{
				// Convert plain text into a byte array. 
				byte[] plainTextBytes = ASCIIEncoding.ASCII.GetBytes(plainText);
				// Allocate array, which will hold plain text and salt. 
				byte[] plainTextWithSaltBytes = null;
				byte[] saltBytes;
				if (!string.IsNullOrEmpty(salt))
				{
					// Convert salt text into a byte array. 
					saltBytes = ASCIIEncoding.ASCII.GetBytes(salt);
					plainTextWithSaltBytes =
						new byte[plainTextBytes.Length + saltBytes.Length];
				}
				else
				{
					// Define min and max salt sizes. 
					int minSaltSize = 4;
					int maxSaltSize = 8;
					// Generate a random number for the size of the salt. 
					Random random = new Random();
					int saltSize = random.Next(minSaltSize, maxSaltSize);
					// Allocate a byte array, which will hold the salt. 
					saltBytes = new byte[saltSize];
					// Initialize a random number generator. 
					RNGCryptoServiceProvider rngCryptoServiceProvider =
						new RNGCryptoServiceProvider();
					// Fill the salt with cryptographically strong byte values. 
					rngCryptoServiceProvider.GetNonZeroBytes(saltBytes);
				}
				// Copy plain text bytes into resulting array. 
				for (int i = 0; i < plainTextBytes.Length; i++)
				{
					plainTextWithSaltBytes[i] = plainTextBytes[i];
				}
				// Append salt bytes to the resulting array. 
				for (int i = 0; i < saltBytes.Length; i++)
				{
					plainTextWithSaltBytes[plainTextBytes.Length + i] =
						saltBytes[i];
				}
				HashAlgorithm hash = null;
				switch (hashName)
				{
					case HashName.SHA1:
						hash = new SHA1Managed();
						break;
					case HashName.SHA256:
						hash = new SHA256Managed();
						break;
					case HashName.SHA384:
						hash = new SHA384Managed();
						break;
					case HashName.SHA512:
						hash = new SHA512Managed();
						break;
					case HashName.MD5:
						hash = new MD5CryptoServiceProvider();
						break;
				}
				// Compute hash value of our plain text with appended salt. 
				byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);
				// Create array which will hold hash and original salt bytes. 
				byte[] hashWithSaltBytes =
					new byte[hashBytes.Length + saltBytes.Length];
				// Copy hash bytes into resulting array. 
				for (int i = 0; i < hashBytes.Length; i++)
				{
					hashWithSaltBytes[i] = hashBytes[i];
				}
				// Append salt bytes to the result. 
				for (int i = 0; i < saltBytes.Length; i++)
				{
					hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];
				}
				// Convert result into a base64-encoded string. 
				string hashValue = Convert.ToBase64String(hashWithSaltBytes);
				// Return the result. 
				return hashValue;
			}
			return string.Empty;
		}

		/// <summary> 
		/// Hash enum value 
		/// </summary> 
		public enum HashName
		{
			SHA1 = 1,
			MD5 = 2,
			SHA256 = 4,
			SHA384 = 8,
			SHA512 = 16
		}
	}
}