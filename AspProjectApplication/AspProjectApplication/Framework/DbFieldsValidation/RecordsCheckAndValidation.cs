using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Schema;


namespace AspProjectApplication.Framework.DbFieldsValidation
{
    public static class RecordsCheckAndValidation
    {
        /// <summary>
        /// //Това е функция, която проверява дали въведеният номер на порода е валиден 
        /// </summary>
        /// <param name="snTextBox"></param>
        /// <returns></returns>
        public static bool          IsStandartNumberValid                   (TextBox  snTextBox)
        {
            const string pattern            = @"^[A-Z]{3}$";
            var myRegex                     = new Regex(pattern);

            var test                        = snTextBox.Text;

            return myRegex.IsMatch(test, 0);
        }

        /// <summary>
        /// Това е функция, която проверява дали номерът  на групата е в правилният формат:"group*"
        /// </summary>
        /// <param name="gnTextBox"></param>
        /// <returns></returns>
        public static bool          IsGroupNumberValid                      (ITextControl gnTextBox )
        {
            const string pattern            = @"^group[A-D]{1}$";

            var myRegex                     = new Regex(pattern, 0);

            return myRegex.IsMatch(gnTextBox.Text);
        }

        /// <summary>
        /// Това е функция, която проверява дали номерът на категорията е в павилният формат:"cat*"
        /// </summary>
        /// <param name="snTextBox"></param>
        /// <returns></returns>
        public static bool          IsSectionNumberValid                    (ITextControl snTextBox,ITextControl grTextBox)
        {

            const string pattern                     = @"^cat[1-4]{1}$";

            var myRegex                     = new Regex(pattern, 0);

            return myRegex.IsMatch(snTextBox.Text);
        }

        /// <summary>
        /// Това е функция, която проверява дали кодът на държавата е в правилният формат:"BGN"
        /// </summary>
        /// <param name="countryCodeTextBox"></param>
        /// <returns></returns>
        public static bool          IsCountryCodeNumberValid                (ITextControl countryCodeTextBox)
        {
            var groupNumber                 = string.Empty;

            const string pattern            = @"^[A-Z]{3}$";

            var myRegex                     = new Regex(pattern, 0);

            return myRegex.IsMatch(countryCodeTextBox.Text);
        }

        /// <summary>
        /// Това е функция, която проверява дали въведената годиан е цяло положително число : 1998
        /// </summary>
        /// <param name="yearEstTextBox"></param>
        /// <returns></returns>
        public static bool          IsYearEstablishedValid                  (ITextControl yearEstTextBox)
        {
            const string pattern            = @"^[1,2,3,4,5,6,7,8,9]\d*$";

            var myRegex                     = new Regex(pattern, 0);

            return myRegex.IsMatch(yearEstTextBox.Text);
        }

        /// <summary>
        /// Това е функция която връща като резултат дали подаденият като аргумент номер на стандарт вече съществува в базата данни
        /// </summary>
        /// <param name="aStandartNumber"></param>
        /// <returns></returns>
        public static bool          IsThereSuchAStandartNumber              (string aStandartNumber)
        {
            var myConnection = new SqlConnection(@"Data Source=.;Initial Catalog=Cat_DB;Integrated Security=True");
            var table                       = new DataTable();

            try
            {
                // var myConnection            = new SqlConnection(@"Data Source=.;Initial Catalog=Cat_DB;Integrated Security=True");
                var sqlSelect               = string.Format("SELECT * FROM ConnectingTable WHERE breed_number  = '{0}'", aStandartNumber);

                                            myConnection.Open();

                var adapter                 = new SqlDataAdapter(sqlSelect, myConnection);
                                            adapter.Fill(table);
            }
            catch (SqlException)
            {

            }
            finally
            {
                myConnection.Close();
            }
            return table.Rows.Count != 0;

        }

        /// <summary>
        /// Чрез тази функция, подаваме името(пътя до) на XML документа и като резултат получава булева стойност, който казва дали
        ///  Документът е валиден или не.Проверката е за Validation с DTD и File Name Collision.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="errorTextBox"></param>
        /// <returns></returns>
        public static bool          ValidationResult                        (string filePath, TextBox errorTextBox)
        {
            var validationCheckResult       = true;


            var  settings                   = new XmlReaderSettings
                {
                    DtdProcessing           = DtdProcessing.Parse,
                    ValidationType          = ValidationType.DTD
                };

            try
            {

                var reader1                 = XmlReader.Create(filePath, settings);

                try
                {

                    while (reader1.Read())
                    {

                        //В тази част reader1 чете ред-по-ред и същевременно съпоставя с cat_breed.dtd
                        //Там където намери несъответствие между елементът, който чете в момента
                        //и елементът, който е се е очаквало да прочете връща изключение, което се прихваща в по-долния ред

                    }
                }
                catch (Exception ex)
                {
                    if (ex is XmlException || ex is XmlSchemaException || ex is XmlSchemaValidationException)
                    {
                        validationCheckResult = false;
                        return validationCheckResult;
                    }
                }
                return validationCheckResult;
            }
            catch (FileNotFoundException ex)
            {
                validationCheckResult = false;
                errorTextBox.Text += "There was a problem with the opening of the file \n" + ex.Message + "\n";
                return validationCheckResult;
            }
            /* finally
            {
                myConnection.Close();
            } */

        }

        /// <summary>
        /// Това е функцията, която приема като аргумент име на група и проверява дали вече имам такава група въведана в базата от данни(GroupInfo)
        /// </summary>
        /// <param name="aGroup"></param>
        /// <param name="errorTextBox"></param>
        /// <returns></returns>
        public static bool          IsThereSuchAGroupInTheDb                (string aGroup, TextBox errorTextBox)
        {
            var myConnection = new SqlConnection(@"Data Source=.;Initial Catalog=Cat_DB;Integrated Security=True");
            var table                       = new DataTable();

            try
            {
                
                var sqlSelect               = string.Format("SELECT * FROM GroupInfo WHERE group_id = '{0}'", aGroup);

                                            myConnection.Open();

                var  adapter                = new SqlDataAdapter(sqlSelect, myConnection);
                                            adapter.Fill(table);
            }
            catch (SqlException)
            {

            }
            catch (InvalidOperationException ex)
            {
                errorTextBox.Text           += "Получи се проблем от страна на SQL Сървъра \n" + ex.Message;
            }
            finally
            {
                myConnection.Close();
            }
            return table.Rows.Count != 0;

        }
    }
}