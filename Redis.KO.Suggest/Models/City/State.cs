// ----------------------------------------------------------------------
// <copyright file="State.cs" company="iBox Technology">
//     Copyright (c) iBox Technology. All right reserved
// </copyright>
//
// ------------------------------------------------------------------------

namespace CityDataSource
{
    using System;

    [Serializable]
    public class State
    {
        private long id;
        private string code;
        private string name;
        private string foreignLanguageName;
        private Country countryInfo;
        private DateTime validFrom;
        private DateTime validTo;

        public State()
            : base()
        {
            this.CountryInfo = new Country();
        }

        public long Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        public string Code
        {
            get { return this.code; }

            set { this.code = value; }
        }

        public string Name
        {
            get { return this.name; }

            set { this.name = value; }
        }

        public string ForeignLanguageName
        {
            get { return this.foreignLanguageName; }

            set { this.foreignLanguageName = value; }
        }

        public Country CountryInfo
        {
            get { return this.countryInfo; }

            set { this.countryInfo = value; }
        }

        public DateTime ValidFrom
        {
            get { return this.validFrom; }

            set { this.validFrom = value; }
        }

        public DateTime ValidTo
        {
            get { return this.validTo; }

            set { this.validTo = value; }
        }
    }
}