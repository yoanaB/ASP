using System;
using System.Web.UI.WebControls;
using AspProjectApplication.Framework.DbFieldsValidation;
using AspProjectApplication.Framework.IO;

namespace AspProjectApplication.Framework.ButtonClickEvents
{
    public static class ButtonClickHandler
    {
        public static void SubmitXmlButtonWithSuccessfulValidation( Label snStatusLabel,Label groupStatusLabel,Label sectionStatusLabel,
                                                                    Label countryCodeStatusLabel,Label yearEstablishedStatusLabel,Label submitResultLabel,
                                                                    TextBox snInput,TextBox grInput,TextBox secInput,TextBox grDescrInput,
                                                                    TextBox secDescrInput,TextBox brNameInput,TextBox cntryCodeInput,
                                                                    TextBox cntrCapInput,TextBox offLangInput,DropDownList tZoneInput,
                                                                    TextBox currInput,TextBox cntrNameInput,DropDownList cntryContinentInput, 
                                                                    TextBox govTypeInput,TextBox yearEstInput,TextBox headFrmInput,
                                                                    TextBox earsFormInput,TextBox eyesFormInput, TextBox tailFormInput,
                                                                    TextBox primColInput,TextBox secColInput,TextBox prefColInput,TextBox furFormInput,
                                                                    TextBox imgInput,TextBox mSizeInput,TextBox fSizeInput,
                                                                    TextBox persInput,Label sbmtResLabel,TextBox errTextBox)
        {
            snStatusLabel.Text                      = string.Empty;
            groupStatusLabel.Text                   = string.Empty;
            sectionStatusLabel.Text                 = string.Empty;
            countryCodeStatusLabel.Text             = string.Empty;
            yearEstablishedStatusLabel.Text         = string.Empty;

            submitResultLabel.Text                  = "Записът е валиден и ще бъде добавен в базата данни!";
            submitResultLabel.Visible               = true;
            submitResultLabel.ForeColor             = System.Drawing.Color.Azure;
            submitResultLabel.Dispose();

            if (!RecordsCheckAndValidation.IsThereSuchAStandartNumber(snInput.Text))
            {
                //Тук след като вече сме проверили,че ключовите полета са валидни   
                //създаваме запис от тип dogRecord и го въвеждаме в базата данни
                var myCatRec = new catRecord(snInput.Text, grInput.Text, secInput.Text,
                                             grDescrInput.Text, secInput.Text, brNameInput.Text,
                                             cntryCodeInput.Text, cntrCapInput.Text, offLangInput.Text,
                                             tZoneInput.Text, currInput.Text, cntrNameInput.Text,
                                             cntryContinentInput.Text, govTypeInput.Text,
                                             yearEstInput.Text != string.Empty
                                                 ? Convert.ToInt32(yearEstInput.Text)
                                                 : 0,
                                             earsFormInput.Text, eyesFormInput.Text,
                                             tailFormInput.Text, headFrmInput.Text ,primColInput.Text, 
                                             secColInput.Text, prefColInput.Text, furFormInput.Text, 
                                             imgInput.Text, mSizeInput.Text,
                                             fSizeInput.Text, persInput.Text);

                InsertCatBreedRecord.InsertAdogRecordIntoTheDataBase(myCatRec, errTextBox );

                //След това създаваме XML документ, валиден за посоченото DTD и го попълваме с въведените данни
                InsertCatBreedRecord.CreateValidXmlDocument(snInput,grInput,secInput,brNameInput,cntrCapInput,
                                                            offLangInput,tZoneInput,currInput,cntryCodeInput,
                                                            cntrNameInput, cntryContinentInput, govTypeInput,
                                                            yearEstInput,headFrmInput, persInput, earsFormInput, 
                                                            eyesFormInput,tailFormInput,primColInput,secColInput,
                                                            prefColInput,furFormInput,imgInput,mSizeInput,fSizeInput,
                                                            secDescrInput,grDescrInput);
            }
            else
            {
                sbmtResLabel.Text =
                    "Записът е валиден \n Но няма да бъде въведен в БД защото вече същестува такъв запис!";
                sbmtResLabel.ForeColor      = System.Drawing.Color.Lime;
                                            sbmtResLabel.Dispose();
            }
        }
    }
}