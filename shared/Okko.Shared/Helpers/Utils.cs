using Microsoft.AspNetCore.Mvc.ApiExplorer;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web;

namespace Okko.Shared.Helpers
{

    public static class Utils
    {
        public enum NLogType
        {
            Info,
            Warn,
            Error,
            Debug,
            Trace,
            Fatal
        }

        public static void NLogMessage(Type declaringType, string text, NLogType messageType)
        {
            switch (messageType)
            {
                case NLogType.Info:
                    LogManager.GetLogger(declaringType.FullName).Info(text);
                    break;
                case NLogType.Warn:
                    LogManager.GetLogger(declaringType.FullName).Warn(text);
                    break;
                case NLogType.Error:
                    LogManager.GetLogger(declaringType.FullName).Error(text);
                    break;
                case NLogType.Debug:
                    LogManager.GetLogger(declaringType.FullName).Debug(text);
                    break;
                case NLogType.Trace:
                    LogManager.GetLogger(declaringType.FullName).Trace(text);
                    break;
                case NLogType.Fatal:
                    LogManager.GetLogger(declaringType.FullName).Fatal(text);
                    break;
                default:
                    LogManager.GetLogger(declaringType.FullName).Info(text);
                    break;
            };
        }
   
        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            var propertyInfos = typeof(T).GetProperties();
            DataTable table = new DataTable();

            foreach (var property in propertyInfos)
                table.Columns.Add(property.Name);

            foreach (T item in data)
            {
                var newRow = table.NewRow();
                int column = 0;

                foreach (var property in propertyInfos)
                {
                    var value = property.PropertyType.IsEnum
                        ? Convert.ChangeType(property.GetValue(item, null), Enum.GetUnderlyingType(property.PropertyType))
                        : property.GetValue(item, null);

                    newRow[column] = value;

                    column++;
                }

                table.Rows.Add(newRow);
            }
            return table;
        }
        public static DateTime ToDateTime(string tarih)
        {
            DateTime dateTime;
            tarih = tarih.Trim().Replace('/', '.').Replace('-', '.').Replace('_', '.');

            if (tarih.IndexOf(':') != -1)
                tarih = tarih.Substring(0, tarih.IndexOf(':') - 2).Trim();

            if (DateTime.TryParseExact(tarih, "yyyy.MM.dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                return dateTime;
            else if (DateTime.TryParseExact(tarih, "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                return dateTime;
            else if (DateTime.TryParseExact(tarih, "d.MMM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                return dateTime;
            else if (DateTime.TryParseExact(tarih, "MMM d.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                return dateTime;
            else if (DateTime.TryParseExact(tarih, "DDD MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                return dateTime;
            else if (DateTime.TryParseExact(tarih, "M.d.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                return dateTime;
            else if (DateTime.TryParseExact(tarih, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                return dateTime;
            else
            {
                long ticks;
                if (long.TryParse(tarih, out ticks))
                    return new DateTime(ticks);
                return new DateTime(1900, 1, 1);
            }

        }

    }
    public static class ApiDescriptionExtensions
    {
        /// <summary>
        /// Generates an URI-friendly ID for the <see cref="ApiDescription"/>. E.g. "Get-Values-id_name" instead of "GetValues/{id}?name={name}"
        /// </summary>
        /// <param name="description">The <see cref="ApiDescription"/>.</param>
        /// <returns>The ID as a string.</returns>
        public static string GetFriendlyId(this ApiDescription description)
        {
            string path = description.RelativePath;
            string[] urlParts = path.Split('?');
            string localPath = urlParts[0];
            string queryKeyString = null;
            if (urlParts.Length > 1)
            {
                string query = urlParts[1];
                string[] queryKeys = HttpUtility.ParseQueryString(query).AllKeys;
                queryKeyString = String.Join("_", queryKeys);
            }

            StringBuilder friendlyPath = new StringBuilder();
            friendlyPath.AppendFormat("{0}-{1}",
                description.HttpMethod,
                localPath.Replace("/", "-").Replace("{", String.Empty).Replace("}", String.Empty));
            if (queryKeyString != null)
            {
                friendlyPath.AppendFormat("_{0}", queryKeyString.Replace('.', '-'));
            }
            return friendlyPath.ToString();
        }
    }
}
