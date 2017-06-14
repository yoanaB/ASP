using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspProjectApplication
{
    public class catRecord
    {
        //These are the private fields of the class
        private string _snumber;
        private string _group;
        private string _section;

        private string _groupDescription;
        private string _sectionDescription;


        
        private string _breedName;
        private string _countryCode;
        private string _capital;
        private string _officialLanguage;
        private string _timeZone;
        private string _currency;
        private string _countryName;
        private string _countryContinent;
        private string _countryGovernmentType;
        private int _yearEstablished;
        private string _personality;
        private string _head;
        private string _ears;
        private string _eyes;
        private string _tail;
        private string _priamryColor;
        private string _secondaryColor;
        private string _preferedColor;
        private string _fur;
        private string _image;
        private string _malesSize;
        private string _femalesSize;
        
        //Public methods that allow us to modify the object
        public string standart_number
        {
            get
            {
                return _snumber;
            }
            set
            {
                _snumber = value;
            }
        }
        public string group
        {
            get
            {
                return _group;
            }
            set
            {
                _group = value;
            }
        }
        public string section
        {
            get
            {
                return _section;
            }
            set
            {
                _section = value;
            }
        }
        public string name
        {
            get
            {
                return _breedName;
            }
            set
            {
                _breedName = value;
            }
        }
        public string head
        {
            get
            {
                return _head;
            }
            set
            {
                _head = value;
            }
        }
        public string country_code
        {
            get
            {
                return _countryCode;
            }
            set
            {
                _countryCode = value;
            }
        }
        public string capital
        {
            get
            {
                return _capital;
            }
            set
            {
                _capital = value;
            }
        }
        public string official_language
        {
            get
            {
                return _officialLanguage;
            }
            set
            {
                _officialLanguage = value;
            }
        }
        public string time_zone
        {
            get
            {
                return _timeZone;
            }
            set
            {
                _timeZone = value;
            }
        }
        public string currency
        {
            get
            {
                return _currency;
            }
            set
            {
                _currency = value;
            }
        }
        public string country_name
        {
            get
            {
                return _countryName;
            }
            set
            {
                _countryName = value;
            }
        }
        public string country_continent
        {
            get
            {
                return _countryContinent;
            }
            set
            {
                _countryContinent = value;
            }
        }
        public string country_government_type
        {
            get
            {
                return _countryGovernmentType;
            }
            set
            {
                _countryGovernmentType = value;
            }
        }
        public int year_establishment
        {
            get
            {
                return _yearEstablished;
            }
            set
            {
                _yearEstablished = value;
            }
        }
        public string personality
        {
            get
            {
                return _personality;
            }
            set
            {
                _personality = value;
            }
        }
        public string ears
        {
            get
            {
                return _ears;
            }
            set
            {
                _ears = value;
            }
        }
        public string eyes
        {
            get
            {
                return _eyes;
            }
            set
            {
                _eyes = value;
            }
        }
        public string tail
        {
            get
            {
                return _tail;
            }
            set
            {
                _tail = value;
            }
        }
        public string primary_color
        {
            get
            {
                return _priamryColor;
            }
            set
            {
                _priamryColor = value;
            }
        }
        public string secondary_color
        {
            get
            {
                return _secondaryColor;
            }
            set
            {
                _secondaryColor = value;
            }
        }
        public string prefered_color
        {
            get
            {
                return _preferedColor;
            }
            set
            {
                _preferedColor = value;
            }
        }
        public string fur
        {
            get
            {
                return _fur;
            }
            set
            {
                _fur = value;
            }
        }
        public string image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }
        public string males_size
        {
            get
            {
                return _malesSize;
            }
            set
            {
                _malesSize = value;
            }
        }
        public string females_size
        {
            get
            {
                return _femalesSize;
            }
            set
            {
                _femalesSize = value;
            }
        }

        public string group_description
        {
            get
            {
                return _groupDescription;
            }
            set
            {
                _groupDescription = value;
            }
        }
        public string section_description
        {
            get
            {
                return _sectionDescription;
            }
            set
            {
                _sectionDescription = value;
            }
        }


        public catRecord(string aSnumber, string aGroup, string aSection, string aGroupDescr, string aSectionDescr, string aBreedName, string aCountryCode, string aCapital,
            string aOfficialLanguage, string aTimeZone, string aCurrency, string aCountryName, string aCountryContinent, string aGovernmentType, int aYearEst,
            string aEars, string aEyes, string aTail, string aHead, string aPrimaryColor, string aSecondaryCol, string aPreferedCol, string aFur, string aImage, string aMalesSize,
            string aFemalesSize, string aPersonality)
        {
            standart_number = aSnumber;
            group = aGroup;
            section = aSection;
            group_description = aGroupDescr;
            section_description = aSectionDescr;
            name = aBreedName;
            country_code = aCountryCode;
            capital = aCapital; 
            official_language = aOfficialLanguage;
            time_zone = aTimeZone;
            currency = aCurrency;
            country_name = aCountryName;
            country_continent = aCountryContinent;
            country_government_type = aGovernmentType;
            year_establishment = aYearEst;
            head = aHead;
            ears = aEars;
            eyes = aEyes;
            tail = aTail;
            primary_color = aPrimaryColor;
            secondary_color = aSecondaryCol;
            prefered_color = aPreferedCol;
            fur = aFur;
            image = aImage;
            males_size = aMalesSize;
            females_size = aFemalesSize;
            personality = aPersonality;
        }

        public catRecord() : this("","","","","","","","","","","","","","",0,"","","","","","","","","","","","") { }

    }
}