using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using GreenByte.DataAccess;
using GreenByte.Models;

namespace greenByte.Controls
{
    public partial class AdminDashboardPage : UserControl
    {
        private Chart temperatureHumidityChart;

        public AdminDashboardPage()
        {
            InitializeComponent();
            updateLabelsByData();
            ChartHazirla();
            ConfigureDeviceEventsListView(); // Yeni metot çağrısı
            LoadLatestDeviceEvents(); // Yeni metot çağrısı

            this.tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
        }

        private void ConfigureDeviceEventsListView()
        {
            // ListView'i yapılandır
            deviceEventsListView.View = View.Details;
            deviceEventsListView.FullRowSelect = true;
            deviceEventsListView.GridLines = true;
            deviceEventsListView.Font = new Font("Segoe UI", 9);

            // ListView'in sütunlarını temizle (varsa)
            deviceEventsListView.Columns.Clear();

            // Sütunları ekle - cihaz_olaylari tablosuna göre düzenlendi
            deviceEventsListView.Columns.Add("Zaman", 150);
            deviceEventsListView.Columns.Add("Cihaz ID", 80);
            deviceEventsListView.Columns.Add("İşlem", 120);
            deviceEventsListView.Columns.Add("Tetikleyici", 120);
        }

        private void LoadLatestDeviceEvents()
        {
            try
            {
                deviceEventsListView.Items.Clear();

                // DeviceEventDataAccess sınıfını kullanarak cihaz olaylarını çek
                var deviceEventDataAccess = new GreenByte.DataAccess.DeviceEventDataAccess();

                try
                {
                    var allEvents = deviceEventDataAccess.GetAll();

                    // Null kontrolü
                    if (allEvents == null)
                    {
                        MessageBox.Show("GetAll metodu null döndürdü", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AddSampleDeviceEvents();
                        return;
                    }

                    // Boş liste kontrolü
                    if (allEvents.Count == 0)
                    {
                        MessageBox.Show("Veri tabanında hiç cihaz olayı bulunamadı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AddSampleDeviceEvents();
                        return;
                    }

                    // Son 10 olayı tarihe göre sırala ve al
                    var latestEvents = allEvents
                        .OrderByDescending(e => e.Time)
                        .Take(10)
                        .ToList();

                    foreach (var deviceEvent in latestEvents)
                    {
                        try
                        {
                            // Tarihi formatla
                            string timeFormatted = deviceEvent.Time.ToString("dd.MM.yyyy HH:mm:ss");

                            var item = new ListViewItem(timeFormatted);
                            item.SubItems.Add(deviceEvent.DeviceId.ToString());
                            item.SubItems.Add(deviceEvent.GetActionName());
                            item.SubItems.Add(deviceEvent.GetTriggerEventName());
                            item.SubItems.Add(deviceEvent.Status ?? "");
                            item.SubItems.Add(deviceEvent.Description ?? "");

                            // Renklendirme
                            item.BackColor = deviceEvent.GetRowColor();

                            deviceEventsListView.Items.Add(item);
                        }
                        catch (Exception itemEx)
                        {
                            MessageBox.Show($"Bir öğe eklenirken hata oluştu: {itemEx.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception innerEx)
                {
                    MessageBox.Show("GetAll metodu çağrılırken hata oluştu: " + innerEx.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AddSampleDeviceEvents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cihaz olayları yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AddSampleDeviceEvents();
            }
        }

        // Test için örnek veriler ekleyen metod
        private void AddSampleDeviceEvents()
        {
            deviceEventsListView.Items.Clear();

            // Test için 5 örnek veri ekleyelim
            for (int i = 0; i < 5; i++)
            {
                var item = new ListViewItem(DateTime.Now.AddHours(-i).ToString("dd.MM.yyyy HH:mm:ss"));

                // Cihaz ID: bu kısmı kontrol edin
                item.SubItems.Add($"{i + 1}"); // İ+1 şeklinde değer oluşturuluyor, 0 olmamalı

                // Diğer değerler...
                // ...

                deviceEventsListView.Items.Add(item);
            }
        }
        

        // Bildirimleri yenilemek için metot (isteğe bağlı)
        public void RefreshDeviceEvents()
        {
            LoadLatestDeviceEvents();
        }

        // Olay tipini metne dönüştür
        private string GetEventTypeName(int eventType)
        {
            // Bu değerleri kendi projenizde kullanılan değerlere göre güncellemelisiniz
            switch (eventType)
            {
                case 0:
                    return "Bilgi";
                case 1:
                    return "Uyarı";
                case 2:
                    return "Alarm";
                case 3:
                    return "İşlem Başarılı";
                default:
                    return "Bilinmeyen";
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
          
            var panel = sender as TableLayoutPanel;
            if (panel != null)
            {
                using (var pen = new System.Drawing.Pen(Color.LightGray, 2))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
                }
            }
        
        }

        private void updateLabelsByData()
        {
            var sensorDataAccess = new SensorDataAccess();

            // Sıcaklık sensörünün son verisi (id: 6)
            var sicaklikData = sensorDataAccess.GetBySensorId(1).OrderByDescending(d => d.RecordTime).FirstOrDefault();
            if (sicaklikData != null)
                labelSicaklik.Text = $"{sicaklikData.Value} °C";

            // Nem sensörünün son verisi (id: 7)
            var nemData = sensorDataAccess.GetBySensorId(2).OrderByDescending(d => d.RecordTime).FirstOrDefault();
            if (nemData != null)
                labelNem.Text = $"{nemData.Value} %";

            // Toprak nemi sensörünün son verisi (id: 7)
            var toprakNemData = sensorDataAccess.GetBySensorId(4).OrderByDescending(d => d.RecordTime).FirstOrDefault();
            if (toprakNemData != null)
                labelToprakNem.Text = $"{toprakNemData.Value} %";

            // Işık seviyesi sensörünün son verisi (id: 9)
            var isikData = sensorDataAccess.GetBySensorId(3).OrderByDescending(d => d.RecordTime).FirstOrDefault();
            if (isikData != null)
                labelIsik.Text = $"{isikData.Value} lux";

            var suSeviyeData = sensorDataAccess.GetBySensorId(6).OrderByDescending(d => d.RecordTime).FirstOrDefault();
            if (suSeviyeData != null)
                labelSuSeviyesi.Text = $"{suSeviyeData.Value} %";
        }


        private void ChartHazirla()
        {
            chartSicaklikVeNem.Series.Clear();

            var sicaklikSerisi = new System.Windows.Forms.DataVisualization.Charting.Series("Sıcaklık (°C)")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line,
                Color = System.Drawing.Color.Red,
                BorderWidth = 2
            };

            var nemSerisi = new System.Windows.Forms.DataVisualization.Charting.Series("Nem (%)")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line,
                Color = System.Drawing.Color.Blue,
                BorderWidth = 2
            };

            // SensorDataAccess ile sıcaklık ve nem verilerini çek
            var sensorDataAccess = new SensorDataAccess();

            // Sıcaklık ve nem sensörlerinin id'si 6 ise:
            var sicaklikVerileri = sensorDataAccess.GetBySensorId(6);
            var nemVerileri = sensorDataAccess.GetBySensorId(7); // Eğer nem sensörünün id'si 7 ise

            // X ekseni için saat/zaman bilgisini kullan
            foreach (var data in sicaklikVerileri.Cast<SensorData>())
            {
                sicaklikSerisi.Points.AddXY(data.RecordTime.ToString("HH:mm"), data.Value);
            }
            foreach (var data in nemVerileri.Cast<SensorData>())
            {
                nemSerisi.Points.AddXY(data.RecordTime.ToString("HH:mm"), data.Value);
            }

            chartSicaklikVeNem.Series.Add(sicaklikSerisi);
            chartSicaklikVeNem.Series.Add(nemSerisi);

            var ca = chartSicaklikVeNem.ChartAreas[0];
            ca.AxisX.Title = "Saat";
            ca.AxisY.Title = "Değer";
            ca.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            ca.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            ca.AxisX.LabelStyle.Angle = -45;

            chartSicaklikVeNem.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
        }

       

    }
}