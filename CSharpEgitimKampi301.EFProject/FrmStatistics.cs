﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics: Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            
            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapacity.Text = db.Location.Sum(x => x.Capacity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAvgCapacity.Text = db.Location.Average(x => (decimal?)x.Capacity)?.ToString("0.00");
            lblAvgLocationPrice.Text = db.Location.Average(x => (decimal?)x.Price)?.ToString("0.00") + " ₺";
            
            int lblLastCountryId = db.Location.Max(x => x.LocationId);
            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lblLastCountryId).Select(y => y.Country).FirstOrDefault();

            lblCappadociaLocationCapacity.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();
            lblTurkiyeCapacityAvg.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y => (decimal?)y.Capacity)?.ToString("0.00");

            var romeGuideId = db.Location.Where(x=>x.City == "Roma Turistik").Select(y=>y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.Guide.Where(x => x.GuideId == romeGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault();

            var maxCapacity = db.Location.Max(x => x.Capacity);
            lblMaxCapacityLocation.Text = db.Location.Where(x => x.Capacity == maxCapacity).Select(y => y.City ).FirstOrDefault();

            var maxPrice = db.Location.Max(x => x.Price);
            lblMostExpensiveLocation.Text = db.Location.Where(x=>x.Price == maxPrice).Select(y=>y.City).FirstOrDefault();

            //lblAysegulCinarLocationCount.Text = db.Location.Where(x => x.GuideId == 2).Count().ToString();

            var guideIdByNameAysegulCinar = db.Guide.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar").Select(y => y.GuideId).FirstOrDefault();
            lblAysegulCinarLocationCount.Text = db.Location.Where(x => x.GuideId == guideIdByNameAysegulCinar).Count().ToString();



        }
    }
}