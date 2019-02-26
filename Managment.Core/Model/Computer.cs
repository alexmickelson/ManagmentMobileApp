using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SQLite;

namespace Managment.Core.Model
{
    public class Computer
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        [RegularExpression(@"^[0-9a-fA-F{2}:]+[0-9a-fA-F{2}]$", ErrorMessage = "Invalid IP Address")]
        public string MAC { get; set; }
        [RegularExpression(@"^\d +.\d +.\d +.\d +$", ErrorMessage = "Invalid IP Address")]
        public string IPAddress { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }

        public string Print
        {
            get =>  $"SerialNumber: {SerialNumber}\nMac Address: {MAC}\nIP Address: {IPAddress}\nLocation: {Location}\nNotes: {Notes}\n";
           
        }
    }
}
