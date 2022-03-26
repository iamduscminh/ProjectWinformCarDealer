using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

#nullable disable

namespace ProjectWinformCarDealer.Models
{
    public partial class Car
    {
        public int CarId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Design { get; set; }
        public string Chair { get; set; }
        public long Price { get; set; }
        public int Wattage { get; set; }
        public int MaximumTorque { get; set; }
        public string Acceleration { get; set; }
        public int MaxSpeed { get; set; }
        public string Co2Emissions { get; set; }
        public int Tall { get; set; }
        public int Wide { get; set; }
        public int Long { get; set; }
        public int Wheelbase { get; set; }
        public string ImageLink { get; set; }
        public string Fuel { get; set; }
        public Image CarImage
        {
            get
            {
                if (!string.IsNullOrEmpty(ImageLink))
                {
                    if (File.Exists(ImageLink))
                        return Image.FromFile(ImageLink);
                }
                return null;
            }
        }
    }

}
