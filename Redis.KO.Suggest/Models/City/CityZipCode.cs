// ----------------------------------------------------------------------
// <copyright file="CityZipCode.cs" company="iBox Technology">
//     Copyright (c) iBox Technology. All right reserved
// </copyright>
//
// ------------------------------------------------------------------------
namespace CityDataSource
{
    using System;

    [Serializable]
    public class CityZipCode
    {
        private long id;
        private long cityId;
        private string cityZip;
        private RecordStatus status;

        public CityZipCode()
        {
            this.Status = RecordStatus.Added;
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

        public long CityId
        {
            get
            {
                return this.cityId;
            }

            set
            {
                this.cityId = value;
            }
        }

        public string CityZip
        {
            get
            {
                return this.cityZip;
            }

            set
            {
                this.cityZip = value;
            }
        }

        public RecordStatus Status
        {
            get
            {
                return this.status;
            }

            set
            {
                this.status = value;
            }
        }
    }
}