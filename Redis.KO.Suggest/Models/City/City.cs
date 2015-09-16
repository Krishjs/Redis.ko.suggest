//-----------------------------------------------------------------------
// <copyright file="City.cs" company="MSC - Ibox">
//     Mediterranean Shipping Company SA - Ibox.
//     OneVision Project // </copyright>
//-----------------------------------------------------------------------

namespace CityDataSource
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class City
    {
        private long id;

        private string code;

        private string name;

        private string foreignLanguageName;

        private string uncode;

        private string zipCode;

        private State stateInfo;

        private DateTime validFrom;

        private DateTime validTo;

        private IList<CityZipCode> zipCodeList;

        private double? latitude;

        private double? longitude;

        public City()
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

        public string ForeignLanguageName
        {
            get { return this.foreignLanguageName; }

            set { this.foreignLanguageName = value; }
        }

        public State StateInfo
        {
            get
            {
                if (this.stateInfo == null)
                {
                    this.stateInfo = new State();
                }

                return this.stateInfo;
            }

            set
            {
                this.stateInfo = value;
            }
        }

        public string UNCode
        {
            get { return this.uncode; }

            set { this.uncode = value; }
        }

        public string ZipCode
        {
            get { return this.zipCode; }

            set { this.zipCode = value; }
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

        public IList<CityZipCode> ZipCodeList
        {
            get
            {
                if (this.zipCodeList == null)
                {
                    this.zipCodeList = new List<CityZipCode>();
                }

                return this.zipCodeList;
            }
        }

        public double? Latitude
        {
            get { return this.latitude; }

            set { this.latitude = value; }
        }

        public double? Longitude
        {
            get { return this.longitude; }

            set { this.longitude = value; }
        }
    }
}