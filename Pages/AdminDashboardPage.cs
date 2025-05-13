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
            ConfigureNotificationsListView();
            LoadLatestNotifications();
            notificationsListView.ItemActivate += NotificationsListView_ItemActivate;

            this.tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
        }

        private void NotificationsListView_ItemActivate(object sender, EventArgs e)
        {
          
        }

        private void StyleListView(ListView listView)
        {
            if (listView == null) return;

            listView.FullRowSelect = true;
            listView.GridLines = false;
            listView.Font = new Font("Segoe UI", 10);
            listView.BackColor = Color.White;
            listView.ForeColor = Color.Black;
            listView.BorderStyle = BorderStyle.None;
            listView.MultiSelect = false;
            listView.View = View.Details;

            listView.OwnerDraw = true;
            listView.DrawColumnHeader += (sender, e) => {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(46, 125, 50)), e.Bounds);
                e.Graphics.DrawString(listView.Columns[e.ColumnIndex].Text,
                    new Font("Segoe UI", 11, FontStyle.Bold),
                    new SolidBrush(Color.White),
                    e.Bounds.X + 5, e.Bounds.Y + 2);
            };

            listView.DrawItem += (sender, e) => {
            };

            listView.DrawSubItem += (sender, e) => {
                e.DrawBackground();
                e.Graphics.DrawString(e.SubItem.Text, listView.Font, new SolidBrush(listView.ForeColor),
                    e.Bounds.X + 5, e.Bounds.Y + 3);
            };
        }

        private void ConfigureNotificationsListView()
        {
            if (notificationsListView == null)
            {
                notificationsListView = new ListView();
                notificationsListView.Dock = DockStyle.Fill;
                notificationsListView.Resize += (sender, e) => ResizeListViewColumns();
            }
            StyleListView(notificationsListView);

            notificationsListView.Columns.Clear();
            notificationsListView.Columns.Add("Zaman", 150);
            notificationsListView.Columns.Add("Başlık", 75);
            notificationsListView.Columns.Add("Mesaj", 150);
            notificationsListView.Columns.Add("Tür", 120);

            // İlk boyutlandırmayı yap
            ResizeListViewColumns();
        }

        private void ResizeListViewColumns()
        {
            if (notificationsListView.Columns.Count == 0)
                return;

            int totalWidth = notificationsListView.ClientSize.Width;
            if (totalWidth <= 0) return;

            // ScrollBar kontrolü
            if (notificationsListView.Items.Count > 0 &&
                notificationsListView.Items[0].Bounds.Height * notificationsListView.Items.Count > notificationsListView.ClientSize.Height)
            {
                totalWidth -= SystemInformation.VerticalScrollBarWidth;
            }
        }

        private void LoadLatestNotifications()
        {
            try
            {
                notificationsListView.Items.Clear();

                // NotificationDataAccess sınıfını kullanarak bildirimleri çek
                var notificationDataAccess = new GreenByte.DataAccess.NotificationDataAccess();

                try
                {
                    var allNotifications = notificationDataAccess.GetAll();

                    if (allNotifications == null)
                    {
                        MessageBox.Show("Bildirim verisi alınamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (allNotifications.Count == 0)
                    {
                        MessageBox.Show("Hiç bildirim bulunamadı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var latestNotifications = allNotifications.Take(10).ToList(); //SON 10 BİLDİRİM

                    foreach (var notification in latestNotifications)
                    {
                        try
                        {
                            // Tarihi formatla
                            string timeFormatted = notification.Olusturma_Zamani.ToString("dd.MM.yyyy HH:mm:ss");

                            var item = new ListViewItem(timeFormatted);
                            item.SubItems.Add(notification.Baslik);
                            item.SubItems.Add(notification.Mesaj);
                            item.SubItems.Add(notification.Tur);

                            bool isOkundu = false;
                            if (notification.Okundu is bool boolValue)
                            {
                                isOkundu = boolValue;
                            }
                            else if (int.TryParse(notification.Okundu.ToString(), out int intValue))
                            {
                                isOkundu = intValue > 0;
                            }
                            else if (notification.Okundu != null && int.TryParse(notification.Okundu.ToString(), out int parsedValue))
                            {
                                isOkundu = parsedValue > 0;
                            }
                            
                            // Bildirim ID'sini Tag özelliğinde saklayalım
                            item.Tag = notification.Id;

                            Color originalColor = notification.GetColor();
                            Color lighterColor = notification.GetColor();

                            if (originalColor != Color.White)
                            {
                                int r = Math.Min(255, originalColor.R + 40);
                                int g = Math.Min(255, originalColor.G + 40);
                                int b = Math.Min(255, originalColor.B + 40);
                                lighterColor = Color.FromArgb(r, g, b);
                            }

                            item.BackColor = lighterColor;

                            notificationsListView.Items.Add(item);
                        }
                        catch (Exception itemEx)
                        {
                            MessageBox.Show($"Bir öğe eklenirken hata oluştu: {itemEx.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Console.WriteLine($"Öğe ekleme hatası: {itemEx.Message}");
                        }
                    }
                }
                catch (Exception innerEx)
                {
                    MessageBox.Show("Bildirimler yüklenirken hata oluştu: " + innerEx.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"Bildirim yükleme hatası: {innerEx.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bildirimler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Genel bildirim hatası: {ex.Message}");
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
            try
            {
                var sensorDataAccess = new SensorDataAccess();

                // Sıcaklık sensörünün son verisi
                var sicaklikData = sensorDataAccess.GetBySensorId(1).OrderByDescending(d => d.RecordTime).FirstOrDefault();
                if (sicaklikData != null)
                    labelSicaklik.Text = $"{sicaklikData.Value} °C";

                // Nem sensörünün son verisi
                var nemData = sensorDataAccess.GetBySensorId(2).OrderByDescending(d => d.RecordTime).FirstOrDefault();
                if (nemData != null)
                    labelNem.Text = $"{nemData.Value} %";

                // Toprak nemi sensörünün son verisi
                var toprakNemData = sensorDataAccess.GetBySensorId(4).OrderByDescending(d => d.RecordTime).FirstOrDefault();
                if (toprakNemData != null)
                    labelToprakNem.Text = $"{toprakNemData.Value} %";

                // Işık seviyesi sensörünün son verisi
                var isikData = sensorDataAccess.GetBySensorId(3).OrderByDescending(d => d.RecordTime).FirstOrDefault();
                if (isikData != null)
                    labelIsik.Text = $"{isikData.Value} lux";

                // Su seviyesi sensörünün son verisi
                var suSeviyeData = sensorDataAccess.GetBySensorId(6).OrderByDescending(d => d.RecordTime).FirstOrDefault();
                if (suSeviyeData != null)
                    labelSuSeviyesi.Text = $"{suSeviyeData.Value} %";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sensör verileri güncellenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Sensör veri güncelleme hatası: {ex.Message}");
            }
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
            var sicaklikVerileri = sensorDataAccess.GetBySensorId(1);
            var nemVerileri = sensorDataAccess.GetBySensorId(2); // Eğer nem sensörünün id'si 7 ise

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