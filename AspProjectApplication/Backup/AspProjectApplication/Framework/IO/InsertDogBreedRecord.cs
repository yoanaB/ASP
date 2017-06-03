using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Xml;
using AspProjectApplication.Framework.DbDublicateCheck;
using AspProjectApplication.Framework.DbFieldsValidation;

namespace AspProjectApplication.Framework.IO
{
    public static class InsertDogBreedRecord
    {
        public static void InsertAdogRecordIntoTheDataBase  (   dogRecord aDogRecord, TextBox errorsTextBox )
        {
            //Проверяваме дали имаме запис в GroupInfo, който съдържа aDogBreed.group
            if (!RecordsCheckAndValidation.IsThereSuchAGroupInTheDb(aDogRecord.group, errorsTextBox))
            {
                var myConnection                = new SqlConnection(@"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=aspProjectDB;Integrated Security=True");
                var sqlIns                      = string.Format("INSERT GroupInfo (group_id,droup_description) VALUES ('{0}','{1}')", aDogRecord.group, aDogRecord.group_description);

                try
                {
                                                myConnection.Open();
                    var myCommand               = new SqlCommand(sqlIns, myConnection);
                                                myCommand.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    errorsTextBox.Text          += "Получи се проблем при вмъкване на данни в GroupInfo.Вероятна причина за това е вече наличен запис. \n" + ex.Message + "\n\n\n\n\n";
                }
                finally
                {
                                                myConnection.Close();
                }
            }
            //Проверяваме дали имаме запис в SectionInfo, който да съдържа dogBreed.section
            if (!CheckForADublicate.IsThereSuchASectionInTheDb(aDogRecord.section))
            {
                var myConnection                = new SqlConnection(@"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=aspProjectDB;Integrated Security=True");
                var sqlIns                      = string.Format("INSERT SectionInfo (section_id,section_description) VALUES ('{0}','{1}')", aDogRecord.section, aDogRecord.section_description);

                try
                {
                    myConnection.Open();
                    var myCommand = new SqlCommand(sqlIns, myConnection);
                    myCommand.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    errorsTextBox.Text          += "Получи се проблем при вмъкване на данни в SectionInfo.Вероятна причина за това е вече наличен запис. \n" + ex.Message + "\n\n\n\n\n\n";
                }
                finally
                {
                                                myConnection.Close();
                }
            }
            //Проверяваме дали имаме запис в CountryInfo, който да съдържа dogBreed.country_code
            if (!CheckForADublicate.IsThereSuchACountryCodeInTheDb(aDogRecord.country_code))
            {
                var myConnection                = new SqlConnection(@"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=aspProjectDB;Integrated Security=True");
                var sqlIns                      = string.Format("INSERT CountryInfo (country_code,country_capital,country_language,country_time_zone,country_currency,country_name,country_continent,country_government_type) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", aDogRecord.country_code, aDogRecord.capital, aDogRecord.official_language, aDogRecord.time_zone, aDogRecord.currency, aDogRecord.country_name, aDogRecord.country_continent, aDogRecord.country_government_type);

                try
                {
                                                myConnection.Open();
                    var myCommand               = new SqlCommand(sqlIns, myConnection);
                                                myCommand.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    errorsTextBox.Text          += "Получи се проблем при вмъкването на данни в CountryInfo.Вероятна причина за това е вече наличен запис. \n" + ex.Message + "\n\n\n\n\n\n";
                }
                catch (InvalidOperationException ex)
                {
                    errorsTextBox.Text          += "Получи се проблем при вмъкването на данни в CountryInfo.Вероятна причина за това е вече наличен запис. \n" + ex.Message + "\n\n\n\n\n\n";
                }
                finally
                {
                                                myConnection.Close();
                }
            }

            //Тук правим опит за вмъкване на запис в DogCharacteristics И евентуално прихващаме изключение ако вече съществува такъв запис
            try
            {
                var myConnection                = new SqlConnection(@"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=aspProjectDB;Integrated Security=True");
                var sqlIns                      = string.Format("INSERT DogCharacteristics (dog_sn,dog_name,country_code,year_established,head_form,teeth,ears,eyes,tail,primary_color,secondary_color,prefered_color,fur,image,males_size,females_size,males_weight,females_weight) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')", aDogRecord.standart_number, aDogRecord.name, aDogRecord.country_code, aDogRecord.year_establishment, aDogRecord.head, aDogRecord.teeth, aDogRecord.ears, aDogRecord.eyes, aDogRecord.tail, aDogRecord.primary_color, aDogRecord.secondary_color, aDogRecord.prefered_color, aDogRecord.fur, aDogRecord.image, aDogRecord.males_size, aDogRecord.females_size, aDogRecord.males_weight, aDogRecord.females_weight);
                                                myConnection.Open();
                var myCommand                   = new SqlCommand(sqlIns, myConnection);
                                                myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                errorsTextBox.Text              += "Получи се проблем при вмъкването на данни в DogCharacteristics.Вероятна причини за това са: \n 1.Съществуване на вече наличен запис \n 2.Конфликт между пръвичен ключе и външен ключ за таблици, които са в реалиця \n" + ex.Message + "\n\n\n\n\n\n\n\n\n";

            }
            catch (InvalidOperationException ex)
            {
                errorsTextBox.Text              += "Получи се проблем при вмъкването на данни в DogCharacteristics.Вероятна причини за това са: \n 1.Съществуване на вече наличен запис \n 2.Конфликт между пръвичен ключе и външен ключ за таблици, които са в реалиця \n" + ex.Message + "\n\n\n\n\n\n\n\n\n";
            }

            //Тук правим опит за вкарване на запис в ConnectingTable И евентуално прихващаме изключение ако вече съществува такъв запис
            try
            {
                var myConnection                = new SqlConnection(@"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=aspProjectDB;Integrated Security=True");
                var sqlIns                      = string.Format("INSERT ConnectingTable (standart_number,groupNumber,sectionNumber) VALUES ('{0}','{1}','{2}')", aDogRecord.standart_number, aDogRecord.group, aDogRecord.section);
                                                myConnection.Open();
                var myCommand                   = new SqlCommand(sqlIns, myConnection);
                                                myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                errorsTextBox.Text              += "Получи се проблем при вмъкването на данни в ConnectingTable.Вероятна причина за това е вече наличен запис \n" + ex.Message + "\n\n\n\n\n";
            }
            catch (InvalidOperationException ex)
            {
                errorsTextBox.Text              += "Получи се проблем при вмъкването на данни в ConnectingTable.Вероятна причина за това е вече наличен запис \n" + ex.Message + "\n\n\n\n\n";
            }


        }

