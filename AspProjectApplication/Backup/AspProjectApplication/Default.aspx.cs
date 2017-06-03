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
        readonly string[] _xmlContainer = Directory.GetFiles(@"C:\Users\user\Desktop\XML_Files\XML_Files", "*.xml");
   
        
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

                    //Crate XML document
                    var reader = new XmlDocument();
                    reader.Load(_xmlContainer[k]);

                    //С този ред запазваме в променливата elementList всички поделементи на dog_breed като група
                    XmlNodeList elementsList = reader.GetElementsByTagName("dog_breed");

                    //Тук в countryList запазваме списък от групи с (country_name,country_continent,country_government_type..)
                    XmlNodeList countryList = reader.GetElementsByTagName("country");

                    //В тази променлива запазваме групите свързани с (primary_color,secodnary_color,prefered_color)
                    XmlNodeList colorsList = reader.GetElementsByTagName("colors");

                    //В този списък запазваме групите свързани със (males_size,females_size)
                    XmlNodeList sizesList = reader.GetElementsByTagName("size");

                    //В този списък запазваме групите свързани със (males_weight,females_weight)
                    XmlNodeList weightsList = reader.GetElementsByTagName("weight");

                    //В този списък запазваме стойностите, които стоят в елемента <groups>
                    XmlNodeList seperateGroupsList = reader.GetElementsByTagName("groups");

                    //В този списък запазваме стойностите, които стоят в елемента <sections>
                    XmlNodeList seperateSectionList = reader.GetElementsByTagName("sections");

                    for (int i = 0; i < elementsList.Count; i++)
                    {

                        //Тук е мястото, където ще създадем новият обект от тип dogRecord
                        //Който ще попълваме в следващите стъпки от тази итерация.
                        //След като го пъплним на всяка една от стъпките, след това би трябвало да ни е по-лесно да
                        //работм с него при добавянето в БД

                        dogRecord tmpDog = new dogRecord();

                        foreach (XmlElement element in elementsList[i].ChildNodes)
                        {
                            if (element.HasAttributes)
                            {
                                //На този ред прочитаме атрибутите на dog_breed(standart_number,group,section)
                                foreach (XmlAttribute atr in element.ParentNode.Attributes)
                                {
                                    //richTextOutput_TextBox.Text += atr.Name + "::" + atr.InnerText + "\n";

                                    if (atr.Name == "standart_number") { tmpDog.standart_number=atr.InnerText; }
                                    if (atr.Name == "group") { tmpDog.group = atr.InnerText; }
                                    if (atr.Name == "section") { tmpDog.section = atr.InnerText; }

                                    //На този ред започва сравненеито между лемемнтите в <groups> и текущата group за да можем да 
                                    //вземем описанието на групата, в която попада породата куче
                                    for (int j = 0; j < seperateGroupsList.Count; j++)
                                    {
                                        foreach (XmlElement groupElement in seperateGroupsList[j].ChildNodes)
                                        {
                                            //richTextOutput_TextBox.Text += groupElement.InnerText;
                                            if (groupElement.HasAttribute("group_code") && atr.InnerText == groupElement.GetAttribute("group_code"))
                                            {

                                                //richTextOutput_TextBox.Text += "Group Description"+"::"+groupElement.InnerText + "\n";
                                                tmpDog.group_description = groupElement.InnerText;
                                            }
                                        }

                                    }

                                    //На този ред започва сравненеито между лемемнтите в <sections> и текущата section за да можем да 
                                    //вземем описанието на секцията, в която попада породата куче
                                    for (int j = 0; j < seperateSectionList.Count; j++)
                                    {
                                        foreach (XmlElement sectionElement in seperateSectionList[j].ChildNodes)
                                        {
                                            //richTextOutput_TextBox.Text += groupElement.InnerText;
                                            if (sectionElement.HasAttribute("section_id") && atr.InnerText == sectionElement.GetAttribute("section_id"))
                                            {

                                                //richTextOutput_TextBox.Text += "Section Description" + "::" + sectionElement.InnerText + "\n";
                                                tmpDog.section_description = sectionElement.InnerText;
                                            }
                                        }

                                    }

                                    

                                }

                                //Тук прочитаме атрибутите на country(country_code,capital,official_language,time_zone,currency)
                                foreach (XmlAttribute el in element.Attributes)
                                {
                                    //richTextOutput_TextBox.Text += el.Name + "::" + el.InnerText + "\n";
                                    if (el.Name == "country_code") { tmpDog.country_code = el.InnerText; }
                                    if (el.Name == "capital") { tmpDog.capital=el.InnerText; }
                                    if (el.Name == "official_language") { tmpDog.official_language = el.InnerText; }
                                    if (el.Name == "time_zone") { tmpDog.time_zone = el.InnerText; }
                                    if (el.Name == "currency") { tmpDog.currency = el.InnerText; }
                                }
                            }



                            if (element.Name != "country" && element.Name != "colors" && element.Name != "size" && element.Name != "weight")
                            {
                                //richTextOutput_TextBox.Text += element.Name + "::" + element.InnerText + "\n";
                                if (element.Name == "name"){tmpDog.name = element.InnerText;}
                                if (element.Name == "year_of_establishment") 
                                { tmpDog.year_establishment= Convert.ToInt32(element.InnerText); }
                                if (element.Name == "head") { tmpDog.head = element.InnerText; }
                                if (element.Name == "teeth") { tmpDog.teeth = element.InnerText; }
                                if (element.Name == "ears") { tmpDog.ears = element.InnerText; }
                                if (element.Name == "eyes") { tmpDog.eyes = element.InnerText; }
                                if (element.Name == "tail") { tmpDog.tail = element.InnerText; }
                                if (element.Name == "fur") { tmpDog.fur = element.InnerText; }
                                if (element.Name == "image") { tmpDog.image = element.InnerText; }

                            }

                            if (element.Name == "country")
                            {
                                foreach (XmlElement cElement in countryList[i].ChildNodes)
                                {
                                    //richTextOutput_TextBox.Text += cElement.Name + "::" + cElement.InnerText + "\n";
                                    if (cElement.Name == "country_name") {tmpDog.country_name=cElement.InnerText; }
                                    if (cElement.Name == "country_continent") { tmpDog.country_continent=cElement.InnerText; }
                                    if (cElement.Name == "country_government_type") { tmpDog.country_government_type=cElement.InnerText; }
                                }
                            }

                            if (element.Name == "colors")
                            {
                                foreach (XmlElement colElement in colorsList[i].ChildNodes)
                                {
                                    //richTextOutput_TextBox.Text += colElement.Name + "::" + colElement.InnerText + "\n";
                                    if (colElement.Name == "primary_color") { tmpDog.primary_color=colElement.InnerText; }
                                    if (colElement.Name == "secondary_color") { tmpDog.secondary_color = colElement.InnerText; }
                                    if (colElement.Name == "prefered_color") { tmpDog.prefered_color = colElement.InnerText; }
                                }
                            }

                            if (element.Name == "size")
                            {
                                foreach (XmlElement sizeElement in sizesList[i].ChildNodes)
                                {
                                    //richTextOutput_TextBox.Text += sizeElement.Name + "::" + sizeElement.InnerText + "\n";
                                    if (sizeElement.Name == "males_size") { tmpDog.males_size=sizeElement.InnerText; }
                                    if (sizeElement.Name == "females_size") { tmpDog.females_size = sizeElement.InnerText; }
                                }
                            }

                            if (element.Name == "weight")
                            {
                                foreach (XmlElement weightElement in weightsList[i].ChildNodes)
                                {
                                    //richTextOutput_TextBox.Text += weightElement.Name + "::" + weightElement.InnerText + "\n";
                                    if (weightElement.Name == "males_weight") { tmpDog.males_weight = weightElement.InnerText; }
                                    if (weightElement.Name == "females_weight") { tmpDog.females_weight = weightElement.InnerText; }
                                }
                            }

                        }

                        //Преди да вмъкнем записа проверяваме дали вече има такъв в БД и съответно извеждаме съобщение дали го има
                        //Или го няма в БД
                        if (RecordsCheckAndValidation.IsThereSuchAStandartNumber(tmpDog.standart_number))
                        {
                            existsOrNotInDb = "Вече съществува такъв запис в базата данни";
                        }
                        
                        //Тук е мястото, на което след като вече имаме dogRecord попълнен го подаваме на функция
                        // insertAdogRecordIntoTheDataBase(dogRecord object) и тя вече преценява, какво да прави с него, тоест
                        //Дали е валиден за въвеждане.Ако - да го въвежда, ако- не, не го въвежда и преминаваме нататък

                         InsertDogBreedRecord.InsertAdogRecordIntoTheDataBase(tmpDog,errorsLog_TextBox);

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
