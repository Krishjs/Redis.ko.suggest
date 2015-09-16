// ----------------------------------------------------------------------
// <copyright file="Country.cs" company="iBox Technology">
//     Copyright (c) iBox Technology. All right reserved
// </copyright>
//
// ------------------------------------------------------------------------

namespace CityDataSource
{
    using System;

    [Serializable]
    public class Country
    {
        private long id;
        private string code;
        private string name;
        private string isState;
        private string isZipCode;
        private string foreignLanguageName;
        private bool isEuropeanCountry;
        private bool isCrossBooking;

        public Country()
            : base()
        {
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

        public string IsState
        {
            get { return this.isState; }

            set { this.isState = value; }
        }

        public string IsZipCode
        {
            get { return this.isZipCode; }

            set { this.isZipCode = value; }
        }

        public string ForeignLanguageName
        {
            get { return this.foreignLanguageName; }

            set { this.foreignLanguageName = value; }
        }

        public bool IsEuropeanCountry
        {
            get { return this.isEuropeanCountry; }

            set { this.isEuropeanCountry = value; }
        }

        public bool IsCrossBooking
        {
            get { return this.isCrossBooking; }

            set { this.isCrossBooking = value; }
        }
    }
}