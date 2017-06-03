using System;
using AspProjectApplication.Framework.ButtonClickEvents;
using AspProjectApplication.Framework.DbFieldsValidation;

namespace AspProjectApplication
{
    public partial class FillXml : System.Web.UI.Page
    {

        protected void              Page_Load                   ( object sender, EventArgs e )
        {
            submitResult_Lable.Visible = false;
            errorsLog_TextBox.Visible = false;
        }

        //На това място пишем валидирането на полетата от fillXML и обработката на данните
        protected void              submitXmlButton_Click       ( object sender, EventArgs e )
       {
           submitResult_Lable.Text                          = string.Empty;
           standratNumberStatus_Label.Text                  = string.Empty;
           groupStatus_Label.Text                           = string.Empty;
           sectionStatus_Label.Text                         = string.Empty;
           countryCodeStatus_Label.Text                     = string.Empty;
           yearEstablishedStatus_Label.Text                 = string.Empty;

           SubmitXmlButtonHelper();
           
       }

        private void                SubmitXmlButtonHelper       ( )
        {
            if (RecordsCheckAndValidation.IsStandartNumberValid(standartNumber_Input)
                && RecordsCheckAndValidation.IsGroupNumberValid(groupInput)
                && RecordsCheckAndValidation.IsSectionNumberValid(sectionInput,groupInput)
                && RecordsCheckAndValidation.IsCountryCodeNumberValid(countryCodeInput))
            {
                ButtonClickHandler.SubmitXmlButtonWithSuccessfulValidation(standratNumberStatus_Label,groupStatus_Label,sectionStatus_Label,
                                                                           countryCodeStatus_Label,yearEstablishedStatus_Label,submitResult_Lable,
                                                                           standartNumber_Input,groupInput,sectionInput,groupDescrInput,sectionDescrInput,
                                                                           breedNameInput,countryCodeInput,countryCapitalInput,officialLanguageInput,
                                                                           timeZoneInput,currencyInput,countryNameInput,countryContinent_DropDownListInput,
                                                                           governmentTypeInput,yearEstablishedInput,headFormInput,teethInput,earsInput,
                                                                           eyesInput,tailInput,primaryColorInput,secondaryColorInput,preferedColorInput,
                                                                           furInput,imageInput,malesSizeInput,femalesSizeInput,malesWeightInput,
                                                                           femalesWeightInput,submitResult_Lable,errorsLog_TextBox);
            }
            else
            {
                submitResult_Lable.Text                     = "Получи се проблем при валидацията на въведените данни.";
                submitResult_Lable.Visible                  = true;
                submitResult_Lable.ForeColor                = System.Drawing.Color.Red;

                                                            submitResult_Lable.Dispose          ( );

                if (!RecordsCheckAndValidation.IsStandartNumberValid(standartNumber_Input))
                {
                    standratNumberStatus_Label.Text         = "Въведеният номер на стандарт е невалиден!";
                    standratNumberStatus_Label.Visible      = true;
                    standratNumberStatus_Label.ForeColor    = System.Drawing.Color.IndianRed;

                                                            standratNumberStatus_Label.Dispose  ( );
                }

                if (!RecordsCheckAndValidation.IsGroupNumberValid(groupInput))
                {
                    groupStatus_Label.Text                  = "Въведеният номер на група е невалиден!";
                    groupStatus_Label.Visible               = true;
                    groupStatus_Label.ForeColor             = System.Drawing.Color.IndianRed;

                                                            groupStatus_Label.Dispose           ( );
                }

                if (!RecordsCheckAndValidation.IsSectionNumberValid(sectionInput,groupInput))
                {
                    sectionStatus_Label.Text                = "Въведеният номер на секция е невалиден!";
                    sectionStatus_Label.Visible             = true;
                    sectionStatus_Label.ForeColor           = System.Drawing.Color.IndianRed;

                    sectionStatus_Label.Dispose();
                }

                if (!RecordsCheckAndValidation.IsCountryCodeNumberValid(countryCodeInput))
                {
                    countryCodeStatus_Label.Text            = "Въведеният Код на държава е невалиден!";
                    countryCodeStatus_Label.Visible         = true;
                    countryCodeStatus_Label.ForeColor       = System.Drawing.Color.IndianRed;

                    countryCodeStatus_Label.Dispose();
                }
                if (!RecordsCheckAndValidation.IsYearEstablishedValid(yearEstablishedInput))
                {
                    yearEstablishedStatus_Label.Text        = "Въведената година е невалидна!";
                    yearEstablishedStatus_Label.Visible     = true;
                    yearEstablishedStatus_Label.ForeColor   = System.Drawing.Color.IndianRed;

                    yearEstablishedStatus_Label.Dispose();
                }
            }
        }

    }
}