using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Xml;
using AspProjectApplication.Framework.DbDublicateCheck;
using AspProjectApplication.Framework.DbFieldsValidation;

namespace AspProjectApplication.Framework.IO
{
    public static class InsertCatBreedRecord
    {
        public static void InsertAdogRecordIntoTheDataBase  (   catRecord aCatRecord, TextBox errorsTextBox )
        {
            //Проверяваме дали имаме запис в GroupInfo, който съдържа aCatBreed.group
            if (!RecordsCheckAndValidation.IsThereSuchAGroupInTheDb(aCatRecord.group, errorsTextBox))
            {
                var myConnection                = new SqlConnection(@"Data Source=.;Initial Catalog=Cat_DB;Integrated Security=True");
                var sqlIns                      = string.Format("INSERT GroupInfo (group_id,group_description) VALUES ('{0}','{1}')", aCatRecord.group, aCatRecord.group_description);

                try
                {
                                                myConnection.Open();
                    var myCommand               = new SqlCommand(sqlIns, myConnection);
                                                myCommand.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    errorsTextBox.Text          += "Получи се проблем при вмъкване на данни в  GroupInfo.Вероятна причина за това е вече наличен запис. \n" + ex.Message + "\n\n\n\n\n";
                }
                catch (InvalidOperationException ex)
                {
                    errorsTextBox.Text += "Получи се проблем при вмъкването на данни в CountryInfo.Вероятна причина за това е вече наличен запис. \n" + ex.Message + "\n\n\n\n\n\n";
                }
                finally
                {
                                                myConnection.Close();
                }
            }
            //Проверяваме дали имаме запис в CatInfo, който да съдържа dogBreed.section
            if (!CheckForADublicate.IsThereSuchASectionInTheDb(aCatRecord.section))
            {
                var myConnection                = new SqlConnection(@"Data Source=.;Initial Catalog=Cat_DB;Integrated Security=True");
                var sqlIns                      = string.Format("INSERT CategoryInfo (category_id,category_descriptio) VALUES ('{0}','{1}')", aCatRecord.section, aCatRecord.section_description);

                try
                {
                    myConnection.Open();
                    var myCommand = new SqlCommand(sqlIns, myConnection);
                    myCommand.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    errorsTextBox.Text          += "Получи се проблем при вмъкване на данни в CategoryInfo.Вероятна причина за това е вече наличен запис. \n" + ex.Message + "\n\n\n\n\n\n";
                }
                catch (InvalidOperationException ex)
                {
                    errorsTextBox.Text += "Получи се проблем при вмъкването на данни в CountryInfo.Вероятна причина за това е вече наличен запис. \n" + ex.Message + "\n\n\n\n\n\n";
                }
                finally
                {
                                                myConnection.Close();
                }
            }
            //Проверяваме дали имаме запис в CountryInfo, който да съдържа dogBreed.country_code
            if (!CheckForADublicate.IsThereSuchACountryCodeInTheDb(aCatRecord.country_code))
            {
                var myConnection                = new SqlConnection(@"Data Source=.;Initial Catalog=Cat_DB;Integrated Security=True");
                var sqlIns                      = string.Format("INSERT Country (country_code,capital,official_language,time_zone,currency,country_name,country_continent,country_government_type) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", aCatRecord.country_code, aCatRecord.capital, aCatRecord.official_language, aCatRecord.time_zone, aCatRecord.currency, aCatRecord.country_name, aCatRecord.country_continent, aCatRecord.country_government_type);

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
                var myConnection                = new SqlConnection(@"Data Source=.;Initial Catalog=Cat_DB;Integrated Security=True");
                var sqlIns                      = string.Format("INSERT CatBreedInfo (breed_number, breed_name,country_code,year_established,head,ears,eyes,tail,primary_color,secondary_color,prefered_color,fur,image,males_size,females_size,personality) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')", aCatRecord.standart_number, aCatRecord.name, aCatRecord.country_code, aCatRecord.year_establishment, aCatRecord.head, aCatRecord.ears, aCatRecord.eyes, aCatRecord.tail, aCatRecord.primary_color, aCatRecord.secondary_color, aCatRecord.prefered_color, aCatRecord.fur, aCatRecord.image, aCatRecord.males_size, aCatRecord.females_size, aCatRecord.personality);
                                                myConnection.Open();
                var myCommand                   = new SqlCommand(sqlIns, myConnection);
                                                myCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                errorsTextBox.Text              += "Получи се проблем при вмъкването на данни в CatBreedInfo.Вероятна причини за това са: \n 1.Съществуване на вече наличен запис \n 2.Конфликт между пръвичен ключе и външен ключ за таблици, които са в реалиця \n" + ex.Message + "\n\n\n\n\n\n\n\n\n";

            }
            catch (InvalidOperationException ex)
            {
                errorsTextBox.Text              += "Получи се проблем при вмъкването на данни в CatBreedInfo.Вероятна причини за това са: \n 1.Съществуване на вече наличен запис \n 2.Конфликт между пръвичен ключе и външен ключ за таблици, които са в реалиця \n" + ex.Message + "\n\n\n\n\n\n\n\n\n";
            }

            //Тук правим опит за вкарване на запис в ConnectingTable И евентуално прихващаме изключение ако вече съществува такъв запис
            try
            {
                var myConnection                = new SqlConnection(@"Data Source=.;Initial Catalog=Cat_DB;Integrated Security=True");
                var sqlIns                      = string.Format("INSERT ConnectingTable (categoty_number, breed_number, group_number) VALUES ('{0}','{1}','{2}')", aCatRecord.standart_number, aCatRecord.group, aCatRecord.section);
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
                                                                TextBox yearEstablishedInput,TextBox headFormInput,TextBox personalityInput,
                                                                TextBox earsInput,TextBox eyesInput,TextBox tailInput,
                                                                TextBox primaryColorInput,TextBox secondaryColorInput,TextBox preferedColorInput,
                                                                TextBox furInput,TextBox imageInput,TextBox malesSizeInput,
                                                                TextBox femalesSizeInput,
                                                                TextBox sectionDescrInput, TextBox groupDescrInput)
        {
            var xmlDoc                                  = new XmlDocument();

            XmlNode rooNode                             = xmlDoc.CreateElement("fif");
                                                        xmlDoc.AppendChild                              (rooNode);

            XmlNode dogBreeds                           = xmlDoc.CreateElement("cat_breeds");
                                                        rooNode.AppendChild                             (dogBreeds);

            XmlNode dogBreed                            = xmlDoc.CreateElement("cat_breed");
            var standartNumber                          = xmlDoc.CreateAttribute("standart_number");
            standartNumber.Value                        = standartNumberInput.Text;

            var group                                   = xmlDoc.CreateAttribute("group");
            group.Value                                 = groupInput.Text;

            var category                                = xmlDoc.CreateAttribute("category");
            category.Value                              = sectionInput.Text;

            dogBreed.Attributes.Append                   (standartNumber);
            dogBreed.Attributes.Append                   (group);
            dogBreed.Attributes.Append                   (category);


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

            XmlNode ears                                = xmlDoc.CreateElement("ears");
            ears.InnerText                              = earsInput.Text;

            XmlNode eyes                                = xmlDoc.CreateElement("eyes");
            eyes.InnerText                              = eyesInput.Text;

            XmlNode tail                                = xmlDoc.CreateElement("tail");
            tail.InnerText                              = tailInput.Text;

            XmlNode personality =                       xmlDoc.CreateElement("personality");
            personality.InnerText =                     tailInput.Text;

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

                                                        dogBreed.AppendChild                        (yearOfEstablishment);
                                                        dogBreed.AppendChild                        (head);
                                                        dogBreed.AppendChild                        (ears);
                                                        dogBreed.AppendChild                        (eyes);
                                                        dogBreed.AppendChild                        (tail);
                                                        dogBreed.AppendChild                        (colors);
                                                        dogBreed.AppendChild                        (fur);
                                                        dogBreed.AppendChild                        (image);
                                                        dogBreed.AppendChild                        (size);
                                                        dogBreed.AppendChild                        (personality);

                                                        dogBreeds.AppendChild                       (dogBreed);
                                                        rooNode.AppendChild                         (dogBreeds);

            XmlNode categories                          = xmlDoc.CreateElement("categories");
            XmlNode category1                           = xmlDoc.CreateElement("category");
            var sectionId                               = xmlDoc.CreateAttribute("category_id");
            sectionId.Value                             = sectionInput.Text;
            category1.InnerText                         = sectionDescrInput.Text;

                                                        category1.Attributes.Append                  (sectionId);
                                                        categories.AppendChild                        (category1);
                                                        rooNode.AppendChild                         (categories);

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
                "D:\\Documents\\ASP\\AspProject_KristianAzmanov_71323_sourceCode\\AspProjectApplication\\AspProjectApplication\\App_Data\\xmlDocument_{0}.xml", standartNumberInput.Text);


                                                        xmlDoc.Save                                 (nameXml);
        }
    }
}