        public static void CreateValidXmlDocument           (   TextBox standartNumberInput,TextBox groupInput,TextBox sectionInput,
                                                                TextBox breedNameInput,TextBox countryCapitalInput,TextBox officialLanguageInput,
                                                                DropDownList timeZoneInput,TextBox currencyInput,TextBox countryCodeInput,
                                                                TextBox countryNameInput,DropDownList countryContinentDropDownListInput,TextBox governmentTypeInput,
                                                                TextBox yearEstablishedInput,TextBox headFormInput,TextBox teethInput,
                                                                TextBox earsInput,TextBox eyesInput,TextBox tailInput,
                                                                TextBox primaryColorInput,TextBox secondaryColorInput,TextBox preferedColorInput,
                                                                TextBox furInput,TextBox imageInput,TextBox malesSizeInput,
                                                                TextBox femalesSizeInput,TextBox malesWeightInput,TextBox femalesWeightInput,
                                                                TextBox sectionDescrInput, TextBox groupDescrInput)
        {
            var xmlDoc                                  = new XmlDocument();

            XmlNode rooNode                             = xmlDoc.CreateElement("fci");
                                                        xmlDoc.AppendChild                              (rooNode);

            XmlNode dogBreeds                           = xmlDoc.CreateElement("dog_breeds");
                                                        rooNode.AppendChild                             (dogBreeds);

            XmlNode dogBreed                            = xmlDoc.CreateElement("dog_breed");
            var standartNumber                          = xmlDoc.CreateAttribute("standart_number");
            standartNumber.Value                        = standartNumberInput.Text;

            var group                                   = xmlDoc.CreateAttribute("group");
            group.Value                                 = groupInput.Text;

            var section                                 = xmlDoc.CreateAttribute("section");
            section.Value                               = sectionInput.Text;

                                                        dogBreed.Attributes.Append                      (standartNumber);
                                                        dogBreed.Attributes.Append                      (group);
                                                        dogBreed.Attributes.Append                      (section);

            XmlNode name                                = xmlDoc.CreateElement("name");
            name.InnerText                              = breedNameInput.Text;

            XmlNode country                             = xmlDoc.CreateElement("country");
            var capital                                 = xmlDoc.CreateAttribute("capital");
            capital.Value                               = countryCapitalInput.Text;

            var officialLanguage                        = xmlDoc.CreateAttribute("official_language");
            officialLanguage.Value                      = officialLanguageInput.Text;

            var timeZone                                = xmlDoc.CreateAttribute("time_zone");
            timeZone.Value                              = timeZoneInput.Text;

            var currency                                = xmlDoc.CreateAttribute("currency");
            currency.Value                              = currencyInput.Text;

            var countryCode                             = xmlDoc.CreateAttribute("country_code");
            countryCode.Value                           = countryCodeInput.Text;

            XmlNode countryName                         = xmlDoc.CreateElement("country_name");
            countryName.InnerText                       = countryNameInput.Text;

            XmlNode countryContinent                    = xmlDoc.CreateElement("country_continent");
            countryContinent.InnerText                  = countryContinentDropDownListInput.Text;

            XmlNode countryGovernmentType               = xmlDoc.CreateElement("country_government_type");
            countryGovernmentType.InnerText             = governmentTypeInput.Text;

                                                        country.Attributes.Append                   (capital);
                                                        country.Attributes.Append                   (officialLanguage);
                                                        country.Attributes.Append                   (timeZone);
                                                        country.Attributes.Append                   (currency);
                                                        country.Attributes.Append                   (countryCode);
                                                        country.AppendChild                         (countryName);
                                                        country.AppendChild                         (countryContinent);
                                                        country.AppendChild                         (countryGovernmentType);

                                                        dogBreed.AppendChild                        (country);
                                                        dogBreed.AppendChild                        (name);

            XmlNode yearOfEstablishment                 = xmlDoc.CreateElement("year_of_establishment");
            yearOfEstablishment.InnerText               = yearEstablishedInput.Text;

            XmlNode head                                = xmlDoc.CreateElement("head");
            head.InnerText                              = headFormInput.Text;

            XmlNode teeth                               = xmlDoc.CreateElement("teeth");
            teeth.InnerText                             = teethInput.Text;

            XmlNode ears                                = xmlDoc.CreateElement("ears");
            ears.InnerText                              = earsInput.Text;

            XmlNode eyes                                = xmlDoc.CreateElement("eyes");
            eyes.InnerText                              = eyesInput.Text;

            XmlNode tail                                = xmlDoc.CreateElement("tail");
            tail.InnerText                              = tailInput.Text;

            XmlNode colors                              = xmlDoc.CreateElement("colors");

            XmlNode primaryColor                        = xmlDoc.CreateElement("primary_color");
            primaryColor.InnerText                      = primaryColorInput.Text;

            XmlNode secondaryColor                      = xmlDoc.CreateElement("secondary_color");
            secondaryColor.InnerText                    = secondaryColorInput.Text;

            XmlNode preferedColor                       = xmlDoc.CreateElement("prefered_color");
            preferedColor.InnerText                     = preferedColorInput.Text;

                                                        colors.AppendChild                          (primaryColor);
                                                        colors.AppendChild                          (secondaryColor);
                                                        colors.AppendChild                          (preferedColor);

            XmlNode fur                                 = xmlDoc.CreateElement("fur");
            fur.InnerText                               = furInput.Text;

            XmlNode image                               = xmlDoc.CreateElement("image");
            image.InnerText                             = imageInput.Text;

            XmlNode size                                = xmlDoc.CreateElement("size");
            XmlNode malesSize                           = xmlDoc.CreateElement("males_size");
            malesSize.InnerText                         = malesSizeInput.Text;

            XmlNode femalesSize                         = xmlDoc.CreateElement("females_size");
            femalesSize.InnerText                       = femalesSizeInput.Text;

                                                        size.AppendChild                            (malesSize);
                                                        size.AppendChild                            (femalesSize);

            XmlNode weight                              = xmlDoc.CreateElement("weight");
            XmlNode malesWeight                         = xmlDoc.CreateElement("males_weight");
            malesWeight.InnerText                       = malesWeightInput.Text;

            XmlNode femalesWeight                       = xmlDoc.CreateElement("females_weight");
            femalesWeight.InnerText                     = femalesWeightInput.Text;

                                                        weight.AppendChild                          (malesWeight);
                                                        weight.AppendChild                          (femalesWeight);

                                                        dogBreed.AppendChild                        (yearOfEstablishment);
                                                        dogBreed.AppendChild                        (head);
                                                        dogBreed.AppendChild                        (teeth);
                                                        dogBreed.AppendChild                        (ears);
                                                        dogBreed.AppendChild                        (eyes);
                                                        dogBreed.AppendChild                        (tail);
                                                        dogBreed.AppendChild                        (colors);
                                                        dogBreed.AppendChild                        (fur);
                                                        dogBreed.AppendChild                        (image);
                                                        dogBreed.AppendChild                        (size);
                                                        dogBreed.AppendChild                        (weight);

                                                        dogBreeds.AppendChild                       (dogBreed);
                                                        rooNode.AppendChild                         (dogBreeds);

            XmlNode sections                            = xmlDoc.CreateElement("sections");
            XmlNode section1                            = xmlDoc.CreateElement("section");
            var sectionId                               = xmlDoc.CreateAttribute("section_id");
            sectionId.Value                             = sectionInput.Text;
            section1.InnerText                          = sectionDescrInput.Text;

                                                        section1.Attributes.Append                  (sectionId);
                                                        sections.AppendChild                        (section1);
                                                        rooNode.AppendChild                         (sections);

            XmlNode groups                              = xmlDoc.CreateElement("groups");
            XmlNode group1                              = xmlDoc.CreateElement("group");
            var groupCode                               = xmlDoc.CreateAttribute("group_code");
            groupCode.Value                             = groupInput.Text;
            group1.InnerText                            = groupDescrInput.Text;




                                                        group1.Attributes.Append                        (groupCode);
                                                        groups.AppendChild                          (group1);
                                                        rooNode.AppendChild                         (groups);


            //Това е стринг, който указва пътя, в който ще се записва XML документа.Използваме номера на въведеният стандарт 
            //с цел уникалност на името на файла (понеже и номера на стандарт е уникален)
            var nameXml                                 = string.Format(
                "C:\\Users\\user\\Desktop\\AspProject_KristianAzmanov_71323_sourceCode\\AspProjectApplication\\AspProjectApplication\\App_Data\\xmlDocument_{0}.xml", standartNumberInput.Text);


                                                        xmlDoc.Save                                 (nameXml);
        }
    }
}