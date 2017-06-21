using System;
using System.IO;
using System.Xml;
using AspProjectApplication.Framework.DbFieldsValidation;
using AspProjectApplication.Framework.IO;


namespace AspProjectApplication
{
    public partial class _Default : System.Web.UI.Page
    {
       
        /// <summary>
        /// Тук декларираме контейнер, който ще използваме когато зареждаме файловете в БД
        /// Правим го така за да можем да имаме индексиран достъп до елементите
        /// </summary>
        readonly string[] _xmlContainer = Directory.GetFiles(@"D:\Documents\ASP\AspProject_YoanaBoyanova_71540_sourceCode\XML_Files\XML_Cat", "*.xml");
   
        
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void submit_Button_Click(object sender, EventArgs e)
        {
            //Тук изчистваме текстовото поле, в което се показва резултатът от въвеждането на данните в БД
            submissionResult_TextBox.Text = string.Empty;

            for (var k = 0; k < _xmlContainer.Length; k++)
            {
                 if (RecordsCheckAndValidation.ValidationResult(_xmlContainer[k], errorsLog_TextBox))
                {
                    var existsOrNotInDb = "Да";
                    var exist = false;

                    //Crate XML document
                    var reader = new XmlDocument();
                    reader.Load(_xmlContainer[k]);

                    //С този ред запазваме в променливата elementList всички поделементи на cat_breed като група
                    XmlNodeList elementsList = reader.GetElementsByTagName("cat_breed");

                    //Тук в countryList запазваме списък от групи с (country_name,country_continent,country_government_type..)
                    XmlNodeList countryList = reader.GetElementsByTagName("country");

                    //В тази променлива запазваме групите свързани с (primary_color,secodnary_color,prefered_color)
                    XmlNodeList colorsList = reader.GetElementsByTagName("colors");

                    //В този списък запазваме групите свързани със (males_size,females_size)
                    XmlNodeList sizesList = reader.GetElementsByTagName("size");

                    //В този списък запазваме стойностите, които стоят в елемента <groups>
                    XmlNodeList seperateGroupsList = reader.GetElementsByTagName("groups");

                    //В този списък запазваме стойностите, които стоят в елемента <categories>
                    XmlNodeList seperateSectionList = reader.GetElementsByTagName("categories");

                    for (int i = 0; i < elementsList.Count; i++)
                    {

                        //Тук е мястото, където ще създадем новият обект от тип catRecord
                        //Който ще попълваме в следващите стъпки от тази итерация.
                        //След като го пъплним на всяка една от стъпките, след това би трябвало да ни е по-лесно да
                        //работм с него при добавянето в БД

                        catRecord tmpCat = new catRecord();

                        foreach (XmlElement element in elementsList[i].ChildNodes)
                        {
                            if (element.HasAttributes)
                            {
                                //На този ред прочитаме атрибутите на cat_breed(standart_number,group,section)
                                foreach (XmlAttribute atr in element.ParentNode.Attributes)
                                {
                                    //richTextOutput_TextBox.Text += atr.Name + "::" + atr.InnerText + "\n";

                                    if (atr.Name == "standart_number") { tmpCat.standart_number=atr.InnerText; }
                                    if (atr.Name == "group") { tmpCat.group = atr.InnerText; }
                                    if (atr.Name == "category") { tmpCat.section = atr.InnerText; }

                                    //На този ред започва сравненеито между лемемнтите в <groups> и текущата group за да можем да 
                                    //вземем описанието на групата, в която попада породата котка
                                    for (int j = 0; j < seperateGroupsList.Count; j++)
                                    {
                                        foreach (XmlElement groupElement in seperateGroupsList[j].ChildNodes)
                                        {
                                            //richTextOutput_TextBox.Text += groupElement.InnerText;
                                            if (groupElement.HasAttribute("group_code") && atr.InnerText == groupElement.GetAttribute("group_code"))
                                            {

                                                //richTextOutput_TextBox.Text += "Group Description"+"::"+groupElement.InnerText + "\n";
                                                tmpCat.group_description = groupElement.InnerText;
                                            }
                                        }

                                    }

                                    //На този ред започва сравненеито между лемемнтите в <sections> и текущата section за да можем да 
                                    //вземем описанието на секцията, в която попада породата котка
                                    for (int j = 0; j < seperateSectionList.Count; j++)
                                    {
                                        foreach (XmlElement sectionElement in seperateSectionList[j].ChildNodes)
                                        {
                                            //richTextOutput_TextBox.Text += groupElement.InnerText;
                                            if (sectionElement.HasAttribute("category_id") && atr.InnerText == sectionElement.GetAttribute("category_id"))
                                            {

                                                //richTextOutput_TextBox.Text += "Section Description" + "::" + sectionElement.InnerText + "\n";
                                                tmpCat.section_description = sectionElement.InnerText;
                                            }
                                        }

                                    }

                                    

                                }

                                //Тук прочитаме атрибутите на country(country_code,capital,official_language,time_zone,currency)
                                foreach (XmlAttribute el in element.Attributes)
                                {
                                    //richTextOutput_TextBox.Text += el.Name + "::" + el.InnerText + "\n";
                                    if (el.Name == "country_code") { tmpCat.country_code = el.InnerText; }
                                    if (el.Name == "capital") { tmpCat.capital=el.InnerText; }
                                    if (el.Name == "official_language") { tmpCat.official_language = el.InnerText; }
                                    if (el.Name == "time_zone") { tmpCat.time_zone = el.InnerText; }
                                    if (el.Name == "currency") { tmpCat.currency = el.InnerText; }
                                }
                            }



                            if (element.Name != "country" && element.Name != "colors" && element.Name != "size" )
                            {
                                //richTextOutput_TextBox.Text += element.Name + "::" + element.InnerText + "\n";
                                if (element.Name == "name"){ tmpCat.name = element.InnerText;}
                                if (element.Name == "year_of_establishment") 
                                { tmpCat.year_establishment= Convert.ToInt32(element.InnerText); }
                                if (element.Name == "head") { tmpCat.head = element.InnerText; }
                                if (element.Name == "ears") { tmpCat.ears = element.InnerText; }
                                if (element.Name == "eyes") { tmpCat.eyes = element.InnerText; }
                                if (element.Name == "tail") { tmpCat.tail = element.InnerText; }
                                if (element.Name == "fur") { tmpCat.fur = element.InnerText; }
                                if (element.Name == "image") { tmpCat.image = element.InnerText; }
                                if (element.Name == "personality") { tmpCat.personality = element.InnerText; }

                            }

                            if (element.Name == "country")
                            {
                                foreach (XmlElement cElement in countryList[i].ChildNodes)
                                {
                                    //richTextOutput_TextBox.Text += cElement.Name + "::" + cElement.InnerText + "\n";
                                    if (cElement.Name == "country_name") { tmpCat.country_name=cElement.InnerText; }
                                    if (cElement.Name == "country_continent") { tmpCat.country_continent=cElement.InnerText; }
                                    if (cElement.Name == "country_government_type") { tmpCat.country_government_type=cElement.InnerText; }
                                }
                            }

                            if (element.Name == "colors")
                            {
                                foreach (XmlElement colElement in colorsList[i].ChildNodes)
                                {
                                    //richTextOutput_TextBox.Text += colElement.Name + "::" + colElement.InnerText + "\n";
                                    if (colElement.Name == "primary_color") { tmpCat.primary_color=colElement.InnerText; }
                                    if (colElement.Name == "secondary_color") { tmpCat.secondary_color = colElement.InnerText; }
                                    if (colElement.Name == "prefered_color") { tmpCat.prefered_color = colElement.InnerText; }
                                }
                            }

                            if (element.Name == "size")
                            {
                                foreach (XmlElement sizeElement in sizesList[i].ChildNodes)
                                {
                                    //richTextOutput_TextBox.Text += sizeElement.Name + "::" + sizeElement.InnerText + "\n";
                                    if (sizeElement.Name == "males_size") { tmpCat.males_size=sizeElement.InnerText; }
                                    if (sizeElement.Name == "females_size") { tmpCat.females_size = sizeElement.InnerText; }
                                }
                            }

                          

                        }

                        //Преди да вмъкнем записа проверяваме дали вече има такъв в БД и съответно извеждаме съобщение дали го има
                        //Или го няма в БД
                        if (RecordsCheckAndValidation.IsThereSuchAStandartNumber(tmpCat.standart_number))
                        {
                            exist = true;
                            existsOrNotInDb = "Вече съществува такъв запис в базата данни";
                            
                        }
                        
                        //Тук е мястото, на което след като вече имаме catRecord попълнен го подаваме на функция
                        // insertAcatRecordIntoTheDataBase(catRecord object) и тя вече преценява, какво да прави с него, тоест
                        //Дали е валиден за въвеждане.Ако - да го въвежда, ако- не, не го въвежда и преминаваме нататък

                         InsertCatBreedRecord.InsertAcatRecordIntoTheDataBase(tmpCat, errorsLog_TextBox, exist);

                    }
                    submissionResult_TextBox.Text += "(" + k + ")";
                    submissionResult_TextBox.Text +=("Име на файл:"+Path.GetFileName(_xmlContainer[k]) + "\n \n Валиден:ДА\n Добавен към базата данни:"+existsOrNotInDb+"\n");
                }
                else
                {
                    
                    submissionResult_TextBox.Text += "(" + k + ")";
                    submissionResult_TextBox.Text +="Име на файл:"+ Path.GetFileName(_xmlContainer[k]) + "\n \n Валиден:НЕ \n Добавен в базата данни:НЕ \n";
                }
                submissionResult_TextBox.Text += "\n ================================================= \n";
            }
        }

        //Това е EventHandler чрез който преминаваме към страницата, в която ще попълваме XML документа
        protected void fillXML_Click(object sender, EventArgs e)
        {
            Response.Redirect("fillXml.aspx");
        }
              
    }
}
