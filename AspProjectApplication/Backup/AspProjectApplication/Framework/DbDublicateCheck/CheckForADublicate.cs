using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AspProjectApplication.Framework.DbDublicateCheck
{
    public static class CheckForADublicate
    {
        /// <summary>
        /// ФУнкция, която ще проверява дали в базата от данни вече има въведена такъв код на държава(CountryInfo)
        /// </summary>
        /// <param name="aCountryCode"></param>
        /// <returns></returns>
        public static bool              IsThereSuchACountryCodeInTheDb              (string aCountryCode)
        {
            var table                       = new DataTable();

            try
            {
                var myConnection            = new SqlConnection(@"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=aspProjectDB;Integrated Security=True");
                var sqlSelect               = string.Format("SELECT * FROM CountryInfo WHERE country_code  = '{0}'", aCountryCode);

                myConnection.Open();

                var adapter                 = new SqlDataAdapter(sqlSelect, myConnection);
                adapter.Fill(table);
            }
            catch (SqlException)
            {

            }
            return table.Rows.Count != 0;
        }

        /// <summary>
        /// Това е функцията, която приема като аргумент име на секция и проверява дали вече имам такава секция въведана в базата от данни(SectionInfo)
        /// </summary>
        /// <param name="aSection"></param>
        /// <returns></returns>
        public static bool              IsThereSuchASectionInTheDb                  (string aSection)
        {
            var table                       = new DataTable();
            try
            {
                var myConnection            = new SqlConnection(@"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=aspProjectDB;Integrated Security=True");
                var sqlSelect               = string.Format("SELECT * FROM SectionInfo WHERE section_id = '{0}'", aSection);

                                            myConnection.Open();

                var adapter                 = new SqlDataAdapter(sqlSelect, myConnection);
                                            adapter.Fill(table);
            }
            catch (SqlException)
            {

            }
            return table.Rows.Count != 0;
        }

        /// <summary>
        /// Това е функцията, която приема като аргумент име на група и проверява дали вече имам такава група въведана в базата от данни(GroupInfo)
        /// </summary>
        /// <param name="aGroup"></param>
        /// <returns></returns>
        public static bool              IsThereSuchAGroupInTheDb                    (string aGroup)
        {
            var table = new DataTable();

            try
            {
                var myConnection            = new SqlConnection(@"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=aspProjectDB;Integrated Security=True");
                var sqlSelect               = string.Format("SELECT * FROM GroupInfo WHERE group_id = '{0}'", aGroup);

                                            myConnection.Open();

                var adapter                 = new SqlDataAdapter(sqlSelect, myConnection);
                                            adapter.Fill(table);
            }
            catch (SqlException)
            {

            }
            return table.Rows.Count != 0;

        }
    }
}