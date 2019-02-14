using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Managment.Core.Model
{
    public class Computer
    {
        [PrimaryKey]
        public string SerialNumber { get; set; }
        public string MAC { get; set; }
        public string IPAddress { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }

        public string Print
        {
            get =>  $"SerialNumber: {SerialNumber}\nMac Address: {MAC}\nIP Address: {IPAddress}\nLocation: {Location}\nNotes: {Notes}\n";
           
        }
    }
}
