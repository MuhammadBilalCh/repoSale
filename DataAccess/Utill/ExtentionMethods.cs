using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace DataAccess.Utill
{
	public static class ExtentionMethods
	{
		public static string ToDetailString(this Exception ex)
		{
			var message = new StringBuilder();

			while (ex != null)
			{
				message.AppendLine(string.Format("Message: {0}", ex.Message));
				message.AppendLine(string.Format("Stace Trace: {0}", ex.StackTrace));

				ex = ex.InnerException;
			}

			return message.ToString();
		}

        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }
    }


}
